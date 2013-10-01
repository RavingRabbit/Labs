using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Linq;
using Test.Answer;
using System.IO;
using Test.Question;
using Test.Serialization;
using Test.Range;
using Test.XmlConverters;

namespace Test
{
    internal class Program
    {
        private static void Main()
        {
            CreateForlderIfNotExists(ContentFormattersTesting.DefaultSaveFolderName);
            FileSystemWatcherTest.Test(ContentFormattersTesting.DefaultSaveFolderName);
            ContentFormattersTesting.Test();
            SerializingTesting.Test();
            TestLinqToXml();
            TestXmlReader();
            TestXmlDocument();
            Console.Read();
        }

        private static void TestLinqToXml()
        {
            using (var fileStream = File.OpenRead(Path.Combine("save", "test.xml")))
            {
                var xmlReader = XmlReader.Create(fileStream);
                var xTest = XDocument.Load(xmlReader);
                var elements =
                    xTest.Root.Element("questions").Elements("question").Elements((XNamespace) "question" + "contents");
                foreach (var xElement in elements)
                {
                    xElement.Value = "One more question.";
                }
                xTest.Save(Path.Combine("save", "test2.xml"));
            }
        }

        private static void TestXmlReader()
        {
            using (var fileStream = File.OpenRead(Path.Combine("save", "test.xml")))
            {
                using (var xmlTextReader = new XmlTextReader(fileStream))
                {
                    while (xmlTextReader.Read())
                    {
                        if (xmlTextReader.NodeType != XmlNodeType.Element) continue;
                        if (xmlTextReader.LocalName != "contents") continue;
                        xmlTextReader.MoveToFirstAttribute();
                        if (xmlTextReader.Value != "question") continue;
                        xmlTextReader.Read();
                        Console.WriteLine(xmlTextReader.Value);
                    }
                }
            }
        }

        private static void TestXmlDocument()
        {
            var xmlTest = new XmlDocument();
            xmlTest.Load(Path.Combine("save", "test2.xml"));
            xmlTest.GetElementsByTagName("description")[0].InnerText = "New description";
            xmlTest.Save(Path.Combine("save", "test2.xml"));
        }

        private static void CreateForlderIfNotExists(string folderName)
        {
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
        }

        public static Test<string> GetTest()
        {
            var test = new Test<string>("Test");

            var question =
                new Question<string>(
                    "В каком случае в одной области видимости можно объявить два делегата с одним именем?",
                    ComplexityLevel.Hard);
            question.AddAnswer(new Answer<string>("Если у делегатов различное количество параметров.", false));
            question.AddAnswer(new Answer<string>("Ни в каком.", true));
            var textAnswer = new Answer<string>("Если они хранят один и тот же метод.", false);
            question.AddAnswer(textAnswer);
            test.AddQuestion(question);

            question = new Question<string>("Какое утверждение об интерфейсах (Ин.) справедливо?", new Range<int>(2, 2),
                                            ComplexityLevel.Hard);
            question.AddAnswer(new Answer<string>("Ин. поддерживают множественное наследование.", true));
            question.AddAnswer(new Answer<string>("Ин. могут содержать поля.", false));
            question.AddAnswer(new Answer<string>("Ин. могут содержать конструкторы.", false));
            question.AddAnswer(new Answer<string>("Ин. могут содержать cвойства, методы, события", true));
            test.AddQuestion(question);

            question = new Question<string>("Ключевое слово sealed применимо к...", ComplexityLevel.Easy);
            question.AddAnswer(new Answer<string>("Полям.", false));
            question.AddAnswer(new Answer<string>("Интерфейсам.", false));
            question.AddAnswer(new Answer<string>("Методам.", true));
            test.AddQuestion(question);

            question = new Question<string>("Что является особенностью пользовательских структур?", ComplexityLevel.Easy);
            question.AddAnswer(new Answer<string>("Структуры не поддерживают наследование.", true));
            question.AddAnswer(new Answer<string>("Структура не может содержать событий.", false));
            test.AddQuestion(question);

            question =
                new Question<string>(
                    "Какое ключевое слово используется в производном классе для вызова конструктора класса-предка?",
                    ComplexityLevel.Easy);
            question.AddAnswer(new Answer<string>("class", false));
            question.AddAnswer(new Answer<string>("base", true));
            question.AddAnswer(new Answer<string>("this", false));
            test.AddQuestion(question);

            question =
                new Question<string>("В групповой делегат объединили 3 функции и произвели вызов. Что будет получено?");
            question.AddAnswer(new Answer<string>("Исключительная ситуация.", false));
            question.AddAnswer(new Answer<string>("Массив из трех значений.", false));
            question.AddAnswer(new Answer<string>("Значение последней функции в цепочке.", true));
            test.AddQuestion(question);

            return test;
        }
    }
}