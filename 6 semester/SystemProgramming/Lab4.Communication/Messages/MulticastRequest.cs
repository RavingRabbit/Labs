using System.Runtime.Serialization;

namespace Lab4.Communication.Messages
{
    [DataContract(Name = "multicastRequest")]
    public sealed class MulticastRequest
    {
        [DataMember(Order = 0, Name = "requestReason")] private readonly MulticastRequestReason _reason;
        [DataMember(Order = 1, Name = "resource")] private readonly string _resourceIdentifier;

        public MulticastRequest(MulticastRequestReason reason, string resourceIdentifier)
        {
            _reason = reason;
            _resourceIdentifier = resourceIdentifier;
        }

        public string ResourceIdentifier
        {
            get { return _resourceIdentifier; }
        }

        public MulticastRequestReason Reason
        {
            get { return _reason; }
        }

        public override string ToString()
        {
            return string.Format("Reason - {0}, resource - {1}",
                _reason, _resourceIdentifier);
        }
    }
}