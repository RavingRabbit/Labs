using System;

namespace Laba_4_ISP
{
    public class SortedSet : Set<string>
    {
        public SortedSet(params string[] elements):base(elements)
        {
            if (elements.Length != 0)
                GetList.Sort();
        }

        public override void Add(string value)
        {
            base.Add(value);
            if (Size < 2) return;
            if (String.CompareOrdinal(value, GetList.GetHead.Value) < 0)
                GetList.Sort();
        }
    }

}
