using System;

namespace Lab5.Plugins
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginInfoAttribute : Attribute
    {
        public string Name { get; private set; }

        public PluginInfoAttribute(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            Name = name;
        }
    }
}
