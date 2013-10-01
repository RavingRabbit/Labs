using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.XmlConverters
{
    public interface IConverter<T1, T2>
    {
        T1 ConvertTo(T2 data);

        T2 ConvertFrom(T1 data);
    }
}
