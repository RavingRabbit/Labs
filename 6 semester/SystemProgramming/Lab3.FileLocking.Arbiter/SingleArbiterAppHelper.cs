using System;
using System.Threading;

namespace Lab3.FileLocking.Arbiter
{
    public static class SingleArbiterAppHelper
    {
        private const String SingleInstanceMutexName = "E7BC0EF0-3151-4FF5-B81D-DF3379DDAFE6";
        private const String ProcessStartedWaitHandleName = "66A93BF1-2BEF-4100-A87F-401972EC485C";
        private static Mutex _singleInstanceMutex;
        private static readonly EventWaitHandle ProcessStartedWaitHandle;

        static SingleArbiterAppHelper()
        {
            ProcessStartedWaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset,
                ProcessStartedWaitHandleName);
        }

        public static Boolean IsApplicationStarted()
        {
            Boolean createdNew;
            using (new Mutex(false, SingleInstanceMutexName, out createdNew))
            {
                return !createdNew;
            }
        }

        internal static void OnStart()
        {
            _singleInstanceMutex = new Mutex(false, SingleInstanceMutexName);
            ProcessStartedWaitHandle.Set();
        }

        internal static void OnExit()
        {
            if (_singleInstanceMutex != null)
            {
                _singleInstanceMutex.Dispose();
            }
            ProcessStartedWaitHandle.Reset();
            ProcessStartedWaitHandle.Dispose();
        }

        public static void WaitForAppStarting()
        {
            ProcessStartedWaitHandle.WaitOne();
        }
    }
}