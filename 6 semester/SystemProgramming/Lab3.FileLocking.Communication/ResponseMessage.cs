using System;
using ProtoBuf;
using RavingDev.Common;

namespace Lab3.FileLocking.Communication
{
    [ProtoContract]
    public sealed class ResponseMessage
    {
        [ProtoMember(1)] private readonly String _filePath;
        [ProtoMember(2)] private readonly ResponseMessageReason _reason;
        [ProtoMember(3)] private readonly String _waitForAccessHandleName;

        private ResponseMessage(ResponseMessageReason reason, String filePath, String waitForAccessHandleName = null)
        {
            Requires.NotNull(filePath, "filePath");

            _reason = reason;
            _filePath = filePath;
            _waitForAccessHandleName = waitForAccessHandleName;
        }

        private ResponseMessage()
        {
            //empty constructor for proto serializer only
        }

        public ResponseMessageReason Reason
        {
            get { return _reason; }
        }

        public String FilePath
        {
            get { return _filePath; }
        }

        public String WaitForAccessHandleName
        {
            get { return _waitForAccessHandleName; }
        }

        public static ResponseMessage CreateAccessGranted(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            return new ResponseMessage(ResponseMessageReason.FileAccessGranted, filePath);
        }

        public static ResponseMessage CreateAccessRefused(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            return new ResponseMessage(ResponseMessageReason.FileAccessRefused, filePath);
        }

        public static ResponseMessage CreateWaitForAccess(String filePath, String handleName)
        {
            Requires.NotNull(filePath, "filePath");

            return new ResponseMessage(ResponseMessageReason.WaitForAccess, filePath, handleName);
        }

        public static ResponseMessage CreateInvalid(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            return new ResponseMessage(ResponseMessageReason.InvalidMessage, filePath);
        }

        public static ResponseMessage CreateOk(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            return new ResponseMessage(ResponseMessageReason.Ok, filePath);
        }

        public override Boolean Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ResponseMessage && Equals((ResponseMessage) obj);
        }

        private Boolean Equals(ResponseMessage other)
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