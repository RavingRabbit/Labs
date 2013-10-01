using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Test.Question;

namespace Test
{
    [Serializable]
    [DataContract(Name = "test")]
    public class Test<TAContents> : IEnumerable<Question<TAContents>>, IDisposable
    {
        #region Fields

        [DataMember(Name = "questions")]
        private readonly List<Question<TAContents>> _questions = new List<Question<TAContents>>();
        [DataMember(Name = "description")]
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
            _questions.AddRange(questions.Cast<Question<TAContents>>());
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

        public Question<TAContents>[] Questions
        {
            get { return _questions.ToArray(); }
        }

        public Question<TAContents>[] CorrectlyAnsweredQuestions
        {
            get { return _questions.Where(question => question.AnsweredCorrectly).ToArray(); }
        }

        #endregion

        #region Public Methods

        public void AddQuestion(Question<TAContents> question)
        {
            if (question == null)
                throw new ArgumentNullException("question");
            _questions.Add(question);
        }

        public void AddQuestionsRange(IEnumerable<Question<TAContents>> questions)
        {
            if (questions == null)
                throw new ArgumentNullException("questions");
            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }

        public bool RemoveQuestion(Question<TAContents> question)
        {
            return _questions.Remove(question);
        }

        public bool ContainsQuestion(Question<TAContents> question)
        {
            return _questions.Contains(question);
        }

        public Question<TAContents> FindQuestion(Predicate<Question<TAContents>> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            return _questions.Find(match);
        }

        public void ClearQuestions()
        {
            _questions.Clear();
        }

        public IEnumerator<Question<TAContents>> GetEnumerator()
        {
            return _questions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Question<TAContents> this[int index]
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