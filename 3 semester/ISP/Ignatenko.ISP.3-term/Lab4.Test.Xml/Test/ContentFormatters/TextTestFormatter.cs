using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Test.Question;

namespace Test.ContentFormatters
{
    public class TextTestFormatter<T> : TextFormatter<Test<T>>
    {
        private readonly Stream _stream;
        private readonly TextFormatter<IQuestion<T>> _contentFormatter;

        public TextTestFormatter(Stream stream, TextFormatter<T> contentFormatter)
            : this(stream, new TextQuestionFormatter<T>(stream, new TextAnswerFormatter<T>(stream, contentFormatter)))
        {
        }

        public TextTestFormatter(Stream stream, TextFormatter<IQuestion<T>> contentFormatter)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (contentFormatter == null)
                throw new ArgumentNullException("contentFormatter");
            _stream = stream;
            _contentFormatter = contentFormatter;
        }

        public override void Save(Test<T> test)
        {
            using (var sw = new StreamWriter(_stream, Encoding.Default, BufferSize, true) {AutoFlush = true})
            {
                sw.WriteLine(test.Description);
                sw.WriteLine(test.Questions.Count());
                foreach (var question in test.Questions)
                {
                    _contentFormatter.Save(question);
                }
            }
        }

        public override Test<T> Load()
        {
            using (var sr = new StreamReader(_stream, Encoding.Default, true, BufferSize, true))
            {
                var position = _stream.Position;
                var description = sr.ReadLine();
                if (description == null)
                    throw new LoadingException();
                var answersCountLine = sr.ReadLine();
                if (answersCountLine == null)
                    throw new LoadingException();
                var answersCount = int.Parse(answersCountLine);
                var questions = new List<IQuestion<T>>();
                _stream.Position = position + sr.GetRealPosition();
                for (var i = 0; i < answersCount; i++)
                {
                    questions.Add(_contentFormatter.Load());
                }
                return new Test<T>(description, questions);
            }
        }

        protected override void DisposeManagedResources()
        {
            _contentFormatter.Dispose();
        }

        protected override void DisposeUnmanagedResources()
        {
        }

        ~TextTestFormatter()
        {
            Dispose(false);
        }
    }
}