using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using PluginInfoLib;

namespace Lab5.Plugins
{
    class PluginManager<T> : IDisposable
    {
        private static PluginManager<T> _instance;
        private readonly string _pluginsDirectoryPath;
        private readonly string _pluginsNamespace;
        private readonly FileSystemWatcher _watcher;
        private readonly Dictionary<string, Type> _plugins;
        private bool _disposed;

        protected PluginManager()
        {
            _plugins = new Dictionary<string, Type>();
            _pluginsDirectoryPath = ConfigurationManager.AppSettings["pluginsDirectoryPath"];
            CreateForlderIfNotExists(_pluginsDirectoryPath);
            _pluginsNamespace = ConfigurationManager.AppSettings["pluginsNamespace"];
            ScanPluginsDirectory();
            _watcher = new FileSystemWatcher
                {
                    Path = _pluginsDirectoryPath,
                    EnableRaisingEvents = true
                };
            _watcher.Created += OnFileAdded;
        }

        public List<string> Plugins { get { return new List<string>(_plugins.Keys); } } 

        public static PluginManager<T> GetInstance()
        {
            return _instance ?? (_instance = new PluginManager<T>());
        }

        private void ScanPluginsDirectory()
        {
            var pluginsDirectoryInfo = new DirectoryInfo(_pluginsDirectoryPath);
            var files = pluginsDirectoryInfo.GetFiles("*.dll");
            foreach (var fileInfo in files)
            {
                AddPlugin(fileInfo.FullName, fileInfo.Name.Replace(".dll", string.Empty));
            }
        }

        private bool AddPlugin(string pluginFilePath, string pluginAssemblyName)
        {
            try
            {
                var assembly = Assembly.LoadFrom(pluginFilePath);
                var type = assembly.GetType(_pluginsNamespace + "." + pluginAssemblyName);
                var pluginName = type.GetCustomAttribute<PluginInfoAttribute>().DisplayName;
                var plugin = (T)Activator.CreateInstance(type); //тестируем возможность создания плагина
                _plugins.Add(pluginName, type);
                OnPluginAdded(new EventArgs<string>(pluginName));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void OnFileAdded(object sender, FileSystemEventArgs args)
        {
            if (!args.Name.EndsWith(".dll")) return;
            var assemblyName = args.Name.Remove(args.Name.Length - 4);
            AddPlugin(args.FullPath, assemblyName);
        }

        public T GetPluginObject(string pluginName)
        {
            if (_plugins.ContainsKey(pluginName))
                return (T) Activator.CreateInstance(_plugins[pluginName]);
            throw new ArgumentOutOfRangeException("pluginName");
        }

        public event EventHandler<EventArgs<string>> PluginAdded;

        protected virtual void OnPluginAdded(EventArgs<string> e)
        {
            var handler = PluginAdded;
            if (handler != null) handler(this, e);
        }
        

        private static void CreateForlderIfNotExists(string folderName)
        {
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _watcher.Dispose();
            }
            _disposed = true;
        }
    }
}