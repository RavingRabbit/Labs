using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading;
using Lab4.Communication.Messages;
using Lab4.Communication.Tcp;
using Lab4.Communication.Udp;
using Lab4.ResourceLocking.Config;
using log4net;
using RavingDev.Common;
using RavingDev.Communication.Tcp;
using RavingDev.Communication.Udp;

namespace Lab4.ResourceLocking
{
    internal sealed class ResourceAccessArbiter : IDisposable
    {
        private static readonly TimeSpan UdpTimeout = TimeSpan.FromMilliseconds(1500);
        private static readonly ILog Logger = LogManager.GetLogger(typeof (ResourceAccessArbiter));
        private static readonly IPAddress MulticastAddress;
        private static readonly Int32 TcpPort;
        private static readonly Int32 UdpPort;
        private static readonly IPAddress[] LocalIpAddresses;
        private static readonly ITcpMsgFormatter<UnicastRequest> TcpMsgFormatter = new JsonTcpMsgFormatter<UnicastRequest>();

        private static readonly IDatagramFormatter<MulticastRequest> DatagramFormatter =
            new JsonDatagramFormatter<MulticastRequest>();

        private readonly Dictionary<string, Action> _callbacks;
        private readonly UdpServer _multicastServer;
        private readonly Dictionary<string, List<AccessQueueTicket>> _resourceAccessQueue;
        private readonly MaltyTcpClientHandler<UnicastRequest> _tcpClientHandler;
        private readonly TcpServer _tcpServer;

        static ResourceAccessArbiter()
        {
            var configuration = (ConfigHandler) ConfigurationManager.GetSection(ConfigHandler.SectionName);
            MulticastAddress = IPAddress.Parse(configuration.MulticastAddress);
            TcpPort = configuration.TcpPort;
            UdpPort = configuration.UdpPort;
            LocalIpAddresses = Dns.GetHostAddresses(Dns.GetHostName());
        }

        public ResourceAccessArbiter()
        {
            _resourceAccessQueue = new Dictionary<String, List<AccessQueueTicket>>();
            _callbacks = new Dictionary<string, Action>();
            var datagramHandler = new DatagramHandler<MulticastRequest>(DatagramFormatter, HandleUdpDatagram);
            _multicastServer = new UdpServer(UdpPort, datagramHandler);
            _multicastServer.JoinMulticastGroup(MulticastAddress);
            _multicastServer.Start();

            var tcpMsgHandler = new TcpMessageHandler<UnicastRequest>(HandleTcpMessage);
            _tcpClientHandler = new MaltyTcpClientHandler<UnicastRequest>(TcpMsgFormatter, tcpMsgHandler);
            _tcpServer = new TcpServer(TcpPort, _tcpClientHandler);
            _tcpServer.Start();
        }

// ReSharper disable once EventNeverSubscribedTo.Global
        public event EventHandler StateChanged;

        private void HandleTcpMessage(UnicastRequest msg, IPEndPoint remoteendpoint, out UnicastRequest response)
        {
            Logger.WarnFormat("[TCP] Received from {0}: \"{1}\".", remoteendpoint.Address, msg);
            response = new UnicastRequest(UnicastRequestReason.IvalidRequest, msg.ResourceIdentifier);
        }

        private void HandleUdpDatagram(MulticastRequest datagram, IPEndPoint remoteendpoint)
        {
            if (LocalIpAddresses.Contains(remoteendpoint.Address))
            {
                return;
            }

            Logger.InfoFormat("############ UDP HANDLER START #############");
            Logger.InfoFormat("[UDP] Received from {0}: \"{1}\".", remoteendpoint.Address, datagram);
            string resourceId = datagram.ResourceIdentifier;
            MulticastRequestReason requestReason = datagram.Reason;

            switch (requestReason)
            {
                case MulticastRequestReason.IsResourceLocked:
                {
                    var tcpEndPoint = new IPEndPoint(remoteendpoint.Address, TcpPort);
                    RefreshQueueRespondIfResourceLocked(resourceId, tcpEndPoint);
                    break;
                }
                case MulticastRequestReason.LeavingQueue:
                {
                    RemoveFromQueueIfExists(resourceId, remoteendpoint.Address);
                    CheckIfOwner(resourceId);
                    break;
                }
                default:
                {
                    Logger.WarnFormat("[UDP] [INVALID REQUEST] Received from {0}: \"{1}\".",
                        remoteendpoint.Address, datagram);
                    break;
                }
            }

            Logger.InfoFormat("############ UDP HANDLER END #############");
            OnStateChanged();
            return;
        }

