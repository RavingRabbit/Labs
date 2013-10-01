namespace Test.Question
{
    public class StringQuestion : Question<string, object>
    {
        public StringQuestion(string contents, ComplexityLevel level = ComplexityLevel.Normal) : base(contents, level)
        {
        }

        public StringQuestion(string contents, Range<int> maxSelectedAnswersRange, ComplexityLevel level = ComplexityLevel.Normal) : base(contents, maxSelectedAnswersRange, level)
        {
        }
    }
}
