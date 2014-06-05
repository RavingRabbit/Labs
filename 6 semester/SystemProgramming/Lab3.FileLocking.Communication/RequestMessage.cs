using System;
using ProtoBuf;
using RavingDev.Common;

namespace Lab3.FileLocking.Communication
{
    [ProtoContract]
    public sealed class RequestMessage
    {
        [ProtoMember(1)] private readonly String _filePath;
        [ProtoMember(2)] private readonly RequestMessageReason _reason;
        [ProtoMember(3)] private readonly ProcessInfo _senderProcessInfo;

        private RequestMessage(RequestMessageReason reason, String filePath)
            : this(reason, filePath, ProcessInfo.CurrentProcessInfo)
        {
        }

        private RequestMessage(RequestMessageReason reason, String filePath, ProcessInfo senderProcessInfo)
        {
            Requires.NotNull(filePath, "filePath");
            Requires.NotNull(senderProcessInfo, "senderProcessInfo");

            _reason = reason;
            _filePath = filePath;
            _senderProcessInfo = senderProcessInfo;
        }

        private RequestMessage()
        {
            //empty constructor for proto serializer only
        }

        public RequestMessageReason Reason
        {
            get { return _reason; }
        }

        public String FilePath
        {
            get { return _filePath; }
        }

        public ProcessInfo SenderProcessInfo
        {
            get { return _senderProcessInfo; }
        }

        public static RequestMessage CreateAccessRequest(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            return new RequestMessage(RequestMessageReason.FileAccessRequest, filePath);
        }


        public static RequestMessage CreateFileClosed(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            return new RequestMessage(RequestMessageReason.FileClosed, filePath);
        }

        public static RequestMessage CreateTakePlaceInQueueForAccess(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            return new RequestMessage(RequestMessageReason.TakePlaceInQueueForAccess, filePath);
        }

        public static RequestMessage CreateRemoveFromQueueForAccess(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            return new RequestMessage(RequestMessageReason.RemoveFromQueueForAccess, filePath);
        }

        public override Boolean Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is RequestMessage && Equals((RequestMessage) obj);
        }

        private Boolean Equals(RequestMessage other)
        {
            return _reason == other._reason && String.Equals(_filePath, other._filePath);
        }

        public override Int32 GetHashCode()
        {
            unchecked
            {
                return ((Int32) _reason*397) ^ (_filePath != null ? _filePath.GetHashCode() : 0);
            }
        }
    }
}