        private void RefreshQueueRespondIfResourceLocked(string resourceId, IPEndPoint tcpRemoteEndPoint)
        {
            if (!IsResourceLocking(resourceId))
            {
                return;
            }
            List<IPAddress> queue = GetWaitingQueue(resourceId);
            if (IsResourceLocked(resourceId))
            {
                var unicastRequest = new UnicastRequest(UnicastRequestReason.AddedToQueue, resourceId, queue);
                UnicastRequest response = SendUnicastRequest(unicastRequest, tcpRemoteEndPoint);
                if (response.Reason == UnicastRequestReason.IvalidRequest)
                {
                    Logger.WarnFormat("[TCP] Got invalid response: {0}.", response);
                }
            }
            queue.Add(tcpRemoteEndPoint.Address);
            RefreshResourceAccessQueue(resourceId, queue);
        }

        private void RemoveFromQueueIfExists(string resourceId, IPAddress remoteAddress)
        {
            if (!IsResourceLocking(resourceId))
            {
                return;
            }
            List<IPAddress> queue = GetWaitingQueue(resourceId);
            queue.Remove(remoteAddress);
            RefreshResourceAccessQueue(resourceId, queue);
        }

        private void CheckIfOwner(string resourceId)
        {
            if (IsResourceLocked(resourceId))
            {
                NotifyResourceAccessGranted(resourceId);
            }
        }

        private void NotifyResourceAccessGranted(string resourceId)
        {
            if (_callbacks.ContainsKey(resourceId))
            {
                _callbacks[resourceId]();
            }
        }

        public void RegisterCallbackOnResourceAccessGranted(string resourceId, Action callback)
        {
            if (_callbacks.ContainsKey(resourceId))
            {
                _callbacks[resourceId] += callback;
            }
            else
            {
                _callbacks.Add(resourceId, callback);
            }
        }

        public bool TryGetAccess(string resourceId)
        {
            if (IsResourceLocked(resourceId))
            {
                return true;
            }
            if (IsResourceLocking(resourceId))
            {
                return false;
            }
            return TryLockResource(resourceId);
        }

        private bool TryLockResource(string resourceId)
        {
            var accessRequest = new MulticastRequest(MulticastRequestReason.IsResourceLocked, resourceId);
            var requestHandledEvent = new ManualResetEvent(false);

            //create and register specific handler for this resource
            var resourceAddedToQueueHandler = new TcpMessageHandler<UnicastRequest>(HandleAddedToQueueRequest);
            var handlerWithEvent = new TcpMessageHandlerWithEvent<UnicastRequest>(resourceAddedToQueueHandler,
                requestHandledEvent);
            Predicate<UnicastRequest> byResourceFilter =
                r => r.ResourceIdentifier.Equals(resourceId) && r.Reason == UnicastRequestReason.AddedToQueue;
            _tcpClientHandler.RegisterHandler(handlerWithEvent, UdpTimeout, byResourceFilter);

            AddResourceAccessQueue(resourceId, new[] { AccessQueueTicket.Local.RemoteIp });
            SendMulticastRequest(accessRequest);
            bool handled = requestHandledEvent.WaitOne(UdpTimeout);
            if (handled) return false;
            return true;
        }

        private void HandleAddedToQueueRequest(UnicastRequest msg, IPEndPoint point, out UnicastRequest response)
        {
            if (msg.Reason != UnicastRequestReason.AddedToQueue)
            {
                throw new NotSupportedException();
            }
            string resourceId = msg.ResourceIdentifier;
            IPAddress[] waitingQueue = msg.WaitingQueue;
            AddMeToWaitingQueue(ref waitingQueue, point.Address);
            RefreshResourceAccessQueue(resourceId, waitingQueue);
            response = new UnicastRequest(UnicastRequestReason.Ok, resourceId);
        }

        private static void AddMeToWaitingQueue(ref IPAddress[] waitingQueue, IPAddress queueReceivedFrom)
        {
            int remoteLocalIndex = Array.IndexOf(waitingQueue, AccessQueueTicket.Local.RemoteIp);
            waitingQueue[remoteLocalIndex] = queueReceivedFrom;
            Array.Resize(ref waitingQueue, waitingQueue.Length + 1);
            waitingQueue[waitingQueue.Length - 1] = AccessQueueTicket.Local.RemoteIp;
        }

        public void ReleaseAccess(string resourceId)
        {
            if (!IsResourceLocked(resourceId))
            {
                throw new InvalidOperationException("Resource is not locked.");
            }
            RemoveFromQueueResource(resourceId);
        }

