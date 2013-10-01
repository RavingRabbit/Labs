using System;
using Ignatenko.Lab2.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTests
{
    [TestClass]
    public class AnswerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorWhenTextNull()
        {
            var testAnswer = new Answer(null, true);
        }

        [TestMethod]
        public void TestProperties()
        {
            var testAnswer = new Answer("Test answer", true);
            Assert.AreSame("Test answer", testAnswer.Text);
            Assert.IsTrue(testAnswer.Correct);
        }

        [TestMethod]
        public void TestCompareOperatorsAndMethods()
        {
            var answer1 = new Answer("Test answer", true);
            var answer2 = new Answer("Test answer", true);
            var answer3 = new Answer("Other test answer", true);
            Assert.IsTrue(answer1 == answer1);
            Assert.IsTrue(answer1 == answer2);
            Assert.IsFalse(answer1 == answer3);
            Assert.IsFalse(answer1 == null);
            Assert.IsFalse(null == answer1);
            Assert.IsTrue(answer1 != answer3);
            Assert.IsFalse(answer1.Equals(new object()));
            Assert.IsTrue(answer1.Equals((object)answer2));
            Assert.IsTrue(answer1.GetHashCode() == answer2.GetHashCode());
        }

        [TestMethod]
        public void TestCloneMethod()
        {
            var testAnswer = new Answer("Test answer", true);
            Assert.IsTrue(testAnswer.Equals(testAnswer.Clone() as Answer));
        }
    }
}
