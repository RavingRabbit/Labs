namespace Test.Answer
{
    public class TextAnswer : Answer<string>
    {
        public TextAnswer(string contents, bool isCorrect) : base(contents, isCorrect)
        {
        }
    }
}
