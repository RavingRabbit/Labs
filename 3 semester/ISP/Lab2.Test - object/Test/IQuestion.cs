using System;
using System.Collections.Generic;

namespace Test
{
    public interface IQuestion : IEnumerable<IAnswer>, IDisposable
    {
        object Contents { get; }

        bool AnsweredCorrectly { get; }

        IAnswer[] SelectedAnswers { get; }

        IAnswer[] Answers { get; }

        bool AddAnswer(IAnswer answer);

        bool RemoveAnswer(IAnswer answer);

        bool ContainsAnswer(IAnswer answer);

        IAnswer FindAnswer(Predicate<IAnswer> match);

        bool IsValid();

        void ClearAnswers();

        void SelectAnswer(IAnswer answer);
    }
}
