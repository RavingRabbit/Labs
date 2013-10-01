using System;

namespace Test.Answer
{
    public class Answer<T> : IAnswer<T>
    {
        #region Fields

        private readonly bool _correct;
        private readonly T _contents;
        private bool _disposed;

        #endregion

        #region Constructors

        public Answer(T contents, bool isCorrect)
        {
            if (ReferenceEquals(contents, null))
                throw new ArgumentNullException("contents");
            _contents = contents;
            _correct = isCorrect;
        }

        #endregion

        #region Properties

        public T Contents
        {
            get { return _contents; }
        }

        public bool Correct
        {
            get { return _correct; }
        }

        #endregion

        #region Public Methods

        public override int GetHashCode()
        {
            return (_contents.GetHashCode()*397) ^ _correct.GetHashCode();
        }

        public override string ToString()
        {
            return _contents.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Answer<T>)) return false;
            return Equals((Answer<T>) obj);
        }

        public bool Equals(IAnswer<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return Contents.Equals(other.Contents) && Correct == other.Correct;
        }

        ~Answer()
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
                var contents = _contents as IDisposable;
                if (contents != null)
                    contents.Dispose();
            }
            _disposed = true;
        }

        #endregion
    }
}