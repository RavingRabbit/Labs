using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    public class SemaphoreTest : ConcurrencyTest
    {
        private readonly Semaphore _semaphore;

        public SemaphoreTest(Int32 threadCount, Int32 maxConcurrentThreads) : base(threadCount)
        {
            if (threadCount <= 0)
                throw new ArgumentOutOfRangeException("threadCount");
            if (maxConcurrentThreads <= 0)
                throw new ArgumentOutOfRangeException("maxConcurrentThreads");

            _semaphore = new Semaphore(maxConcurrentThreads, maxConcurrentThreads);
        }

        protected override void WaitOne()
        {
            _semaphore.WaitOne();
        }

        protected override void Release()
        {
            _semaphore.Release();
        }

        protected override void Dispose(Boolean disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _semaphore.Dispose();
            }
        }

    }
}
