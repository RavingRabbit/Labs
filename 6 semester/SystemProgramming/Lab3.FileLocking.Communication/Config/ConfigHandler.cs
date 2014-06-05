using System;
using System.Configuration;

namespace Lab3.FileLocking.Communication.Config
{
    public sealed class ConfigHandler : ConfigurationSection
    {
        public static readonly String SectionName = "communication";

        [ConfigurationProperty(NameFor.Hostname, DefaultValue = "localhost")]
        public String Hostname
        {
            get { return (String) base[NameFor.Hostname]; }
        }

        [ConfigurationProperty(NameFor.Port, DefaultValue = 15645)]
        public Int32 Port
        {
            get { return (Int32) base[NameFor.Port]; }
        }

        private static class NameFor
        {
            public const String Hostname = "hostname";
            public const String Port = "port";
        }
    }
}