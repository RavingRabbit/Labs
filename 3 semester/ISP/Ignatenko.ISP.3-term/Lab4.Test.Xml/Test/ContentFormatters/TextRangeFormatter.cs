using System;
using System.IO;
using Test.Range;

namespace Test.ContentFormatters
{
    public class TextRangeFormatter<T> : TextFormatter<Range<T>> where T : IComparable<T>
    {
        private readonly TextFormatter<T> _contentFormatter;

        public TextRangeFormatter(TextFormatter<T> contentFormatter)
        {
            if (contentFormatter == null)
                throw new ArgumentNullException("contentFormatter");
            _contentFormatter = contentFormatter;
        }

        public override void Save(Range<T> data)
        {
            _contentFormatter.Save(data.LowerBound);
            _contentFormatter.Save(data.UpperBound);
        }

        public override Range<T> Load()
        {
            var lowerBound = _contentFormatter.Load();
            var upperBound = _contentFormatter.Load();
            return new Range<T>(lowerBound, upperBound);
        }

        protected override void DisposeManagedResources()
        {
            _contentFormatter.Dispose();
        }

        protected override void DisposeUnmanagedResources()
        {
        }

        ~TextRangeFormatter()
        {
            Dispose(false);
        }
    }
}