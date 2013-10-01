using System;
using System.Collections.Generic;
using Test.Answer;

namespace Test.Question
{
    public interface IQuestion<TAContents> : IEnumerable<IAnswer<TAContents>>, IDisposable
    {
        string Contents { get; }

        bool AnsweredCorrectly { get; }

        IAnswer<TAContents>[] SelectedAnswers { get; }

        IAnswer<TAContents>[] Answers { get; }

        bool AddAnswer(IAnswer<TAContents> answer);

        bool RemoveAnswer(IAnswer<TAContents> answer);

        bool ContainsAnswer(IAnswer<TAContents> answer);

        IAnswer<TAContents> FindAnswer(Predicate<IAnswer<TAContents>> match);

        void ClearAnswers();

        void SelectAnswer(IAnswer<TAContents> answer);
    }
}