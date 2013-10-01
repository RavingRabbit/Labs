using System;
using System.IO;
using System.Linq;
using System.Text;
using Test.Answer;
using Test.Question;

namespace Test.ContentFormatters
{
    public class BinaryQuestionFormatter<T> : BinaryFormatter<IQuestion<T>>
    {
        private readonly Stream _stream;
        private readonly BinaryFormatter<IAnswer<T>> _contentFormatter;

        public BinaryQuestionFormatter(Stream stream, BinaryFormatter<T> contentFormatter)
            : this(stream, new BinaryAnswerFormatter<T>(stream, contentFormatter))
        {
        }

        public BinaryQuestionFormatter(Stream stream, BinaryFormatter<IAnswer<T>> contentFormatter)
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
            using (var bw = new BinaryWriter(_stream, Encoding.Default, true))
            {
                bw.Write(question.Contents);
                bw.Write(question.Answers.Count());
                foreach (var answer in question.Answers)
                {
                    _contentFormatter.Save(answer);
                }
            }
        }

        public override IQuestion<T> Load()
        {
            using (var br = new BinaryReader(_stream, Encoding.Default, true))
            {
                var contents = br.ReadString();
                var question = new Question<T>(contents);
                var answersCount = br.ReadInt32();
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

        ~BinaryQuestionFormatter()
        {
            Dispose(false);
        }
    }
}