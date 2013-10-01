using System.Drawing;

namespace Test
{
    class BitmapAnswer : Answer
    {
        public BitmapAnswer(Bitmap contents, bool isCorrect) : base(contents, isCorrect)
        {
        }

        public new Bitmap Contents { get { return (Bitmap)ContentsAsObject; } }
    }
}
