using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PluginInfoLib;

namespace Lab5.Plugins
{
    /// <summary>
    /// Code Project, Custom Configuration in .Net.
    /// 
    /// Paint .net Plugins SubSystem..
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Program
    {
        static void Main(string[] args)
        {
            var pluginManager = PluginManager<ISerializer<Student>>.GetInstance();
            Console.WriteLine("Plugins: ");
            foreach (var plugin in pluginManager.Plugins)
            {
                Console.WriteLine(plugin);
            }
            pluginManager.PluginAdded +=
                (sender, eventArgs) => Console.WriteLine("Plugin added: " + eventArgs.EventInfo);
            Console.WriteLine("Press any key... ");
            Console.ReadKey();
            var plugins = pluginManager.Plugins;
            for (var i = 0; i < plugins.Count; i++)
            {
                Console.WriteLine(string.Format("[{0}. {1}]", i, plugins[i]));
            }
            Console.WriteLine("Plugin number: ");
            var pluginNumber = Console.Read() - '0';
            var pluginObject = pluginManager.GetPluginObject(plugins[pluginNumber]);
            var student = new Student(45, "Adsf", "Bdsf");
            using (var file = File.Create("Student.dat"))
            {
                pluginObject.Serialize(file, student);
            }
        }
    }
}
