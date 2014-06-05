using System;
using System.Configuration;

namespace Lab4.ResourceLocking.Config
{
    public sealed class ConfigHandler : ConfigurationSection
    {
        public static readonly String SectionName = "communication";

        [ConfigurationProperty(NameFor.MulticastAddress, DefaultValue = "224.5.6.7")]
        public String MulticastAddress
        {
            get { return (String) base[NameFor.MulticastAddress]; }
        }

        [ConfigurationProperty(NameFor.TcpPort, DefaultValue = 45684)]
        public Int32 TcpPort
        {
            get { return (Int32) base[NameFor.TcpPort]; }
        }

        [ConfigurationProperty(NameFor.UdpPort, DefaultValue = 13456)]
        public Int32 UdpPort
        {
            get { return (Int32) base[NameFor.UdpPort]; }
        }

        private static class NameFor
        {
            public const String MulticastAddress = "multicastAddress";
            public const String TcpPort = "tcpPort";
            public const String UdpPort = "udpPort";
        }
    }
}