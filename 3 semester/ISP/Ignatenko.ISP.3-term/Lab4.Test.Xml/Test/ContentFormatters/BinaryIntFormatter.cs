using System;
using System.IO;
using System.Text;

namespace Test.ContentFormatters
{
    public class BinaryIntFormatter : BinaryFormatter<int>
    {
        private readonly Stream _stream;

        public BinaryIntFormatter(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            _stream = stream;
        }

        public override void Save(int data)
        {
            using (var bw = new BinaryWriter(_stream, Encoding.Default, true))
            {
                bw.Write(data);
            }
        }

        public override int Load()
        {
            using (var br = new BinaryReader(_stream, Encoding.Default, true))
            {
                return br.ReadInt32();
            }
        }

        protected override void DisposeManagedResources()
        {
        }

        protected override void DisposeUnmanagedResources()
        {
        }

        ~BinaryIntFormatter()
        {
            Dispose(false);
        }
    }
}