using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ContentFormatters
{
    /// <summary>
    /// Сохраняет и загружает объекты в двоичном формате.
    /// </summary>
    public abstract class AbstractFormatter<T> : IContentFormatter<T>
    {
        private bool _disposed;

        public SavingFormat Format
        {
            get { return GetSavingFormat(); }
        }

        protected abstract SavingFormat GetSavingFormat();

        public abstract void Save(T data);

        public abstract T Load();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                DisposeManagedResources();
            }
            DisposeUnmanagedResources();
            _disposed = true;
        }

        protected abstract void DisposeManagedResources();

        protected abstract void DisposeUnmanagedResources();
    }
}