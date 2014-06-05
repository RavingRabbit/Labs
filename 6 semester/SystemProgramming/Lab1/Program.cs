using System;
using System.Threading;

namespace Lab1
{
    internal static class Program
    {
        private const Int32 ThreadCount = 10;

        public static void Main(String[] args)
        {
            TestMutex();
            Console.ReadKey();
            TestSemaphore();

            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }

        private static void TestMutex()
        {
            Console.WriteLine("Starting testing mutex.");
            using (var mt = new MutexTest(ThreadCount))
            {
                mt.Start();
                Console.ReadKey();
            }
            Console.WriteLine("Mutex testing finished.");
        }

        private static void TestSemaphore()
        {
            Console.WriteLine("Starting testing semaphore.");
            using (var st = new SemaphoreTest(ThreadCount, 3))
            {
                st.Start();
                Console.ReadKey();
            }
            Console.WriteLine("Semaphore testing finished.");
        }
    }
}
