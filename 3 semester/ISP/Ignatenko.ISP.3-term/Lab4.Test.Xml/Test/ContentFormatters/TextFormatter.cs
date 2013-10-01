using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ContentFormatters
{
    /// <summary>
    /// Сохраняет и загружает объекты в тектовом формате.
    /// </summary>
    public abstract class TextFormatter<T> : AbstractFormatter<T>
    {
        protected override SavingFormat GetSavingFormat()
        {
            return SavingFormat.Text;
        }

        protected const int BufferSize = 0x400;
    }
}