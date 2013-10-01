using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Answer
{
    public interface IAnswer<out T> : IDisposable
    {
        T Contents { get; }

        bool Correct { get; }
    }
}
