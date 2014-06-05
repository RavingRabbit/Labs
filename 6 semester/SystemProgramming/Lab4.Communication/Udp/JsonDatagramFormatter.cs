using System.IO;
using System.Net.Sockets;
using RavingDev.Communication.Tcp;
using RavingDev.Communication.Udp;

namespace Lab4.Communication.Udp
{
    public sealed class JsonDatagramFormatter<T> : IDatagramFormatter<T>
    {
        public byte[] ToBytes(T datagram)
        {
            var jsonFormatter = new JsonFormatter();
            return jsonFormatter.Serialize(datagram);
        }

        public T FromBytes(byte[] datagram)
        {
            var jsonFormatter = new JsonFormatter();
            return jsonFormatter.Deserialize<T>(datagram);
        }
    }
}