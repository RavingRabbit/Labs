using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test.Serialization
{
    public class XmlSerializer<T> : ISerializer<T> where T : new()
    {
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(T));

        public void Serialize(Stream stream, T data)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (ReferenceEquals(data, null))
                throw new ArgumentNullException("data");
            _xmlSerializer.Serialize(stream, data);
        }

        public T Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            return (T) _xmlSerializer.Deserialize(stream);
        }
    }
}
