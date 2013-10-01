using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PluginInfoLib;

namespace Plugins
{
    [PluginInfo("BinarySerializer", "BF corp", "", "1.0.0.0", "http://bf-corp.com/")]
    public class BinarySerializer : ISerializer<IStudent>
    {
        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

        public void Serialize(Stream stream, IStudent data)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (ReferenceEquals(data, null))
                throw new ArgumentNullException("data");
            _binaryFormatter.Serialize(stream, data);
        }

        public IStudent Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            return (IStudent)_binaryFormatter.Deserialize(stream);
        }
    }
}
