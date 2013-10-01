using System;
using System.IO;
using System.Text;

namespace Test.ContentFormatters
{
    public class BinaryStringFormatter : BinaryFormatter<string>
    {
        private readonly Stream _stream;

        public BinaryStringFormatter(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            _stream = stream;
        }

        public override void Save(string data)
        {
            using (var bw = new BinaryWriter(_stream, Encoding.Default, true))
            {
                bw.Write(data);
            }
        }

        public override string Load()
        {
            using (var br = new BinaryReader(_stream, Encoding.Default, true))
            {
                return br.ReadString();
            }
        }

        protected override void DisposeManagedResources()
        {
        }

        protected override void DisposeUnmanagedResources()
        {
        }

        ~BinaryStringFormatter()
        {
            Dispose(false);
        }
    }
}