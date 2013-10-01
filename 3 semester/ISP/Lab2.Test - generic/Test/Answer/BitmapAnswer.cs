using System.Drawing;

namespace Test.Answer
{
    public class BitmapAnswer : Answer<Bitmap>
    {
        public BitmapAnswer(Bitmap contents, bool isCorrect) : base(contents, isCorrect)
        {
        }
    }
}
