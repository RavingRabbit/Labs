using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Test.Range
{
    /// <summary>
    /// Represents a range of items.
    /// </summary>
    /// <typeparam name="T">The range type.</typeparam>
    [Serializable]
    [DataContract(Name = "question")]
    public class Range<T> : IEquatable<Range<T>> where T : IComparable<T>
    {
        #region Fields

        [DataMember(Name = "lowerBound")]
        private readonly T _lowerBound;
        [DataMember(Name = "upperBound")]
        private readonly T _upperBound;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates the range.
        /// </summary>
        /// <param name="lowerBound">The lower bound of the range.</param>
        /// <param name="upperBound">The upper bound of the range.</param>
        public Range(T lowerBound, T upperBound)
        {
            if (ReferenceEquals(lowerBound, null) || ReferenceEquals(upperBound, null))
                throw new ArgumentNullException();
            if (upperBound.CompareTo(lowerBound) < 0)
                throw new RangeCreatingException("upperBound less then lowerBound.");
            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The start of the range.
        /// </summary>
        public T LowerBound
        {
            get { return _lowerBound; }
        }

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public T UpperBound
        {
            get { return _upperBound; }
        }

        #endregion

        #region Public Methods

        public bool Equals(Range<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return (other.UpperBound.CompareTo(UpperBound) == 0) && (other.LowerBound.CompareTo(LowerBound) == 0);
        }

        /// <summary>
        /// Indicates if the range contains <code>value</code>.
        /// </summary>
        /// <param name="value">The value to look for.</param>
        /// <returns>true if the range contains <code>value</code>, false otherwise.</returns>
        /// <exception cref="System.ArgumentNullException"><code>value</code> is null.</exception>
        public bool Contains(T value)
        {
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException("value");
            return ((LowerBound.CompareTo(value) <= 0) && (UpperBound.CompareTo(value) >= 0));
        }

        public static bool operator ==(Range<T> x, Range<T> y)
        {
            return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
        }

        /// <summary>
        /// Returns true if the ranges are intersected.
        /// </summary>
        /// <param name="x">Range.</param>
        /// <param name="y">Range.</param>
        /// <returns>True if the ranges are intersected.</returns>
        public static bool operator ^(Range<T> x, Range<T> y)
        {
            if (ReferenceEquals(x, null))
                throw new ArgumentNullException("x");
            if (ReferenceEquals(y, null))
                throw new ArgumentNullException("y");
            return x.Contains(y.LowerBound) || x.Contains(y.UpperBound) ||
                   y.Contains(x.LowerBound) || y.Contains(x.UpperBound);
        }

        public static bool operator !=(Range<T> x, Range<T> y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Range<T>)) return false;
            return Equals((Range<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(_lowerBound)*397) ^
                       EqualityComparer<T>.Default.GetHashCode(_upperBound);
            }
        }

        #endregion
    }
}