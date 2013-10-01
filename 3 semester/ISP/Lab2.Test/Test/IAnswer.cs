using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IAnswer : IDisposable
    {
        string Contents { get; }

        bool Correct { get; }
    }
}
