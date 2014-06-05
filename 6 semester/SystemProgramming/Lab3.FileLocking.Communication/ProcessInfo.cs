using System;
using System.Diagnostics;
using System.Linq;
using ProtoBuf;

namespace Lab3.FileLocking.Communication
{
    [ProtoContract]
    public sealed class ProcessInfo
    {
        public static readonly ProcessInfo CurrentProcessInfo = Create(Process.GetCurrentProcess());

        [ProtoMember(1)] private readonly Int32 _processId;
        [ProtoMember(2)] private readonly String _processName;
        [ProtoMember(3)] private readonly Int64 _startTimeTicks;

        public ProcessInfo(Int32 processId, String processName, Int64 startTimeTicks)
        {
            _processId = processId;
            _processName = processName;
            _startTimeTicks = startTimeTicks;
        }

        private ProcessInfo()
        {
            //empty constructor for proto serializer only
        }

        public Int32 ProcessId
        {
            get { return _processId; }
        }

        public String ProcessName
        {
            get { return _processName; }
        }

        public Int64 StartTimeTicks
        {
            get { return _startTimeTicks; }
        }

        public static ProcessInfo Create(Process process)
        {
            Int32 processId = process.Id;
            String processName = process.ProcessName;
            Int64 startTimeTicks = process.StartTime.Ticks;
            return new ProcessInfo(processId, processName, startTimeTicks);
        }

        public Process GetProcess()
        {
            Process[] processes = Process.GetProcessesByName(_processName);
            return processes.SingleOrDefault(p => p.StartTime.Ticks.Equals(StartTimeTicks) && p.Id.Equals(ProcessId));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                Int32 hashCode = _processId;
                hashCode = (hashCode*397) ^ (_processName != null ? _processName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _startTimeTicks.GetHashCode();
                return hashCode;
            }
        }

        public override Boolean Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ProcessInfo && Equals((ProcessInfo) obj);
        }

        private Boolean Equals(ProcessInfo other)
        {
            return _processId == other._processId && String.Equals(_processName, other._processName) &&
                   _startTimeTicks == other._startTimeTicks;
        }
    }
}