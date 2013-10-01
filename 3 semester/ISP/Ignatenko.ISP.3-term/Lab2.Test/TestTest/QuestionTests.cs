using System;
using System.Text;
using System.Collections.Generic;
using Ignatenko.Lab2.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTests
{
    [TestClass]
    public class QuestionTests
    {

        [TestMethod]
        public void TestConstructors()
        {
            var question = new Question("test");
            question = new Question("test", new Range<int>(2, 4));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorsWhenTextNull()
        {
           var question = new Question(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRangeException))]
        public void TestConstructorWhenInvalidRange()
        {
            var question = new Question("test", new Range<int>(-2, 6));
        }

        [TestMethod]
        public void TestProperties()
        {
            var question = new Question("question", new Range<int>(1, 1));
            var answer = new Answer("test1", true);
            question.AddAnswer(answer);
            Assert.AreSame(question.Text, "question");
            Assert.AreEqual(question.MaxSelectedAnswersRange, new Range<int>(1, 1));
            Assert.AreEqual(question.Answers.Length, 1);
            question.SelectAnswer(answer);
            Assert.AreEqual(question.AnswersSelected, 1);
            Assert.AreEqual(question.SelectedAnswers[0], answer);
            Assert.IsTrue(question.AnsweredCorrectly);
            answer = new Answer("new answer", true);
            question.AddAnswer(answer);
            Assert.IsTrue(question.AnsweredCorrectly);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingWhenNull()
        {
            var question = new Question("question", new Range<int>(1, 1));
            question.AddAnswer(null);
        }

        [TestMethod]
        public void TestAdding()
        {
            var question = new Question("question", new Range<int>(1, 1));
            var answer = new Answer("test", true);
            Assert.IsTrue(question.AddAnswer(answer));
            Assert.IsFalse(question.AddAnswer(answer));
        }

        [TestMethod]
        public void TestClearing()
        {
            var question = new Question("question");
            question.AddAnswer(new Answer("test", true));
            question.AddAnswer(new Answer("test2", false));
            Assert.AreEqual(question.Answers.Length, 2);
            question.ClearAnswers();
            Assert.AreEqual(question.Answers.Length, 0);

        }
    }
}
