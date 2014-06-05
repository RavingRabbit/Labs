using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using RavingDev.Common;

namespace Lab1
{
    public abstract class ConcurrencyTest : IDisposable
    {
        private Int32 _threadsGotResource;

        private readonly List<Thread> _threads;
        private readonly CancellationTokenSource _cancellationTokenSource;

        protected ConcurrencyTest(Int32 threadCount)
        {
            if (threadCount <= 0)
                throw new ArgumentOutOfRangeException("threadCount");

            _threads = new List<Thread>(threadCount);
            _cancellationTokenSource = new CancellationTokenSource();
            for (int i = 0; i < threadCount; i++)
            {
                var thread = new Thread(ImitateWork) { Name = i.ToString(CultureInfo.InvariantCulture) };
                _threads.Add(thread);
            }
        }

        public void Start()
        {
            foreach (var thread in _threads)
            {
                thread.Start(_cancellationTokenSource.Token);
            }
        }

        private void ImitateWork(Object packedCancellationToken)
        {
            var cancellationToken = (CancellationToken) packedCancellationToken;
            while (!cancellationToken.IsCancellationRequested)
            {
                WaitOne();
                Interlocked.Increment(ref _threadsGotResource);
                Console.WriteLine("Thread {0} got resource.", Thread.CurrentThread.Name);
                Thread.Sleep(new Random().Next(300));
                Console.WriteLine("Threads got resource: {0}", _threadsGotResource);
                Console.WriteLine("Thread {0} released resource.", Thread.CurrentThread.Name);
                Interlocked.Decrement(ref _threadsGotResource);
                Release();
            }
        }

        protected abstract void WaitOne();

        protected abstract void Release();

        #region IDisposable

        private readonly IDisposeGuard _disposeGuard = new DisposeGuard(typeof(ConcurrencyTest).Name);

        protected RavingDev.Common.IDisposeGuard DisposeGuard
        {
            get { return _disposeGuard; }
        }
		
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ConcurrencyTest()
        {
            Dispose(false);
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!_disposeGuard.CanDispose) return;
            if (disposing)
            {
                _cancellationTokenSource.Cancel();
                foreach (var thread in _threads)
                {
                    thread.Join();
                }
                _cancellationTokenSource.Dispose();
                _threads.Clear();
            }
            _disposeGuard.SetDisposed();
        }

        #endregion IDisposable
    }
}
