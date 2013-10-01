using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Test.Question;

namespace Test
{
    public class Test<TAContents> : IEnumerable<IQuestion<TAContents>>, IDisposable
    {
        #region Fields

        private readonly List<IQuestion<TAContents>> _questions = new List<IQuestion<TAContents>>();
        private readonly string _description;
        private bool _disposed;

        #endregion

        #region Constructors

        public Test(string description)
        {
            if (description == null)
                throw new ArgumentNullException("description");
            _description = description;
        }

        public Test(string description, IEnumerable<IQuestion<TAContents>> questions)
            : this(description)
        {
            if (questions == null)
                throw new ArgumentNullException("questions");
            _questions.AddRange(questions);
        }

        #endregion

        #region Properties

        public string Description
        {
            get { return _description; }
        }

        public int QuestionsCount
        {
            get { return _questions.Count; }
        }

        public double ComplitedInPercent
        {
            get { return 100.0*CorrectlyAnsweredQuestions.Count()/QuestionsCount; }
        }

        public IQuestion<TAContents>[] Questions
        {
            get { return _questions.ToArray(); }
        }

        public IQuestion<TAContents>[] CorrectlyAnsweredQuestions
        {
            get { return _questions.Where(question => question.AnsweredCorrectly).ToArray(); }
        }

        #endregion

        #region Public Methods

        public void AddQuestion(IQuestion<TAContents> question)
        {
            if (question == null)
                throw new ArgumentNullException("question");
            _questions.Add(question);
        }

        public void AddQuestionsRange(IEnumerable<IQuestion<TAContents>> questions)
        {
            if (questions == null)
                throw new ArgumentNullException("questions");
            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }

        public bool RemoveQuestion(IQuestion<TAContents> question)
        {
            return _questions.Remove(question);
        }

        public bool ContainsQuestion(IQuestion<TAContents> question)
        {
            return _questions.Contains(question);
        }

        public IQuestion<TAContents> FindQuestion(Predicate<IQuestion<TAContents>> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            return _questions.Find(match);
        }

        public void ClearQuestions()
        {
            _questions.Clear();
        }

        public IEnumerator<IQuestion<TAContents>> GetEnumerator()
        {
            return _questions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IQuestion<TAContents> this[int index]
        {
            get { return _questions[index]; }
            set { _questions[index] = value; }
        }

        #endregion

        ~Test()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                foreach (var question in Questions)
                {
                    question.Dispose();
                }
            }
            _disposed = true;
        }
    }
}