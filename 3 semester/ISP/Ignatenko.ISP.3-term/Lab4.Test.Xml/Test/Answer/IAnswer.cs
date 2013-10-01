using System;

namespace Test.Answer
{
    public interface IAnswer<out T> : IDisposable
    {
        T Contents { get; }

        bool Correct { get; }
    }
}