using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test.Answer;

namespace Test.XmlConverters
{
    public class AnswerToXmlConverter<T> : IXmlConverter<IAnswer<T>>
    {
        private readonly IStringConverter<T> _stringConverter;

        public AnswerToXmlConverter(IStringConverter<T> stringConverter)
        {
            if (stringConverter == null)
                throw new ArgumentNullException();
            _stringConverter = stringConverter;
        }

        public XElement ConvertTo(IAnswer<T> data)
        {
            var contentsTypeAttribute = new XAttribute("contentsType", typeof(T).ToString());
            var xAnswerElement = new XElement("answer", contentsTypeAttribute);
            xAnswerElement.Add(new XElement((XNamespace)"answer" + "contents", _stringConverter.ConvertTo(data.Contents)));
            xAnswerElement.Add(new XElement("correct", data.Correct));
            return xAnswerElement;
        }

        public IAnswer<T> ConvertFrom(XElement dataAsXml)
        {
            if (!CanConvertFrom(dataAsXml))
                throw new InvalidXmlFormatException();
            var contents = _stringConverter.ConvertFrom(dataAsXml.Element((XNamespace)"answer" + "contents").Value);
            var correct = bool.Parse(dataAsXml.Element("correct").Value);
            return new Answer<T>(contents, correct);
        }

        public static bool CanConvertFrom(XElement dataAsXml)
        {
            if (dataAsXml == null)
                throw new ArgumentNullException("dataAsXml");
            var contentsTypeAttribute = dataAsXml.Attribute("contentsType");
            if (contentsTypeAttribute == null)
                return false;
            if (contentsTypeAttribute.Value != typeof(T).ToString())
                return false;
            if (dataAsXml.Element((XNamespace)"answer" + "contents") == null)
                return false;
            if (dataAsXml.Element("correct") == null)
                return false;
            return true;
        }
    }
}
