using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace Lab4.Communication.Messages
{
    [DataContract(Name = "unicastRequest")]
    public sealed class UnicastRequest
    {
        [DataMember(Order = 0, Name = "requestReason")] private readonly UnicastRequestReason _reason;
        [DataMember(Order = 1, Name = "resource")] private readonly string _resourceIdentifier;
        [DataMember(Order = 2, Name = "queue")] private readonly IPAddress[] _waitingQueue;

        public UnicastRequest(UnicastRequestReason reason, string resourceIdentifier,
            IEnumerable<IPAddress> waitingQueue = null)
        {
            _reason = reason;
            _resourceIdentifier = resourceIdentifier;
            _waitingQueue = waitingQueue == null ? new IPAddress[0] : waitingQueue.ToArray();
        }

        public string ResourceIdentifier
        {
            get { return _resourceIdentifier; }
        }

        public IPAddress[] WaitingQueue
        {
            get { return _waitingQueue; }
        }

        public UnicastRequestReason Reason
        {
            get { return _reason; }
        }

        public override string ToString()
        {
            return string.Format("Reason - {0}, resource - {1}, queueCount - {2}",
                _reason, _resourceIdentifier, _waitingQueue.Length);
        }
    }
}