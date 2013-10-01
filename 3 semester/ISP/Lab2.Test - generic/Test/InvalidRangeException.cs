using System;

namespace Test
{
    public class InvalidRangeException : Exception
    {
        public InvalidRangeException()
        {
        }

        public InvalidRangeException(string message) : base(message)
        {
        }

        public InvalidRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}