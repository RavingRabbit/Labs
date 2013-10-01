namespace Laba_3_ISP
{
    public class Node<TKey, TValue>
    {
        public Node<TKey, TValue> Left { get; set; }
        public Node<TKey, TValue> Right { get; set; }

        public Data<TKey,TValue> Data { get; set; }
    
        public Node(Data<TKey,TValue> data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

}
