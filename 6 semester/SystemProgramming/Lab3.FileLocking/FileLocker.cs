using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Lab3.FileLocking.Arbiter;
using Lab3.FileLocking.Communication;
using RavingDev.Common;

namespace Lab3.FileLocking
{
    public sealed class FileLocker : IFileLocker
    {
        private readonly Client _client;
        private readonly String _arbiterAppName;

        public FileLocker(String arbiterAppName)
        {
            Requires.NotNull(arbiterAppName, "arbiterAppName");

            _arbiterAppName = arbiterAppName;
            _client = new Client();
        }

        private void StartArbiterIfNotStarted()
        {
            if (!SingleArbiterAppHelper.IsApplicationStarted())
            {
                Process.Start(_arbiterAppName);
                SingleArbiterAppHelper.WaitForAppStarting();
            }
        }

        public async Task<Boolean> TryLockFileAsync(String filePath)
        {
            StartArbiterIfNotStarted();
            ResponseMessage response = await _client.SendMessageAsync(RequestMessage.CreateAccessRequest(filePath));
            if (response.Reason == ResponseMessageReason.FileAccessGranted)
            {
                return true;
            }
            if (response.Reason == ResponseMessageReason.FileAccessRefused)
            {
                return false;
            }
            throw new InvalidOperationException();
        }

        public async Task UnlockFileAsync(String filePath)
        {
            StartArbiterIfNotStarted();
            ResponseMessage response = await _client.SendMessageAsync(RequestMessage.CreateFileClosed(filePath));
            if (response.Reason == ResponseMessageReason.InvalidMessage)
            {
                throw new InvalidOperationException();
            }
        }

        public async Task RegisterForAccessWaitingAsync(String filePath, Action callback)
        {
            StartArbiterIfNotStarted();
            ResponseMessage response =
                await _client.SendMessageAsync(RequestMessage.CreateTakePlaceInQueueForAccess(filePath));
            if (response.Reason == ResponseMessageReason.FileAccessGranted)
            {
                ThreadPool.QueueUserWorkItem(state => callback());
                return;
            }
            if (response.Reason == ResponseMessageReason.WaitForAccess)
            {
                string waiteHandleName = response.WaitForAccessHandleName;
                var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset, waiteHandleName);
                ThreadPool.RegisterWaitForSingleObject(waitHandle, (state, @out) => callback(), null,
                    Timeout.Infinite, true);
                //waitHandle.WaitOne();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public async Task RemoveFromQueueForAccessAsync(String filePath)
        {
            StartArbiterIfNotStarted();
            ResponseMessage response =
                await _client.SendMessageAsync(RequestMessage.CreateRemoveFromQueueForAccess(filePath));
            return;
        }
    }
}