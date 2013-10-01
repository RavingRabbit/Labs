using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Serialization
{
    public interface ISerializer<T>
    {
        void Serialize(Stream stream, T data);

        T Deserialize(Stream stream);
    }
}
