using System;

namespace Test.ContentFormatters
{
    public class InvalidSaveLoadFormatException : Exception
    {
        public InvalidSaveLoadFormatException()
        {
        }

        public InvalidSaveLoadFormatException(string message) : base(message)
        {
        }

        public InvalidSaveLoadFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}