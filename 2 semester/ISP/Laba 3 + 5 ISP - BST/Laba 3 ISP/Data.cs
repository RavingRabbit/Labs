namespace Laba_3_ISP
{
    public class Data<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public Data(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return "Key = " + Key + ", value = " + Value;
        }
    }
}
