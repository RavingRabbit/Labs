using System;

namespace Typing_Tutor
{
    [Serializable]
    public class TypingSpeed : IComparable<TypingSpeed>, IEquatable<TypingSpeed>
    {
        public override int GetHashCode()
        {
            return _symblesPerSecond.GetHashCode();
        }

        private readonly double _symblesPerSecond;

        public TypingSpeed(int textLength, TimeSpan elapsedTime)
        {
            _symblesPerSecond = textLength / (1.0 * elapsedTime.TotalSeconds);
        }

        public TypingSpeed(int symblesPerMinute)
        {
            if (symblesPerMinute <= 0)
                throw new ArgumentException("Symbles per minute must be greater then zero.");
            _symblesPerSecond = (double) symblesPerMinute/60;
        }

        public int SymblesPerMinute { get { return (int) (_symblesPerSecond*60); } }

        public int SymblesPerSecond { get { return (int) _symblesPerSecond; } }

        public int CompareTo(TypingSpeed other)
        {
            if (other == null)
                throw new ArgumentNullException("other");
            return SymblesPerMinute - other.SymblesPerSecond;
        }

        public static bool operator ==(TypingSpeed x, TypingSpeed y)
        {
            return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
        }

        public static bool operator !=(TypingSpeed x, TypingSpeed y)
        {
            return !(x == y);
        }

        public static bool operator >(TypingSpeed x, TypingSpeed y)
        {
            if (x == null)
                throw new ArgumentNullException("x");
            if (y == null)
                throw new ArgumentNullException("y");
            return x.SymblesPerMinute > y.SymblesPerMinute;
        }

        public static bool operator <(TypingSpeed x, TypingSpeed y)
        {
            if (x == null)
                throw new ArgumentNullException("x");
            if (y == null)
                throw new ArgumentNullException("y");
            return x.SymblesPerMinute < y.SymblesPerMinute;
        }

        public static bool operator >=(TypingSpeed x, TypingSpeed y)
        {
            if (x == null)
                throw new ArgumentNullException("x");
            if (y == null)
                throw new ArgumentNullException("y");
            return !(x < y);
        }

        public static bool operator <=(TypingSpeed x, TypingSpeed y)
        {
            if (x == null)
                throw new ArgumentNullException("x");
            if (y == null)
                throw new ArgumentNullException("y");
            return !(x > y);
        }

        public bool Equals(TypingSpeed other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return SymblesPerMinute == other.SymblesPerMinute;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TypingSpeed)obj);
        }

        public override string ToString()
        {
            return string.Format("{0} симв/мин", SymblesPerMinute);
        }
    }
}
