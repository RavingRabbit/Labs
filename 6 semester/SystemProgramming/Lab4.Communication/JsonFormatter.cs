using System.IO;
using System.Runtime.Serialization.Json;

namespace Lab4.Communication
{
    public sealed class JsonFormatter
    {
        public void WriteMessage<T>(Stream stream, T message)
        {
            var serializer = new DataContractJsonSerializer(typeof (T));
            serializer.WriteObject(stream, message);
        }

        public T ReadMessage<T>(Stream stream)
        {
            var serializer = new DataContractJsonSerializer(typeof (T));
            return (T) serializer.ReadObject(stream);
        }

        public byte[] Serialize<T>(T message)
        {
            using (var memoryStream = new MemoryStream())
            {
                WriteMessage(memoryStream, message);
                return memoryStream.ToArray();
            }
        }

        public T Deserialize<T>(byte[] message)
        {
            using (var memoryStream = new MemoryStream(message))
            {
                return ReadMessage<T>(memoryStream);
            }
        }
    }
}