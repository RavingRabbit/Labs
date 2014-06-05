using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using RavingDev.Common;

namespace Lab2.FileLocking.Model
{
    public sealed class FileLocker : IFileLocker
    {
        private static readonly ProcessInfo CurrentProcessInfo;

        static FileLocker()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Int32 processId = currentProcess.Id;
            String processName = currentProcess.ProcessName;
            Int64 startTimeTicks = currentProcess.StartTime.Ticks;
            CurrentProcessInfo = new ProcessInfo(processId, processName, startTimeTicks);
        }

        public void LockFile(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            if (IsFileLocked(filePath))
            {
                throw new InvalidOperationException("File is already locked.");
            }
            WriteLockFile(filePath);
        }

        public void UnlockFile(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            if (!IsFileLocked(filePath)) return;
            DeleteLockFile(filePath);
        }

        public Boolean IsFileLocked(String filePath)
        {
            Requires.NotNull(filePath, "filePath");

            if (!IsLockFileExists(filePath))
            {
                return false;
            }
            String lockFileContent = ReadLockFile(filePath);
            try
            {
                ProcessInfo processInfo = ProcessInfo.Parse(lockFileContent);
                if (IsProcessAlive(processInfo))
                {
                    return true;
                }
                DeleteLockFile(filePath); //delete outdated file
            }
            catch (FormatException)
            {
                DeleteLockFile(filePath); //delete corrupted file
            }
            return false;
        }

        public Boolean IsFileLockedByCurrentProcess(String filePath)
        {
            Requires.NotNull(filePath, "filePath");
            if (!IsFileLocked(filePath))
            {
                return false;
            }
            String lockFileContent = ReadLockFile(filePath);
            try
            {
                ProcessInfo processInfo = ProcessInfo.Parse(lockFileContent);
                if (processInfo.Equals(CurrentProcessInfo))
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                DeleteLockFile(filePath); //delete corrupted file
            }
            return false;
        }

        private Boolean IsProcessAlive(ProcessInfo processInfo)
        {
            Process[] processes = Process.GetProcessesByName(processInfo.ProcessName);
            return processes.Any(process => process.Id == processInfo.ProcessId &&
                                            process.StartTime.Ticks == processInfo.StartTimeTicks);
        }

        private String ReadLockFile(String lockingFilePath)
        {
            String lockFilePath = GenerateLockFilePath(lockingFilePath);

            return File.ReadAllText(lockFilePath);
        }

        private void WriteLockFile(String lockingFilePath)
        {
            String lockFilePath = GenerateLockFilePath(lockingFilePath);
            String lockFileContents = GetLockFileContents();

            File.WriteAllText(lockFilePath, lockFileContents);
            File.SetAttributes(lockFilePath, FileAttributes.ReadOnly | FileAttributes.Hidden);
        }

        private void DeleteLockFile(String lockingFilePath)
        {
            String lockFilePath = GenerateLockFilePath(lockingFilePath);

            File.SetAttributes(lockFilePath, FileAttributes.Normal);
            File.Delete(lockFilePath);
        }

        private Boolean IsLockFileExists(String lockingFilePath)
        {
            String lockFilePath = GenerateLockFilePath(lockingFilePath);

            return File.Exists(lockFilePath);
        }

        private String GenerateLockFilePath(String lockingFilePath)
        {
            String lockingFileName = Path.GetFileName(lockingFilePath);
            String lockingFileDirectory = Path.GetDirectoryName(lockingFilePath) ?? String.Empty;
            String lockFileName = GenerateLockFileName(lockingFileName);
            String lockFilePath = Path.Combine(lockingFileDirectory, lockFileName);
            return lockFilePath;
        }

        private String GenerateLockFileName(String lockingFileName)
        {
            return String.Format(".~lock.{0}##", lockingFileName);
        }

        private String GetLockFileContents()
        {
            return CurrentProcessInfo.ToString();
        }

        private sealed class ProcessInfo
        {
            private readonly Int32 _processId;
            private readonly String _processName;
            private readonly Int64 _startTimeTicks;

            public ProcessInfo(Int32 processId, String processName, Int64 startTimeTicks)
            {
                _processId = processId;
                _processName = processName;
                _startTimeTicks = startTimeTicks;
            }

            public Int32 ProcessId
            {
                get { return _processId; }
            }

            public String ProcessName
            {
                get { return _processName; }
            }
            
            public Int64 StartTimeTicks
            {
                get { return _startTimeTicks; }
            }

            public static ProcessInfo Parse(String s)
            {
                String[] lines = s.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length != 3)
                {
                    throw new FormatException("Invalid string format.");
                }
                Int32 processId;
                if (!Int32.TryParse(lines[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out processId))
                {
                    throw new FormatException("Invalid string format.");
                }
                String processName = lines[1];
                Int64 startTimeTicks;
                if (!Int64.TryParse(lines[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out startTimeTicks))
                {
                    throw new FormatException("Invalid string format.");
                }
                return new ProcessInfo(processId, processName, startTimeTicks);
            }

            public override String ToString()
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(ProcessId.ToString(CultureInfo.InvariantCulture));
                stringBuilder.AppendLine(ProcessName);
                stringBuilder.AppendLine(StartTimeTicks.ToString(CultureInfo.InvariantCulture));
                return stringBuilder.ToString();
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    Int32 hashCode = _processId;
                    hashCode = (hashCode * 397) ^ (_processName != null ? _processName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ _startTimeTicks.GetHashCode();
                    return hashCode;
                }
            }

            public override Boolean Equals(Object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj is ProcessInfo && Equals((ProcessInfo) obj);
            }

            private Boolean Equals(ProcessInfo other)
            {
                return _processId == other._processId && String.Equals(_processName, other._processName) &&
                       _startTimeTicks == other._startTimeTicks;
            }
        }
    }
}