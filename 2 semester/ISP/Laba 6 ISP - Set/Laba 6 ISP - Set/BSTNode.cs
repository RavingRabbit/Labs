namespace Laba_6_ISP___Set
{
    public class BSTNode<T>
    {
        public BSTNode<T> Left { get; set; }

        public BSTNode<T> Right { get; set; }

        public T Value { get; set; }

        public BSTNode(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

}