        public void LeaveQueue(string resourceId)
        {
            if (!IsResourceLocking(resourceId))
            {
                throw new InvalidOperationException("Resource is not locking.");
            }
            RemoveFromQueueResource(resourceId);
        }

        private void RemoveFromQueueResource(string resourceId)
        {
            List<IPAddress> waitingQueue = GetWaitingQueue(resourceId);
            RemoveAccessQueue(resourceId);
            _callbacks.Remove(resourceId);
            if (waitingQueue.Count == 1)
            {
                return;
            }
            NotifyLeavingQueue(resourceId);
        }

        private void NotifyLeavingQueue(string resourceId)
        {
            var multicastRequest = new MulticastRequest(MulticastRequestReason.LeavingQueue, resourceId);
            SendMulticastRequest(multicastRequest);
        }

        private void RemoveAccessQueue(string resourceId)
        {
            _resourceAccessQueue.Remove(resourceId);
        }

        private void AddResourceAccessQueue(string resourceId, IEnumerable<IPAddress> waitingQueue)
        {
            List<AccessQueueTicket> tickets = waitingQueue.Select(endPoint => new AccessQueueTicket {RemoteIp = endPoint})
                .ToList();
            _resourceAccessQueue.Add(resourceId, tickets);
        }

        private void RefreshResourceAccessQueue(string resourceId, IEnumerable<IPAddress> waitingQueue)
        {
            List<AccessQueueTicket> tickets = waitingQueue.Select(endPoint => new AccessQueueTicket {RemoteIp = endPoint})
                .ToList();
            _resourceAccessQueue.Remove(resourceId);
            _resourceAccessQueue.Add(resourceId, tickets);
        }

        private static void SendMulticastRequest(MulticastRequest multicastRequest)
        {
            var multicastSender = new UdpSender<MulticastRequest>(DatagramFormatter);
            multicastSender.Send(multicastRequest, MulticastAddress, UdpPort);
        }

        private static UnicastRequest SendUnicastRequest(UnicastRequest unicastRequest, IPEndPoint remoteEndPoint)
        {
            var unicastSender = new TcpSender<UnicastRequest>(TcpMsgFormatter);
            return unicastSender.Send(unicastRequest, remoteEndPoint);
        }

        private bool IsResourceLocked(string resourceId)
        {
            return GetLockedResources().Contains(resourceId);
        }

        private bool IsResourceLocking(string resourceId)
        {
            return GetLockingResourcesWithPositions().ContainsKey(resourceId);
        }

        private IEnumerable<string> GetLockedResources()
        {
            return GetLockingResourcesWithPositions().Where(pair => pair.Value == 0).Select(pair => pair.Key).ToList();
        }

        private IReadOnlyDictionary<string, int> GetLockingResourcesWithPositions()
        {
            return _resourceAccessQueue
                .Where(pair => pair.Value.Any(ticket => ticket.IsLocal()))
                .ToDictionary(pair => pair.Key, pair => pair.Value.IndexOf(AccessQueueTicket.Local));
        }

        private List<IPAddress> GetWaitingQueue(string resourceId)
        {
            return _resourceAccessQueue[resourceId].Select(ticket => ticket.RemoteIp).ToList();
        }

        private void OnStateChanged()
        {
            EventHandler handler = StateChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        #region IDisposable

        private readonly IDisposeGuard _disposeGuard = new DisposeGuard(typeof (ResourceAccessArbiter).Name);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ResourceAccessArbiter()
        {
            Dispose(false);
        }

        private void Dispose(Boolean disposing)
        {
            if (!_disposeGuard.CanDispose) return;
            if (disposing)
            {
                IEnumerable<string> lockingResources = GetLockingResourcesWithPositions().Keys;
                foreach (string lockingResource in lockingResources)
                {
                    LeaveQueue(lockingResource);
                }
                _tcpServer.Dispose();
                _multicastServer.Dispose();
            }
            _disposeGuard.SetDisposed();
        }

        #endregion IDisposable

        private struct AccessQueueTicket : IEquatable<AccessQueueTicket>
        {
            public static readonly AccessQueueTicket Local = new AccessQueueTicket {RemoteIp = new IPAddress(0)};

            public IPAddress RemoteIp { get; set; }

            public bool IsLocal()
            {
                return Equals(Local);
            }

            public bool Equals(AccessQueueTicket other)
            {
                return Equals(RemoteIp, other.RemoteIp);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is AccessQueueTicket && Equals((AccessQueueTicket) obj);
            }

            public override int GetHashCode()
            {
                return (RemoteIp != null ? RemoteIp.GetHashCode() : 0);
            }
        }
    }
}