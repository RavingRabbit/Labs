using System;
using System.IO;
using System.Linq;

namespace Test
{
    internal static class FileSystemWatcherTest
    {
        private static readonly FileSystemWatcher Watcher = new FileSystemWatcher();
        private static bool _handlersSetted;

        public static void Test(string path)
        {
            Watcher.Path = path;
            SetHandlers();
            Watcher.EnableRaisingEvents = true;
            CopyAndRenameFile();
        }

        /// <summary>
        /// Назначаем обработчики событий
        /// </summary>
        private static void SetHandlers()
        {
            if (_handlersSetted) return;
            Watcher.Created += (sender, args) => Console.WriteLine("Был создан файл - " + args.Name);
            Watcher.Deleted += (sender, args) => Console.WriteLine("Был удалён файл - " + args.Name);
            Watcher.Changed += (sender, args) => Console.WriteLine("Файл был изменён - " + args.Name);
            _handlersSetted = true;
        }

        private static void CopyAndRenameFile()
        {
            var files = Directory.GetFiles(Watcher.Path);
            if (!files.Any()) return;
            try
            {
                var filePath = files[0];
                var newFilePath = filePath + "_new_file";
                File.Copy(filePath, newFilePath);
                File.Move(newFilePath, newFilePath + "_renamed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}