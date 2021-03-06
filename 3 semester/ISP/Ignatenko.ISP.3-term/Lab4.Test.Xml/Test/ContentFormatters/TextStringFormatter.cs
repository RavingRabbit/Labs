﻿using System;
using System.IO;
using System.Text;

namespace Test.ContentFormatters
{
    public class TextStringFormatter : TextFormatter<string>
    {
        private readonly Stream _stream;

        public TextStringFormatter(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            _stream = stream;
        }

        public override void Save(string data)
        {
            using (var sw = new StreamWriter(_stream, Encoding.Default, BufferSize, true) {AutoFlush = true})
            {
                sw.WriteLine(data);
            }
        }

        public override string Load()
        {
            using (var sr = new StreamReader(_stream, Encoding.Default, true, BufferSize, true))
            {
                var position = _stream.Position;
                var line = sr.ReadLine();
                if (line == null)
                    throw new LoadingException();
                _stream.Position = position + sr.GetRealPosition();
                return line;
            }
        }

        protected override void DisposeManagedResources()
        {
        }

        protected override void DisposeUnmanagedResources()
        {
        }

        ~TextStringFormatter()
        {
            Dispose(false);
        }
    }
}