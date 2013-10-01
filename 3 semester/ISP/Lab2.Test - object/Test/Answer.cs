using System;

namespace Test
{
    public class Answer : IAnswer
    {
        #region Fields
        private readonly bool _correct;
        protected readonly object ContentsAsObject;
        private bool _disposed;

        #endregion

        #region Constructors

        public Answer(object contents, bool isCorrect)
        {
            if (ReferenceEquals(contents, null))
                throw new ArgumentNullException("contents");
            ContentsAsObject = contents;
            _correct = isCorrect;
        }

        #endregion

        #region Properties

        public object Contents
        {
            get { return ContentsAsObject; }
        }

        public bool Correct
        {
            get { return _correct; }
        }

        #endregion

        #region Public Methods

        public override int GetHashCode()
        {
            return (ContentsAsObject.GetHashCode()*397) ^ _correct.GetHashCode();
        }

        public override string ToString()
        {
            return ContentsAsObject.ToString();
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
                var contents = ContentsAsObject as IDisposable;
                if (contents != null)
                    contents.Dispose();
            }
            _disposed = true;
        }

        #endregion
    }
}