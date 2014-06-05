using System;
using System.IO;
using System.Threading.Tasks;
using ProtoBuf;

namespace Lab3.FileLocking.Communication
{
    internal sealed class MessageFormatter
    {
        public async Task WriteMessageAsync<T>(Stream stream, T message)
        {
            byte[] serializedMessage = Serialize(message);
            byte[] messageLengthBytes = BitConverter.GetBytes(serializedMessage.Length);
            await stream.WriteAsync(messageLengthBytes, 0, messageLengthBytes.Length);
            await stream.WriteAsync(serializedMessage, 0, serializedMessage.Length);
        }

        public void WriteMessage<T>(Stream stream, T message)
        {
            byte[] serializedMessage = Serialize(message);
            byte[] messageLengthBytes = BitConverter.GetBytes(serializedMessage.Length);
            stream.Write(messageLengthBytes, 0, messageLengthBytes.Length);
            stream.Write(serializedMessage, 0, serializedMessage.Length);
        }

        public async Task<T> ReadMessageAsync<T>(Stream stream)
        {
            var messageLengthBytes = new Byte[4];
            await stream.ReadAsync(messageLengthBytes, 0, messageLengthBytes.Length);
            int messageLength = BitConverter.ToInt32(messageLengthBytes, 0);
            var serializedMessage = new Byte[messageLength];
            await stream.ReadAsync(serializedMessage, 0, serializedMessage.Length);
            return Deserialize<T>(serializedMessage);
        }

        public T ReadMessage<T>(Stream stream)
        {
            var messageLengthBytes = new Byte[4];
            stream.Read(messageLengthBytes, 0, messageLengthBytes.Length);
            int messageLength = BitConverter.ToInt32(messageLengthBytes, 0);
            var serializedMessage = new Byte[messageLength];
            stream.Read(serializedMessage, 0, serializedMessage.Length);
            return Deserialize<T>(serializedMessage);
        }

        private Byte[] Serialize<T>(T message)
        {
            using (var memoryStream = new MemoryStream())
            {
                Serializer.Serialize(memoryStream, message);
                return memoryStream.ToArray();
            }
        }

        private static T Deserialize<T>(Byte[] serializedMessage)
        {
            using (var memoryStream = new MemoryStream(serializedMessage))
            {
                return Serializer.Deserialize<T>(memoryStream);
            }
        }
    }
}