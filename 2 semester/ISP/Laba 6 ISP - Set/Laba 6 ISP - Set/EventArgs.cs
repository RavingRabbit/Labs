using System;

namespace Laba_6_ISP___Set
{
    public class EventArgs<T> : EventArgs
    {
        public T EventInfo { get; private set; }

        public EventArgs(T eventInfo)
        {
            EventInfo = eventInfo;
        }

        public override string ToString()
        {
            return EventInfo.ToString();
        }
    }

}
