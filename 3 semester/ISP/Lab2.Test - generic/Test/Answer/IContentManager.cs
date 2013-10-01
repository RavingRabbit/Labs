using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Test.Answer
{
    public interface IContentManager<out T>
    {
        void Save(Stream stream);

        T Load(Stream stream);
    }
}
