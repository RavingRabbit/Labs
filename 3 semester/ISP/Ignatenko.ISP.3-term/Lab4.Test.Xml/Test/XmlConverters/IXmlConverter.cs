using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Test.XmlConverters
{
    public interface IXmlConverter<T> : IConverter<XElement, T>
    {
    }
}
