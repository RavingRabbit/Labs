using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test.Question;

namespace Test.XmlConverters
{
    public class TestToXmlConverter<T> : IXmlConverter<Test<T>>
    {
        private readonly IXmlConverter<IQuestion<T>> _questionToXmlConverter;

        public TestToXmlConverter(IStringConverter<T> stringConverter) : 
            this(new QuestionToXmlConverter<T>(stringConverter))
        {
        } 

        public TestToXmlConverter(IXmlConverter<IQuestion<T>> questionToXmlConverter)
        {
            if (questionToXmlConverter == null)
                throw new ArgumentNullException("questionToXmlConverter");
            _questionToXmlConverter = questionToXmlConverter;
        }

        public XElement ConvertTo(Test<T> data)
        {
            var xTestElement = new XElement("test");
            xTestElement.Add(new XElement("description", data.Description));
            var xQuestionsElement = new XElement("questions");
            foreach (var question in data.Questions)
            {
                xQuestionsElement.Add(_questionToXmlConverter.ConvertTo(question));
            }
            xTestElement.Add(xQuestionsElement);
            return xTestElement;
        }

        public Test<T> ConvertFrom(XElement dataAsXml)
        {
            if (!CanConvertFrom(dataAsXml))
                throw new InvalidXmlFormatException();
            var description = dataAsXml.Element("description").Value;
            var questions = new List<IQuestion<T>>();
            foreach (var questionAsXml in dataAsXml.Element("questions").Elements("question"))
            {
                questions.Add(_questionToXmlConverter.ConvertFrom(questionAsXml));
            }
            return new Test<T>(description, questions);
        }

        public bool CanConvertFrom(XElement dataAsXml)
        {
            if (dataAsXml == null)
                throw new ArgumentNullException("dataAsXml");
            if (dataAsXml.Element("description") == null)
                return false;
            if (dataAsXml.Element("questions") == null)
                return false;
            return true;
        }
    }
}
