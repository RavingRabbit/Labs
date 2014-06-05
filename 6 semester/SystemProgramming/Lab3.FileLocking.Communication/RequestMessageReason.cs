namespace Lab3.FileLocking.Communication
{
    public enum RequestMessageReason
    {
        FileAccessRequest,
        FileClosed,
        TakePlaceInQueueForAccess,
        RemoveFromQueueForAccess
    }
}