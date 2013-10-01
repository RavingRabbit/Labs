namespace Laba_4_ISP
{
    public class LinkedListItem<T>
    {
        public LinkedListItem<T> Next { get; set; }

        public LinkedListItem<T> Prev { get; set; }

        public T Value { get; set; }
    }
}
