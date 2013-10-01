namespace Laba_6_ISP___Set
{
    public class LinkedListItem<T>
    {
        public LinkedListItem<T> Next { get; set; }

        public LinkedListItem<T> Prev { get; set; }

        public T Value { get; set; }

        public LinkedListItem(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
