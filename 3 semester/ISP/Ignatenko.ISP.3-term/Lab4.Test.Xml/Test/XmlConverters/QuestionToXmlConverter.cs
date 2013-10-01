using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Test.Answer;
using Test.Question;

namespace Test.XmlConverters
{
    public class QuestionToXmlConverter<T> : IXmlConverter<IQuestion<T>>
    {
        private readonly IXmlConverter<IAnswer<T>> _answerToXmlConverter;

        public QuestionToXmlConverter(IStringConverter<T> stringConverter) :
            this(new AnswerToXmlConverter<T>(stringConverter))
        {
        }

        public QuestionToXmlConverter(IXmlConverter<IAnswer<T>> answerToXmlConverter)
        {
            if (answerToXmlConverter == null)
                throw new ArgumentNullException("answerToXmlConverter");
            _answerToXmlConverter = answerToXmlConverter;
        }

        public XElement ConvertTo(IQuestion<T> data)
        {
            var xQuestionElement = new XElement("question");
            xQuestionElement.Add(new XElement((XNamespace)"question" + "contents", data.Contents));
            var xAnswersElement = new XElement("answers");
            foreach (var answer in data.Answers)
            {
                xAnswersElement.Add(_answerToXmlConverter.ConvertTo(answer));
            }
            xQuestionElement.Add(xAnswersElement);
            return xQuestionElement;
        }

        public IQuestion<T> ConvertFrom(XElement dataAsXml)
        {
            if (!CanConvertFrom(dataAsXml))
                throw new InvalidXmlFormatException();
            var contents = dataAsXml.Element((XNamespace)"question" + "contents").Value;
            var answers = new List<IAnswer<T>>();
            foreach (var answerAsXml in dataAsXml.Element("answers").Elements("answer"))
            {
                answers.Add(_answerToXmlConverter.ConvertFrom(answerAsXml));
            }
            var question = new Question<T>(contents);
            question.AddAnswersRange(answers);
            return question;
        }

        public bool CanConvertFrom(XElement dataAsXml)
        {
            if (dataAsXml == null)
                throw new ArgumentNullException("dataAsXml");
            if (dataAsXml.Element((XNamespace)"question" + "contents") == null)
                return false;
            if (dataAsXml.Element("answers") == null)
                return false;
            return true;
        }
    }
}