using System;

namespace Test
{
    public interface IAnswer : IDisposable
    {
        object Contents { get; }

        bool Correct { get; }
    }
}
