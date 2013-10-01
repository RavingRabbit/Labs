using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.XmlConverters
{
    class StringToStringConverter : IStringConverter<string>
    {
        public string ConvertTo(string data)
        {
            return data;
        }

        public string ConvertFrom(string data)
        {
            return data;
        }
    }
}
