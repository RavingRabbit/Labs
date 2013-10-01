using System;

namespace Test
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