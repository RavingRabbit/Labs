using System;
using System.Configuration;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using Lab3.FileLocking.Communication.Config;
using RavingDev.Common;

namespace Lab3.FileLocking.Communication
{
    public sealed class Server : IDisposable
    {
        private static readonly Int32 Port;
        private static readonly IPAddress IpAddress;

        private readonly CancellationTokenSource _listenerCancellationTokenSource;
        private readonly Thread _listenerThread;
        private readonly MessageFormatter _messageFormatter;
        private readonly Func<RequestMessage, ResponseMessage> _messageHandler;

        static Server()
        {
            var configuration = (ConfigHandler) ConfigurationManager.GetSection(ConfigHandler.SectionName);
            string hostname = configuration.Hostname;
            IpAddress = Dns.GetHostEntry(hostname).AddressList[0];
            Port = configuration.Port;
        }

        public Server(Func<RequestMessage, ResponseMessage> messageHandler)
        {
            Requires.NotNull(messageHandler, "messageHandler");

            _messageHandler = messageHandler;
            _listenerCancellationTokenSource = new CancellationTokenSource();
            _listenerThread = new Thread(ListenerLoop);
            _messageFormatter = new MessageFormatter();
        }

        public void Start()
        {
            _disposeGuard.ThrowIfDisposed();

            _listenerThread.Start(_listenerCancellationTokenSource.Token);
        }

        private void ListenerLoop(Object packedCancellationToken)
        {
            var cancellationToken = (CancellationToken) packedCancellationToken;
            var tcpListener = new TcpListener(IpAddress, Port);
            tcpListener.Start();
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Task<TcpClient> acceptClientTask = tcpListener.AcceptTcpClientAsync();
                    acceptClientTask.Wait(cancellationToken);
                    TcpClient tcpClient = acceptClientTask.Result;
                    NetworkStream stream = tcpClient.GetStream();
                    var message = _messageFormatter.ReadMessage<RequestMessage>(stream);
                    ResponseMessage responseMessage = _messageHandler(message);
                    _messageFormatter.WriteMessage(stream, responseMessage);
                }
            }
            catch (OperationCanceledException)
            {
                //do nothing
            }
            finally
            {
                tcpListener.Stop();
            }
        }

        #region IDisposable

        private readonly IDisposeGuard _disposeGuard = new DisposeGuard(typeof (Server).Name);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Server()
        {
            Dispose(false);
        }

        private void Dispose(Boolean disposing)
        {
            if (!_disposeGuard.CanDispose) return;
            if (disposing)
            {
                _listenerCancellationTokenSource.Cancel();
                _listenerThread.Join();
                _listenerCancellationTokenSource.Dispose();
            }
            _disposeGuard.SetDisposed();
        }

        #endregion IDisposable
    }
}