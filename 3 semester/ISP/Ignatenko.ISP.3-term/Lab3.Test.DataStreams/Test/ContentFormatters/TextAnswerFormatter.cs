using System;
using System.IO;
using System.Text;
using Test.Answer;

namespace Test.ContentFormatters
{
    public class TextAnswerFormatter<T> : TextFormatter<IAnswer<T>>
    {
        private readonly Stream _stream;
        private readonly TextFormatter<T> _contentFormatter;

        public TextAnswerFormatter(Stream stream, TextFormatter<T> contentFormatter)
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
            using (var sw = new StreamWriter(_stream, Encoding.Default, BufferSize, true) {AutoFlush = true})
            {
                sw.WriteLine(data.Correct);
                _contentFormatter.Save(data.Contents);
            }
        }

        public override IAnswer<T> Load()
        {
            using (var sr = new StreamReader(_stream, Encoding.Default, true, BufferSize, true))
            {
                var position = _stream.Position;
                var isCorrectLine = sr.ReadLine();
                if (isCorrectLine == null)
                    throw new LoadingException();
                var correct = bool.Parse(isCorrectLine);
                _stream.Position = position + sr.GetRealPosition();
                var contents = _contentFormatter.Load();
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

        ~TextAnswerFormatter()
        {
            Dispose(false);
        }
    }
}