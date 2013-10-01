using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typing_Tutor
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
