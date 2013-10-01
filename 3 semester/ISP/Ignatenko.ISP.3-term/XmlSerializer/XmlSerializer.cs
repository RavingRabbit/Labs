using System;
using System.IO;
using PluginInfoLib;

namespace Plugins
{
    [PluginInfo("XmlSerializer", "BF corp", "", "1.0.0.0", "http://bf-corp.com/")]
    public class XmlSerializer : ISerializer<IStudent>
    {
        private readonly System.Xml.Serialization.XmlSerializer _xmlSerializer =
            new System.Xml.Serialization.XmlSerializer(typeof(IStudent));

        public void Serialize(Stream stream, IStudent data)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (ReferenceEquals(data, null))
                throw new ArgumentNullException("data");
            _xmlSerializer.Serialize(stream, data);
        }

        public IStudent Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            return (IStudent)_xmlSerializer.Deserialize(stream);
        }
    }
}
