namespace Test
{
    class StringQuestion : Question
    {
        public StringQuestion(string contents, ComplexityLevel level = ComplexityLevel.Normal) : base(contents, level)
        {
        }

        public StringQuestion(string contents, Range<int> maxSelectedAnswersRange, ComplexityLevel level = ComplexityLevel.Normal)
            : base(contents, maxSelectedAnswersRange, level)
        {
        }

        public new string Contents { get { return (string) ContentsAsObject; } }
    }
}
