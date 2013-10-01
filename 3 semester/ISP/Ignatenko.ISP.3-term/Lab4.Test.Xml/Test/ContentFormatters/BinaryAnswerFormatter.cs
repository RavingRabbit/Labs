using System;
using System.IO;
using System.Text;
using Test.Answer;

namespace Test.ContentFormatters
{
    public class BinaryAnswerFormatter<T> : BinaryFormatter<IAnswer<T>>
    {
        private readonly Stream _stream;
        private readonly BinaryFormatter<T> _contentFormatter;

        public BinaryAnswerFormatter(Stream stream, BinaryFormatter<T> contentFormatter)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (contentFormatter == null)
                throw new ArgumentNullException("contentFormatter");
            _stream = stream;
            _contentFormatter = contentFormatter;
        }

        public override void Save(IAnswer<T> data)
        {
            using (var bw = new BinaryWriter(_stream, Encoding.Default, true))
            {
                _contentFormatter.Save(data.Contents);
                bw.Write(data.Correct);
            }
        }

        public override IAnswer<T> Load()
        {
            using (var br = new BinaryReader(_stream, Encoding.Default, true))
            {
                var contents = _contentFormatter.Load();
                var correct = br.ReadBoolean();
                return new Answer<T>(contents, correct);
            }
        }

        protected override void DisposeManagedResources()
        {
            _contentFormatter.Dispose();
        }

        protected override void DisposeUnmanagedResources()
        {
        }

        ~BinaryAnswerFormatter()
        {
            Dispose(false);
        }
    }
}