using System;
using System.Threading.Tasks;

namespace Lab3.FileLocking
{
    public interface IFileLocker
    {
        Task<Boolean> TryLockFileAsync(String filePath);

        Task UnlockFileAsync(String filePath);

        Task RegisterForAccessWaitingAsync(String filePath, Action callback);

        Task RemoveFromQueueForAccessAsync(String filePath);
    }
}