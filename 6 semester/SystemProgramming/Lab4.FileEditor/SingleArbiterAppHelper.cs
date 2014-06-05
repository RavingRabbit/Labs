using System;
using System.Threading;

namespace Lab4.FileEditor
{
    public static class SingleAppInstanceHelper
    {
        private const String SingleInstanceMutexName = "B4FC604A-8799-4454-826C-A42D0FF01638";
        private static Mutex _singleInstanceMutex;

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
        }

        internal static void OnExit()
        {
            if (_singleInstanceMutex != null)
            {
                _singleInstanceMutex.Dispose();
            }
        }
    }
}