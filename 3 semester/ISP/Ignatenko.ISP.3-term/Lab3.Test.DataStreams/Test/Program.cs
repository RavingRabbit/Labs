using System;
using System.IO;

namespace Test
{
    internal class Program
    {
        private static void Main()
        {
            const string forlderName = SaveLoadTesting.DefaultSaveFolderName;
            if (!Directory.Exists(forlderName))
                Directory.CreateDirectory(forlderName);
            FileSystemWatcherTest.Test(forlderName);
            SaveLoadTesting.Test();
            Console.Read();
        }
    }
}