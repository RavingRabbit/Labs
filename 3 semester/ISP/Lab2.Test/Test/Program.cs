using System;
using System.Diagnostics;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main()
        {
            TestLINQtoObjects();
            Test();
            GetTest().Dispose();
            Console.Read();
        }

        static void TestLINQtoObjects()
        {
            var test = GetTest();

            /* В коллекции 6 вопросов: 3 с уровнем сложности Easy, 1 - Normal, 2 - Hard */

            /* Выполняем фильтрацию коллекции вопросов по уровню сложности Hard (должно быть 2 вопроса) */
            var hardQuestions = test.Where(question =>
                {
                    var question3 = question as Question;
                    return question3 != null && question3.ComplexityLevel == ComplexityLevel.Hard;
                });
            Debug.Assert(hardQuestions.All(question => ((Question)question).ComplexityLevel == ComplexityLevel.Hard));
            /* Выполняем проекцию коллекции вопросов: получаем тексты вопросов */
            var texts = test.Select(question => question.Contents);
            Debug.Assert(texts.Count() == 6);

            /* Выполняем группировку элементов коллекции вопросов по уровню сложности */
            var groups = test.GroupBy(question => ((Question)question).ComplexityLevel).ToArray();
            Debug.Assert(groups.Count() == 3); // должны получить 3 группы вопросов: Easy, Normal, Hard
            var normalQuestions = groups.First(grouping => grouping.Key == ComplexityLevel.Normal); // находим группу Normal вопросов
            var normalQuestion = test.First(question => ((Question)question).ComplexityLevel == ComplexityLevel.Normal); // есть только 1 вопрос Normal
            Debug.Assert(Equals(normalQuestions.First(), normalQuestion));

            /* Выполняем преобразования коллекции */
            var questions = test.ToArray();
            Debug.Assert(questions.SequenceEqual(test.Questions)); // последовательности должны быть одинаковыми

            /* Выполняем вычисления агрегатных функций */
            Debug.Assert(test.Count() == test.QuestionsCount);
            var newBigQuestion = test.Aggregate((question1, question2) =>
                {
                    var newQuestion = new Question(question1.Contents + " " + question2.Contents);
                    newQuestion.AddAnswersRange(question1.Answers);
                    newQuestion.AddAnswersRange(question2.Answers);
                    return newQuestion;
                });
            Console.WriteLine(newBigQuestion.Contents); // длинный текст вопроса
            Console.WriteLine(newBigQuestion.Answers.Count()); // 17 ответов
        }

        static Test GetTest()
        {
            var test = new Test("Test");

            var question =
                new Question("В каком случае в одной области видимости можно объявить два делегата с одним именем?",
                             ComplexityLevel.Hard);
            question.AddAnswer(new Answer("Если у делегатов различное количество параметров.", false));
            question.AddAnswer(new Answer("Ни в каком.", true));
            test.AddQuestion(question);

            question = new Question("Какое утверждение об интерфейсах (Ин.) справедливо?", new Range<int>(2, 2),
                                    ComplexityLevel.Hard);
            question.AddAnswer(new Answer("Ин. поддерживают множественное наследование.", true));
            question.AddAnswer(new Answer("Ин. могут содержать поля.", false));
            question.AddAnswer(new Answer("Ин. могут содержать конструкторы.", false));
            question.AddAnswer(new Answer("Ин. могут содержать cвойства, методы, события", true));
            test.AddQuestion(question);

            question = new Question("Ключевое слово sealed применимо к...", ComplexityLevel.Easy);
            question.AddAnswer(new Answer("Полям.", false));
            question.AddAnswer(new Answer("Интерфейсам.", false));
            question.AddAnswer(new Answer("Методам.", true));
            test.AddQuestion(question);

            question = new Question("Что является особенностью пользовательских структур?", ComplexityLevel.Easy);
            question.AddAnswer(new Answer("Структуры не поддерживают наследование.", true));
            question.AddAnswer(new Answer("Структура не может содержать событий.", false));
            test.AddQuestion(question);

            question =
                new Question(
                    "Какое ключевое слово используется в производном классе для вызова конструктора класса-предка?",
                    ComplexityLevel.Easy);
            question.AddAnswer(new Answer("class", false));
            question.AddAnswer(new Answer("base", true));
            question.AddAnswer(new Answer("this", false));
            test.AddQuestion(question);

            question = new Question("В групповой делегат объединили 3 функции и произвели вызов. Что будет получено?");
            question.AddAnswer(new Answer("Исключительная ситуация.", false));
            question.AddAnswer(new Answer("Массив из трех значений.", false));
            question.AddAnswer(new Answer("Значение последней функции в цепочке.", true));
            test.AddQuestion(question);

            return test;
        }

        static void Test()
        {
            var test = GetTest();
            /* вопросов должно быть 6 */
            Debug.Assert(test.QuestionsCount == 6);
            /* верно отвеченных должно быть 0 */
            Debug.Assert(test.CorrectlyAnsweredQuestions.Length == 0);
            var firstQuestion = test[0] as Question;
            Debug.Assert(firstQuestion != null, "firstQuestion != null");
            firstQuestion.SelectAnswer(firstQuestion.Answers[0]); //выбираем неверный ответ
            /* верно отвеченных должно быть 0 */
            Debug.Assert(test.CorrectlyAnsweredQuestions.Length == 0);
            firstQuestion.UnselectAllAnswers(); //снимаем выбор ответа
            firstQuestion.SelectAnswer(firstQuestion.Answers[1]); //выбраем верный ответ
            /* верно отвеченных должно быть 1 */
            Debug.Assert(test.CorrectlyAnsweredQuestions.Length == 1);
        }
    }
}
