namespace Test
{
    class StringAnswer : Answer
    {
        public StringAnswer(string contents, bool isCorrect) : base(contents, isCorrect)
        {
        }

        public new string Contents { get { return (string)ContentsAsObject; } }
    }
}
