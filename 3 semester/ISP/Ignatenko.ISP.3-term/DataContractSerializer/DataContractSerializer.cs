using System;
using System.IO;
using PluginInfoLib;

namespace Plugins
{
    [PluginInfo("DataContractSerializer", "BF corp", "", "1.0.0.0", "http://bf-corp.com/")]
    public class DataContractSerializer : ISerializer<IStudent>
    {
        private readonly System.Runtime.Serialization.DataContractSerializer _dcs =
            new System.Runtime.Serialization.DataContractSerializer(typeof(IStudent));

        public void Serialize(Stream stream, IStudent data)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (ReferenceEquals(data, null))
                throw new ArgumentNullException("data");
            _dcs.WriteObject(stream, data);
        }

        public IStudent Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            return (IStudent)_dcs.ReadObject(stream);
        }
    }
}
