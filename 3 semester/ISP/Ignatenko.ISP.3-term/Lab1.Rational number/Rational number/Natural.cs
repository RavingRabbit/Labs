using System;
using System.Globalization;

namespace RationalNumber
{
    class Natural : IComparable, IComparable<Natural>, IEquatable<Natural>
    {
        public override int GetHashCode()
        {
            return _number;
        }

        private readonly int _number;

        public static readonly Natural MaxValue = new Natural(int.MaxValue);
        public static readonly Natural MinValue = new Natural(1);

        public Natural(int number)
        {
            if (number < 1)
                throw new ArgumentException("Число, меньшее единицы, не может являтся натуральным.");
            _number = number;
        }

        public static implicit operator int(Natural value)
        {
            if (value == null)
                throw new ArgumentNullException();
            return value._number;
        }

        public static explicit operator Natural(int value)
        {
            return new Natural(value);
        }

        public int CompareTo(object value)
        {
            if (value == null)
                return 1;
            if (!(value is Natural))
                throw new ArgumentException("Параметр value не относится к типу Natural");
            value = value as Natural;
            return _number.CompareTo(value);
        }

        public int CompareTo(Natural value)
        {
            return value == null ? 1 : _number.CompareTo(value._number);
        }

        public bool Equals(Natural value)
        {
            return !ReferenceEquals(value, null) && _number == value._number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Natural)) return false;
            return Equals((Natural)obj);
        }

        public static bool operator ==(Natural x, Natural y)
        {
            return y != null && (x != null && x._number.Equals(y._number));
        }

        public static bool operator !=(Natural x, Natural y)
        {
            return !ReferenceEquals(x, null) && !(x.Equals(y));
        }

        public override string ToString()
        {
            return _number.ToString(CultureInfo.InvariantCulture);
        }
    }
}
