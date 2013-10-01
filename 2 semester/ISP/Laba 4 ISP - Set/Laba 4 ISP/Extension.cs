using System;

namespace Laba_4_ISP
{
    public static class Extension
    {
        public static void Sort(this LinkedList<string> list)
        {
            var current = list.GetHead;
            while (current != null)
            {
                var item = current.Next;
                while (item != null)
                {
                    if (String.CompareOrdinal(item.Value, current.Value) < 0)
                    {
                        var value = item.Value;
                        item.Value = current.Value;
                        current.Value = value;
                    }
                    item = item.Next;
                }
                current = current.Next;
            }
        }
    }
}
