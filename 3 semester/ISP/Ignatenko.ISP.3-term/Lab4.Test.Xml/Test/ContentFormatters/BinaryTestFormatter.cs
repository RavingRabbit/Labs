using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Test.Question;

namespace Test.ContentFormatters
{
    public class BinaryTestFormatter<T> : BinaryFormatter<Test<T>>
    {
        private readonly Stream _stream;
        private readonly BinaryFormatter<IQuestion<T>> _contentFormatter;

        public BinaryTestFormatter(Stream stream, BinaryFormatter<T> contentFormatter)
            : this(
                stream, new BinaryQuestionFormatter<T>(stream, new BinaryAnswerFormatter<T>(stream, contentFormatter)))
        {
        }

        public BinaryTestFormatter(Stream stream, BinaryFormatter<IQuestion<T>> contentFormatter)
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
            using (var bw = new BinaryWriter(_stream, Encoding.Default, true))
            {
                bw.Write(test.Description);
                bw.Write(test.Questions.Count());
                foreach (var question in test.Questions)
                {
                    _contentFormatter.Save(question);
                }
            }
        }

        public override Test<T> Load()
        {
            using (var br = new BinaryReader(_stream, Encoding.Default, true))
            {
                var description = br.ReadString();
                var answersCount = br.ReadInt32();
                var questions = new List<IQuestion<T>>();
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

        ~BinaryTestFormatter()
        {
            Dispose(false);
        }
    }
}