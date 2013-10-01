using System;

namespace Test.Range
{
    public class RangeCreatingException : Exception
    {
        public RangeCreatingException()
        {
        }

        public RangeCreatingException(string message) : base(message)
        {
        }

        public RangeCreatingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}