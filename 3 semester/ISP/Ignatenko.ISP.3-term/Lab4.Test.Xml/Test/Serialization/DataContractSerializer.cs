using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace Test.Serialization
{
    public class DataContractSerializer<T> : ISerializer<T>
    {
        private readonly DataContractSerializer _dcs = new DataContractSerializer(typeof(T));

        public void Serialize(Stream stream, T data)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (ReferenceEquals(data, null))
                throw new ArgumentNullException("data");
            _dcs.WriteObject(stream, data);
        }

        public T Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            return (T)_dcs.ReadObject(stream);
        }
    }
}
