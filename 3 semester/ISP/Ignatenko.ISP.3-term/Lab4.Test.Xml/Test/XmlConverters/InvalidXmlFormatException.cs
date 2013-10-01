using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.XmlConverters
{
    public class InvalidXmlFormatException : Exception
    {
        public InvalidXmlFormatException()
        {
        }

        public InvalidXmlFormatException(string message) : base(message)
        {
        }

        public InvalidXmlFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
