using System;

namespace Lab5.Plugins
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
