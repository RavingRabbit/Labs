using System;

namespace Test
{
    public class Answer : IAnswer
    {
        #region Fields
        private readonly bool _correct;
        private readonly string _contents;
        private bool _disposed;

        #endregion

        #region Constructors

        public Answer(string contents, bool isCorrect)
        {
            if (ReferenceEquals(contents, null))
                throw new ArgumentNullException("contents");
            _contents = contents;
            _correct = isCorrect;
        }

        #endregion

        #region Properties

        //public IQuestion<string> Owner { get; internal set; }

        public string Contents
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
            return _contents;
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