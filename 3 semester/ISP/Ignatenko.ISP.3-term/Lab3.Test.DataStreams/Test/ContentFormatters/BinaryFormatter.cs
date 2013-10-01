using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ContentFormatters
{
    /// <summary>
    /// Сохраняет и загружает объекты в двоичном формате.
    /// </summary>
    public abstract class BinaryFormatter<T> : AbstractFormatter<T>
    {
        protected override SavingFormat GetSavingFormat()
        {
            return SavingFormat.Binary;
        }
    }
}