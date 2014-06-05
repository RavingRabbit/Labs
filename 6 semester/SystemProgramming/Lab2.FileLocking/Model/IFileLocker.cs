using System;

namespace Lab2.FileLocking.Model
{
    public interface IFileLocker
    {
        void LockFile(String filePath);

        void UnlockFile(String filePath);

        Boolean IsFileLocked(String filePath);

        Boolean IsFileLockedByCurrentProcess(String filePath);
    }
}