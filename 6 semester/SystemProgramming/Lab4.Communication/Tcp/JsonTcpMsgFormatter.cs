using System.IO;
using System.Net.Sockets;
using RavingDev.Communication.Tcp;

namespace Lab4.Communication.Tcp
{
    public sealed class JsonTcpMsgFormatter<T> : ITcpMsgFormatter<T>
    {
        private readonly BytesTcpMsgFormatter _bytesTcpMsgFormatter;

        public JsonTcpMsgFormatter()
        {
            _bytesTcpMsgFormatter = new BytesTcpMsgFormatter();
        }

        public T ReadMsg(TcpClient tcpClient)
        {
            byte[] msgBytes = _bytesTcpMsgFormatter.ReadMsg(tcpClient);
            using (var memoryStream = new MemoryStream(msgBytes))
            {
                var jsonFormatter = new JsonFormatter();
                return jsonFormatter.ReadMessage<T>(memoryStream);
            }
        }

        public void WriteMsg(TcpClient tcpClient, T msg)
        {
            using (var memoryStream = new MemoryStream())
            {
                var jsonFormatter = new JsonFormatter();
                jsonFormatter.WriteMessage(memoryStream, msg);
                byte[] msgBytes = memoryStream.ToArray();
                _bytesTcpMsgFormatter.WriteMsg(tcpClient, msgBytes);
            }
        }
    }
}