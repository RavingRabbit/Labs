using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Test.Answer;

namespace Test.Question
{
    public class Question<TQContents, TAContents> : IQuestion<TQContents, TAContents>
    {
        #region Fields

        private readonly TQContents _contents;
        private readonly Dictionary<IAnswer<TAContents>, bool> _answers = new Dictionary<IAnswer<TAContents>, bool>();
        private readonly Range<int> _maxSelectedAnswersRange;
        private readonly ComplexityLevel _complexityLevel;
        private bool _disposed;

        #endregion

        #region Constructors

        public Question(TQContents contents, ComplexityLevel level = ComplexityLevel.Normal)
            : this(contents, new Range<int>(1, 1), level)
        {
        }

        public Question(TQContents contents, Range<int> maxSelectedAnswersRange, ComplexityLevel level = ComplexityLevel.Normal)
        {
            if (ReferenceEquals(contents, null))
                throw new ArgumentNullException("contents");
            if (maxSelectedAnswersRange.LowerBound < 1)
                throw new InvalidRangeException("Lower bound has to be greater than 0.");
            _contents = contents;
            _maxSelectedAnswersRange = maxSelectedAnswersRange;
            _complexityLevel = level;
        }

        #endregion

        #region Properties

        public TQContents Contents
        {
            get { return _contents; }
        }

        public Range<int> MaxSelectedAnswersRange
        {
            get { return _maxSelectedAnswersRange; }
        }

        public ComplexityLevel ComplexityLevel
        {
            get { return _complexityLevel; }
        }

        public int AnswersCount
        {
            get { return _answers.Count; }
        }

        public int AnswersSelected { get; private set; }

        public IAnswer<TAContents>[] Answers
        {
            get { return _answers.Select(pair => pair.Key).ToArray(); }
        }

        public IAnswer<TAContents>[] SelectedAnswers
        {
            get { return _answers.Where(pair => pair.Value).Select(pair => pair.Key).ToArray(); }
        }

        public bool AnsweredCorrectly
        {
            get
            {
                return _maxSelectedAnswersRange.Contains(AnswersSelected) &&
                       SelectedAnswers.All(answer => answer.Correct);
            }
        }

        #endregion

        #region Public Methods

        public bool AddAnswer(IAnswer<TAContents> answer)
        {
            if (answer == null)
                throw new ArgumentNullException("answer");
            if (!_answers.ContainsKey(answer))
            {
                _answers.Add(answer, false);
                return true;
            }
            return false;
        }

        public void AddAnswersRange(IEnumerable<IAnswer<TAContents>> answers)
        {
            if (answers == null)
                throw new ArgumentNullException("answers");
            foreach (var answer in answers)
            {
                AddAnswer(answer);
            }
        }

        public bool RemoveAnswer(IAnswer<TAContents> answer)
        {
            if (answer == null)
                throw new ArgumentNullException("answer");
            return _answers.Remove(answer);
        }

        public bool ContainsAnswer(IAnswer<TAContents> answer)
        {
            return _answers.Keys.ToList().Contains(answer);
        }

        public IAnswer<TAContents> FindAnswer(Predicate<IAnswer<TAContents>> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            return _answers.Keys.ToList().Find(match);
        }

        public void ClearAnswers()
        {
            _answers.Clear();
        }

        public void SelectAnswer(IAnswer<TAContents> answer)
        {
            if (AnswersSelected == _maxSelectedAnswersRange.UpperBound)
                throw new AnswerSelectingException("Too many answers selected.");
            if (answer == null)
                throw new ArgumentNullException("answer");
            if (!_answers.ContainsKey(answer))
                throw new ArgumentOutOfRangeException("answer");
            if (_answers[answer]) return;
            _answers[answer] = true;
            AnswersSelected++;
        }

        public void UnselectAnswer(IAnswer<TAContents> answer)
        {
            if (answer == null)
                throw new ArgumentNullException("answer");
            if (!_answers.ContainsKey(answer))
                throw new ArgumentOutOfRangeException("answer");
            if (!_answers[answer]) return;
            _answers[answer] = false;
            AnswersSelected--;
        }

        public void SelectAllAnswers()
        {
            foreach (var answer in _answers.Keys.ToArray())
            {
                _answers[answer] = true;
            }
            AnswersSelected = _answers.Count;
        }

        public void UnselectAllAnswers()
        {
            foreach (var answer in _answers.Keys.ToArray())
            {
                _answers[answer] = false;
            }
            AnswersSelected = 0;
        }


        public static bool operator ==(Question<TQContents, TAContents> x, Question<TQContents, TAContents> y)
        {
            return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
        }

        public static bool operator !=(Question<TQContents, TAContents> x, Question<TQContents, TAContents> y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Question<TQContents, TAContents>)) return false;
            return Equals((Question<TQContents, TAContents>)obj);
        }

        public bool Equals(IQuestion<TQContents, TAContents> other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return Contents.Equals(other.Contents) && Answers.SequenceEqual(other.Answers);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (!ReferenceEquals(_contents, null) ? _contents.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_answers != null ? _answers.GetHashCode() : 0);
                hashCode = (hashCode*397) ^
                           (_maxSelectedAnswersRange != null ? _maxSelectedAnswersRange.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ AnswersSelected;
                return hashCode;
            }
        }

        public IEnumerator<IAnswer<TAContents>> GetEnumerator()
        {
            return _answers.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return _contents.ToString();
        }

        ~Question()
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
                foreach (var answer in _answers.Keys)
                {
                    answer.Dispose();
                }
                // Dispose managed resources.
                // component.Dispose();
            }
            // Call the appropriate methods to clean up unmanaged resources here.
            // CloseHandle(handle);
            // handle = IntPtr.Zero;
            _disposed = true;
        }

        #endregion
    }
}