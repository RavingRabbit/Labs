using System;

namespace Test.Question
{
    public class AnswerSelectingException : Exception
    {
        public AnswerSelectingException()
        {
        }

        public AnswerSelectingException(string message) : base(message)
        {
        }

        public AnswerSelectingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}