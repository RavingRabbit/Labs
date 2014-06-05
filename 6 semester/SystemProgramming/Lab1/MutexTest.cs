using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    public class MutexTest : ConcurrencyTest
    {
        private readonly Mutex _mutex;

        public MutexTest(Int32 threadCount) : base(threadCount)
        {
            if (threadCount <= 0)
                throw new ArgumentOutOfRangeException("threadCount");

            _mutex = new Mutex(false);
        }

        protected override void WaitOne()
        {
            _mutex.WaitOne();
        }

        protected override void Release()
        {
            _mutex.ReleaseMutex();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _mutex.Dispose();
            }
        }
    }
}
