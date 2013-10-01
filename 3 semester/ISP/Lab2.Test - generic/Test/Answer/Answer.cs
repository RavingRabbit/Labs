using System;
using System.Linq;

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

        public Answer(T contents, bool isCorrect, IContentManager<T> contentManager = null)
        {
            if (ReferenceEquals(contents, null))
                throw new ArgumentNullException("contents");
            _contents = contents;
            _correct = isCorrect;
        }

        #endregion

        #region Properties

        //public IQuestion<T> Owner { get; internal set; }

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