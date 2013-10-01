using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Test.Answer;
using Test.Range;

namespace Test.Question
{
    public class Question<T> : IQuestion<T>
    {
        #region Fields

        private readonly string _contents;
        private readonly Dictionary<IAnswer<T>, bool> _answers = new Dictionary<IAnswer<T>, bool>();
        private readonly Range<int> _maxSelectedAnswersRange;
        private readonly ComplexityLevel _complexityLevel;
        private bool _disposed;

        #endregion

        #region Constructors

        public Question(string contents, ComplexityLevel level = ComplexityLevel.Normal)
            : this(contents, new Range<int>(1, 1), level)
        {
        }

        public Question(string contents, Range<int> maxSelectedAnswersRange,
                        ComplexityLevel level = ComplexityLevel.Normal)
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

        public string Contents
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

        public IAnswer<T>[] Answers
        {
            get { return _answers.Select(pair => pair.Key).ToArray(); }
        }

        public IAnswer<T>[] SelectedAnswers
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

        public bool AddAnswer(IAnswer<T> answer)
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

        public void AddAnswersRange(IEnumerable<IAnswer<T>> answers)
        {
            if (answers == null)
                throw new ArgumentNullException("answers");
            foreach (var answer in answers)
            {
                AddAnswer(answer);
            }
        }

        public bool RemoveAnswer(IAnswer<T> answer)
        {
            if (answer == null)
                throw new ArgumentNullException("answer");
            return _answers.Remove(answer);
        }

        public bool ContainsAnswer(IAnswer<T> answer)
        {
            return _answers.Keys.ToList().Contains(answer);
        }

        public IAnswer<T> FindAnswer(Predicate<IAnswer<T>> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            return _answers.Keys.ToList().Find(match);
        }

        public void ClearAnswers()
        {
            _answers.Clear();
        }

        public void SelectAnswer(IAnswer<T> answer)
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

        public void UnselectAnswer(IAnswer<T> answer)
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


        public static bool operator ==(Question<T> x, Question<T> y)
        {
            return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
        }

        public static bool operator !=(Question<T> x, Question<T> y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Question<T>)) return false;
            return Equals((Question<T>) obj);
        }

        public bool Equals(IQuestion<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return Contents == other.Contents && Answers.SequenceEqual(other.Answers);
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

        public IEnumerator<IAnswer<T>> GetEnumerator()
        {
            return _answers.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return _contents;
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
            }
            _disposed = true;
        }

        #endregion
    }
}