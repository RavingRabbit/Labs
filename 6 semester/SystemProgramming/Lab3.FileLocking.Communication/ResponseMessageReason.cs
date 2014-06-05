namespace Lab3.FileLocking.Communication
{
    public enum ResponseMessageReason
    {
        FileAccessRefused,
        FileAccessGranted,
        WaitForAccess,
        InvalidMessage,
        Ok
    }
}