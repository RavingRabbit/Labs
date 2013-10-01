using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Test.Serialization
{
    public class BinarySerializer<T> : ISerializer<T>
    {
        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

        public void Serialize(Stream stream, T data)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (ReferenceEquals(data, null))
                throw new ArgumentNullException("data");
            _binaryFormatter.Serialize(stream, data);
        }

        public T Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            return (T) _binaryFormatter.Deserialize(stream);
        }
    }
}
