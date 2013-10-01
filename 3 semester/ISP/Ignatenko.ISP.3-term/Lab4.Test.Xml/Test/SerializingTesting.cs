using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Test.Answer;
using Test.Serialization;
using Test.XmlConverters;

namespace Test
{
    public static class SerializingTesting
    {
        public static void Test()
        {
            TestXmlLoadingAndSaving();
            TestBinarySerializing();
            TestXmlSerializing();
            TestDataContractSerializing();
        }

        public static void TestXmlLoadingAndSaving()
        {
            var test = Program.GetTest();
            var testToXmlConverter = new TestToXmlConverter<string>(new StringToStringConverter());
            var xTest = new XDocument(testToXmlConverter.ConvertTo(test));
            using (var fileStream = File.Create(Path.Combine("save", "test.xml")))
            {
                using (var xmlWriter = XmlWriter.Create(fileStream, new XmlWriterSettings{Indent = true, IndentChars = "    "}))
                {
                    xTest.WriteTo(xmlWriter);
                }
            }
            var testFromXml = testToXmlConverter.ConvertFrom(xTest.Root);
            Debug.Assert(test.SequenceEqual(testFromXml));
        }

        public static void TestBinarySerializing()
        {
            var bs = new BinarySerializer<Test<string>>();
            using (var fileStream = File.Create(Path.Combine("save", "test.binx")))
            {
                bs.Serialize(fileStream, Program.GetTest());
            }
            using (var fileStream = File.OpenRead(Path.Combine("save", "test.binx")))
            {
                var test = bs.Deserialize(fileStream);
                Debug.Assert(test.SequenceEqual(Program.GetTest()));
            }
        }

        public static void TestXmlSerializing()
        {
            var answer = new Answer<string>("Ответ.", true);
            var xs = new XmlSerializer<Answer<string>>();
            using (var fileStream = File.Create(Path.Combine("save", "answer.xml")))
            {
                xs.Serialize(fileStream, answer);
            }
            using (var fileStream = File.OpenRead(Path.Combine("save", "answer.xml")))
            {
                var deserializedAnswer = xs.Deserialize(fileStream);
                Debug.Assert(deserializedAnswer.Contents == answer.Contents);
            }
        }

        public static void TestDataContractSerializing()
        {
            var dcs = new DataContractSerializer<Test<string>>();
            using (var fileStream = File.Create(Path.Combine("save", "test.dc")))
            {
                dcs.Serialize(fileStream, Program.GetTest());
            }
            using (var fileStream = File.OpenRead(Path.Combine("save", "test.dc")))
            {
                var test = dcs.Deserialize(fileStream);
                Debug.Assert(test.SequenceEqual(Program.GetTest()));
            }
        }
    }
}
