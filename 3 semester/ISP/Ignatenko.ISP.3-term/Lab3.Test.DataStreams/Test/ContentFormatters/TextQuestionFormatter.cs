using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Test.Answer;
using Test.Question;

namespace Test.ContentFormatters
{
    public class TextQuestionFormatter<T> : TextFormatter<IQuestion<T>>
    {
        private readonly Stream _stream;
        private readonly TextFormatter<IAnswer<T>> _contentFormatter;

        public TextQuestionFormatter(Stream stream, TextFormatter<T> contentFormatter)
            : this(stream, new TextAnswerFormatter<T>(stream, contentFormatter))
        {
        }

        public TextQuestionFormatter(Stream stream, TextFormatter<IAnswer<T>> contentFormatter)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (contentFormatter == null)
                throw new ArgumentNullException("contentFormatter");
            _stream = stream;
            _contentFormatter = contentFormatter;
        }

        public override void Save(IQuestion<T> question)
        {
            using (var sw = new StreamWriter(_stream, Encoding.Default, BufferSize, true) {AutoFlush = true})
            {
                sw.WriteLine(question.Contents);
                sw.WriteLine(question.Answers.Count());
                foreach (var answer in question.Answers)
                {
                    _contentFormatter.Save(answer);
                }
            }
        }

        public override IQuestion<T> Load()
        {
            using (var sr = new StreamReader(_stream, Encoding.Default, true, BufferSize, true))
            {
                var position = _stream.Position;
                var contents = sr.ReadLine();
                if (contents == null)
                    throw new LoadingException();
                var question = new Question<T>(contents);
                var answersCountLine = sr.ReadLine();
                if (answersCountLine == null)
                    throw new LoadingException();
                var answersCount = int.Parse(answersCountLine);
                _stream.Position = position + sr.GetRealPosition();
                for (var i = 0; i < answersCount; i++)
                {
                    question.AddAnswer(_contentFormatter.Load());
                }
                return question;
            }
        }

        protected override void DisposeManagedResources()
        {
            _contentFormatter.Dispose();
        }

        protected override void DisposeUnmanagedResources()
        {
        }

        ~TextQuestionFormatter()
        {
            Dispose(false);
        }
    }
}