using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test : IEnumerable<IQuestion>, IDisposable
    {
        #region Fields

        private readonly List<IQuestion> _questions = new List<IQuestion>();
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

        public Test(string description, IEnumerable<IQuestion> questions)
            : this(description)
        {
            if (questions == null)
                throw new ArgumentNullException("questions");
            _questions.AddRange(questions);
        }

        #endregion

        #region Properties

        public string Description { get { return _description; } }

        public int QuestionsCount
        {
            get { return _questions.Count; }
        }

        public double ComplitedInPercent
        {
            get { return 100.0 * CorrectlyAnsweredQuestions.Count() / QuestionsCount; }
        }

        public IQuestion[] Questions
        {
            get { return _questions.ToArray(); }
        }

        public IQuestion[] CorrectlyAnsweredQuestions
        {
            get { return _questions.Where(question => question.AnsweredCorrectly).ToArray(); }
        }

        #endregion

        #region Public Methods

        public void AddQuestion(IQuestion question)
        {
            if (question == null)
                throw new ArgumentNullException("question");
            _questions.Add(question);
        }

        public void AddQuestionsRange(IEnumerable<IQuestion> questions)
        {
            if (questions == null)
                throw new ArgumentNullException("questions");
            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }

        public bool RemoveQuestion(IQuestion question)
        {
            return _questions.Remove(question);
        }

        public bool ContainsQuestion(IQuestion question)
        {
            return _questions.Contains(question);
        }

        public IQuestion FindQuestion(Predicate<IQuestion> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            return _questions.Find(match);
        }

        public void ClearQuestions()
        {
            _questions.Clear();
        }

        public bool IsValid()
        {
            return Questions.All(question => question.IsValid());
        }

        public List<IQuestion> InvalidQuestions()
        {
            return _questions.Where(question => !question.IsValid()).ToList();
        }

        public IEnumerator<IQuestion> GetEnumerator()
        {
            return _questions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IQuestion this[int index]
        {
            get
            {
                return _questions[index];
            }
            set
            {
                _questions[index] = value;
            }
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
                // Dispose managed resources.
                // component.Dispose();
            }
            // Call the appropriate methods to clean up unmanaged resources here.
            // CloseHandle(handle);
            // handle = IntPtr.Zero;
            _disposed = true;
        }
    }
}