using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Lab3.FileLocking.Communication;
using RavingDev.Common;

namespace Lab3.FileLocking.Arbiter
{
    public sealed class FileAccessArbiter : IDisposable
    {
        private readonly Dictionary<String, Queue<Ticket>> _fileAccessQueue;
        private readonly Dictionary<String, Process> _lockedFiles;
        private readonly Server _server;

        public FileAccessArbiter()
        {
            _lockedFiles = new Dictionary<String, Process>();
            _fileAccessQueue = new Dictionary<String, Queue<Ticket>>();
            _server = new Server(HandleMessage);
            _server.Start();
        }

        internal Dictionary<String, Process> LockedFiles
        {
            get { return _lockedFiles; }
        }

        internal Dictionary<String, Process[]> FileAccessQueue
        {
            get
            {
                return _fileAccessQueue.ToDictionary(pair => pair.Key,
                    pair => pair.Value.Select(ticket => ticket.Process).ToArray());
            }
        }

        public event EventHandler StateChanged;

        private void OnStateChanged()
        {
            EventHandler handler = StateChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private ResponseMessage HandleMessage(RequestMessage message)
        {
            RequestMessageReason messageReason = message.Reason;
            string filePath = message.FilePath;
            Process process = message.SenderProcessInfo.GetProcess();
            if (process == null)
            {
                return ResponseMessage.CreateInvalid(filePath);
            }
            switch (messageReason)
            {
                case RequestMessageReason.FileAccessRequest:
                {
                    return TryGetAccess(filePath, process)
                        ? ResponseMessage.CreateAccessGranted(filePath)
                        : ResponseMessage.CreateAccessRefused(filePath);
                }
                case RequestMessageReason.FileClosed:
                {
                    return TryUnlockFile(filePath, process)
                        ? ResponseMessage.CreateOk(filePath)
                        : ResponseMessage.CreateInvalid(filePath);
                }
                case RequestMessageReason.TakePlaceInQueueForAccess:
                {
                    if (TryGetAccess(filePath, process))
                    {
                        return ResponseMessage.CreateAccessGranted(filePath);
                    }
                    string handleName = TakePlaceInQueueForAccess(filePath, process);
                    return ResponseMessage.CreateWaitForAccess(filePath, handleName);
                }
                case RequestMessageReason.RemoveFromQueueForAccess:
                {
                    return TryRemoveFromWaitingQueue(filePath, process)
                        ? ResponseMessage.CreateOk(filePath)
                        : ResponseMessage.CreateInvalid(filePath);
                }
                default:
                {
                    return ResponseMessage.CreateInvalid(filePath);
                }
            }
        }

        private Boolean IsFileLocked(String filePath)
        {
            return _lockedFiles.ContainsKey(filePath);
        }

        private Boolean TryGetAccess(String filePath, Process process)
        {
            if (!IsFileLocked(filePath))
            {
                LockFile(filePath, process);
                return true;
            }
            return false;
        }

        private void LockFile(String filePath, Process process)
        {
            process.EnableRaisingEvents = true;
            _lockedFiles.Add(filePath, process);
            process.Exited += OnProcessExited;
            OnStateChanged();
        }

        private void OnProcessExited(Object processObj, EventArgs eventArgs)
        {
            var process = (Process) processObj;
            List<string> lockedFilesByProcess =
                _lockedFiles.Where(pair => Equals(pair.Value, process)).Select(pair => pair.Key).ToList();
            foreach (string lockedFile in lockedFilesByProcess)
            {
                UnlockFile(lockedFile);
            }
        }

        private Boolean TryUnlockFile(String filePath, Process process)
        {
            if (!IsFileLocked(filePath))
            {
                return true;
            }
            Process lockingProcess = _lockedFiles[filePath];
            if (Equals(lockingProcess, process))
            {
                UnlockFile(filePath);
                return true;
            }
            return false;
        }

        private void UnlockFile(String filePath)
        {
            if (_lockedFiles.ContainsKey(filePath))
            {
                Process process = _lockedFiles[filePath];
                process.Exited -= OnProcessExited;
                process.Dispose();
                _lockedFiles.Remove(filePath);
            }
            TryNotifyWaitingProcess(filePath);
            OnStateChanged();
        }

        private void TryNotifyWaitingProcess(String filePath)
        {
            if (!_fileAccessQueue.ContainsKey(filePath)) return;
            Queue<Ticket> queue = _fileAccessQueue[filePath];
            Ticket ticket = null;
            while (queue.Count != 0)
            {
                ticket = queue.Dequeue();
                Process process = ticket.Process;
                process.Refresh();
                if (!process.HasExited)
                {
                    break;
                }
                process.Dispose();
                ticket.EventWaitHandle.Dispose();
            }
            if (ticket == null)
            {
                _fileAccessQueue.Remove(filePath);
                return;
            }
            NotifyProcessAccessGranted(ticket);
        }

        private String TakePlaceInQueueForAccess(String filePath, Process process)
        {
            Queue<Ticket> processQueue;
            if (_fileAccessQueue.ContainsKey(filePath))
            {
                processQueue = _fileAccessQueue[filePath];
            }
            else
            {
                processQueue = new Queue<Ticket>();
                _fileAccessQueue.Add(filePath, processQueue);
            }
            string waitHandleName = Guid.NewGuid().ToString();
            var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset, waitHandleName);
            var ticket = new Ticket {Process = process, EventWaitHandle = waitHandle};
            processQueue.Enqueue(ticket);
            process.EnableRaisingEvents = true;
            process.Exited += OnWaitingProcessExited;
            OnStateChanged();
            return waitHandleName;
        }

        private void OnWaitingProcessExited(Object processObj, EventArgs eventArgs)
        {
            var process = (Process) processObj;
            foreach (var pair in _fileAccessQueue)
            {
                TryRemoveFromWaitingQueue(pair.Key, process);
            }
        }

        private Boolean TryRemoveFromWaitingQueue(String fileName, Process process)
        {
            Queue<Ticket> accessQueue = _fileAccessQueue[fileName];
            Ticket ticket = accessQueue.FirstOrDefault(t => Equals(t.Process, process));
            if (ticket == null)
            {
                OnStateChanged();
                return false;
            }
            List<Ticket> queueCopy = accessQueue.ToList();
            queueCopy.Remove(ticket);
            ticket.Process.Dispose();
            ticket.EventWaitHandle.Dispose();
            accessQueue.Clear();
            foreach (Ticket ticket1 in queueCopy)
            {
                accessQueue.Enqueue(ticket1);
            }
            OnStateChanged();
            return true;
        }

        private void NotifyProcessAccessGranted(Ticket ticket)
        {
            ticket.EventWaitHandle.Set();
        }

        private Boolean Equals(Process x, Process y)
        {
            return x.Id == y.Id && x.StartTime == y.StartTime;
        }

        #region IDisposable

        private readonly IDisposeGuard _disposeGuard = new DisposeGuard(typeof (FileAccessArbiter).Name);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~FileAccessArbiter()
        {
            Dispose(false);
        }

        private void Dispose(Boolean disposing)
        {
            if (!_disposeGuard.CanDispose) return;
            if (disposing)
            {
                _server.Dispose();
            }
            _disposeGuard.SetDisposed();
        }

        #endregion IDisposable

        private sealed class Ticket
        {
            public Process Process { get; set; }

            public EventWaitHandle EventWaitHandle { get; set; }
        }
    }
}