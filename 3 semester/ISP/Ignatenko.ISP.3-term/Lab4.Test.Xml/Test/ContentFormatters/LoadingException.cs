using System;

namespace Test.ContentFormatters
{
    public class LoadingException : Exception
    {
        public LoadingException()
        {
        }

        public LoadingException(string message) : base(message)
        {
        }

        public LoadingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}