using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using Test.ContentFormatters;
using Test.Question;

namespace Test
{
    internal class ContentFormattersTesting
    {
        public const string DefaultSaveFolderName = "save";

        public static void Test()
        {
            TestLinqToObjects();
            TestBinarySavingAndLoading();
            TestBinaryGzipSavingAndLoading();
            TestBinaryCryptoGzipSavingAndLoading();
            TestTextSavingAndLoading();
        }

        public static void TestBinarySavingAndLoading()
        {
            var test = Program.GetTest();
            using (var fileStream = File.Create(Path.Combine(DefaultSaveFolderName, "SavedTest.bin")))
            {
                using (
                    var testFormatter = new BinaryTestFormatter<string>(fileStream,
                                                                        new BinaryStringFormatter(fileStream)))
                {
                    testFormatter.Save(test);
                }
            }
            using (var fileStream = File.OpenRead(Path.Combine(DefaultSaveFolderName, "SavedTest.bin")))
            {
                using (
                    var testFormatter = new BinaryTestFormatter<string>(fileStream,
                                                                        new BinaryStringFormatter(fileStream)))
                {
                    var loadedTest = testFormatter.Load();
                    Debug.Assert(loadedTest.Questions.SequenceEqual(test.Questions));
                }
            }
        }

        public static void TestBinaryGzipSavingAndLoading()
        {
            var test = Program.GetTest();
            using (Stream fileStream = File.Create(Path.Combine(DefaultSaveFolderName, "SavedTest.zip")))
            {
                using (var zippedFileStream = new GZipStream(fileStream, CompressionMode.Compress))
                {
                    using (var testFormatter = new BinaryTestFormatter<string>(zippedFileStream,
                                                                               new BinaryStringFormatter(
                                                                                   zippedFileStream))
                        )
                    {
                        testFormatter.Save(test);
                    }
                }
            }

            using (Stream fileStream = File.OpenRead(Path.Combine(DefaultSaveFolderName, "SavedTest.zip")))
            {
                using (var zippedFileStream = new GZipStream(fileStream, CompressionMode.Decompress))
                {
                    using (var testFormatter = new BinaryTestFormatter<string>(zippedFileStream,
                                                                               new BinaryStringFormatter(
                                                                                   zippedFileStream)))
                    {
                        var loadedTest = testFormatter.Load();
                        Debug.Assert(loadedTest.Questions.SequenceEqual(test.Questions));
                    }
                }
            }
        }

        public static void TestBinaryCryptoGzipSavingAndLoading()
        {
            var test = Program.GetTest();
            using (Stream fileStream = File.Create(Path.Combine(DefaultSaveFolderName, "SavedTest.cryzip")))
            {
                using (var cryptoStream = new CryptoStream(fileStream, new ToBase64Transform(), CryptoStreamMode.Write))
                {
                    using (var cryptoZippedFileStream = new GZipStream(cryptoStream, CompressionMode.Compress))
                    {
                        using (var testFormatter = new BinaryTestFormatter<string>(cryptoZippedFileStream,
                                                                                   new BinaryStringFormatter(
                                                                                       cryptoZippedFileStream)))
                        {
                            testFormatter.Save(test);
                        }
                    }
                }
            }

            using (Stream fileStream = File.OpenRead(Path.Combine(DefaultSaveFolderName, "SavedTest.cryzip")))
            {
                using (var cryptoStream = new CryptoStream(fileStream, new FromBase64Transform(), CryptoStreamMode.Read)
                    )
                {
                    using (var cryptoZippedFileStream = new GZipStream(cryptoStream, CompressionMode.Decompress))
                    {
                        using (var testFormatter = new BinaryTestFormatter<string>(cryptoZippedFileStream,
                                                                                   new BinaryStringFormatter(
                                                                                       cryptoZippedFileStream)))
                        {
                            var loadedTest = testFormatter.Load();
                            Debug.Assert(loadedTest.Questions.SequenceEqual(test.Questions));
                        }
                    }
                }
            }
        }

        public static void TestTextSavingAndLoading()
        {
            Test<string> test = Program.GetTest();
            using (
                FileStream fileStream =
                    File.OpenWrite(Path.Combine(DefaultSaveFolderName, "SavedTest.txt")))
            {
                using (
                    var testFormatter = new TextTestFormatter<string>(fileStream, new TextStringFormatter(fileStream)))
                {
                    testFormatter.Save(test);
                }
            }
            using (var fileStream = File.OpenRead(Path.Combine(DefaultSaveFolderName, "SavedTest.txt")))
            {
                using (
                    var testFormatter = new TextTestFormatter<string>(fileStream, new TextStringFormatter(fileStream)))
                {
                    var loadedTest = testFormatter.Load();
                    Debug.Assert(loadedTest.Questions.SequenceEqual(test.Questions));
                }
            }
        }

        public static void TestLinqToObjects()
        {
            Test<string> test = Program.GetTest();

            /* В коллекции 6 вопросов: 3 с уровнем сложности Easy, 1 - Normal, 2 - Hard */

            /* Выполняем фильтрацию коллекции вопросов по уровню сложности Hard (должно быть 2 вопроса) */
            IEnumerable<IQuestion<string>> hardQuestions =
                test.Where(question => question.ComplexityLevel == ComplexityLevel.Hard);
            Debug.Assert(
                hardQuestions.All(question => ((Question<string>) question).ComplexityLevel == ComplexityLevel.Hard));

            /* Выполняем проекцию коллекции вопросов: получаем тексты вопросов */
            IEnumerable<string> texts = test.Select(question => question.Contents);
            Debug.Assert(texts.Count() == 6);

            /* Выполняем группировку элементов коллекции вопросов по уровню сложности */
            IGrouping<ComplexityLevel, Question<string>>[] groups =
                test.GroupBy(question => question.ComplexityLevel).ToArray();
            Debug.Assert(groups.Count() == 3); // должны получить 3 группы вопросов: Easy, Normal, Hard
            IGrouping<ComplexityLevel, IQuestion<string>> normalQuestions =
                groups.First(grouping => grouping.Key == ComplexityLevel.Normal); // находим группу Normal вопросов
            IQuestion<string> normalQuestion =
                test.First(question => question.ComplexityLevel == ComplexityLevel.Normal);
            // есть только 1 вопрос Normal
            Debug.Assert(Equals(normalQuestions.First(), normalQuestion));

            /* Выполняем преобразования коллекции */
            Question<string>[] questions = test.ToArray();
            Debug.Assert(questions.SequenceEqual(test.Questions)); // последовательности должны быть одинаковыми

            /* Выполняем вычисления агрегатных функций */
            Debug.Assert(test.Count() == test.QuestionsCount);
            IQuestion<string> newBigQuestion = test.Aggregate((question1, question2) =>
                                                                  {
                                                                      var newQuestion =
                                                                          new Question<string>(question1.Contents + " " +
                                                                                               question2.Contents);
                                                                      newQuestion.AddAnswersRange(question1.Answers);
                                                                      newQuestion.AddAnswersRange(question2.Answers);
                                                                      return newQuestion;
                                                                  });
            Debug.Assert(newBigQuestion.Answers.Any());
        }

        
    }
}