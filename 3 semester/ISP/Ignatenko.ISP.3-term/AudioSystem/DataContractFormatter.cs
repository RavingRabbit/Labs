using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace AudioSystem
{
    public static class DataContractFormatter<T>
    {
        public static void Save(string fileName, T obj)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if ((object)obj == null)
                throw new ArgumentNullException("obj");
            using (var xmlWriter = XmlWriter.Create(fileName, GetXmlWriterSettings()))
            {
                Save(xmlWriter, obj);
            }
        }

        public static void Save(Stream stream, T obj)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if ((object)obj == null)
                throw new ArgumentNullException("obj");
            using (var xmlWriter = XmlWriter.Create(stream, GetXmlWriterSettings()))
            {
                Save(xmlWriter, obj);
            }
        }

        public static void Save(XmlWriter writer, T obj)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            if ((object)obj == null)
                throw new ArgumentNullException("obj");
            var dcs = new DataContractSerializer(typeof(T));
            dcs.WriteObject(writer, obj);
        }

        public static T Load(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            using (var xmlReader = XmlReader.Create(fileName))
            {
                return Load(xmlReader);
            }
        }

        public static T Load(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            using (var xmlReader = XmlReader.Create(stream))
            {
                return Load(xmlReader);
            }
        }

        public static T Load(XmlReader xmlReader)
        {
            if (xmlReader == null)
                throw new ArgumentNullException("xmlReader");
            var dcs = new DataContractSerializer(typeof(T));
            return (T)dcs.ReadObject(xmlReader);
        }

        private static XmlWriterSettings GetXmlWriterSettings()
        {
            return new XmlWriterSettings { Indent = true, IndentChars = "    " };
        }
    }
}
