using System;
using System.Linq;

namespace Laba_6_ISP___Set
{
    public class SortedSet<T> where T : IComparable
    {
        private readonly BST<T> _bst;

        public int Size { get; private set; }

        public SortedSet(params T[] elements)
        {
            _bst = new BST<T>();
            Add(elements);
        }

        public void Add(params T[] elements)
        {
            foreach (var value in elements.Where(value => !Contains(value)))
            {
                _bst.Insert(value);
                Size++;
                OnAdded(new EventArgs<T>(value));
            }
        }

        public event EventHandler<EventArgs<T>> Added;

        protected virtual void OnAdded(EventArgs<T> e)
        {
            if (Added != null) Added(this, e);
        }

        public bool Contains(T value)
        {
            return _bst.Contains(obj => obj.Equals(value));
        }

        public bool IsSubset(SortedSet<T> secondSet) //является ли this подмножеством seconSet
        {
            if (secondSet == null) throw new ArgumentNullException();
            return _bst.All(secondSet.Contains);
        }

        /* Объединение множеств this и secondSet */
        public SortedSet<T> Union(SortedSet<T> secondSet)
        {
            if (secondSet == null) throw new ArgumentNullException();
            var newSet = new SortedSet<T>();
            _bst.Where(value => !secondSet.Contains(value)).ForEach(x => newSet.Add(x)); //берём this без secondSet
            newSet.Add(secondSet.ToArray()); //добавляем secondSet множеством
            return newSet;
        }

        /* Объединение множеств this и secondSet */
        public static SortedSet<T> operator +(SortedSet<T> x, SortedSet<T> y)
        {
            return x.Union(y);
        }

        /* Пересечение множеств this и secondSet */
        public SortedSet<T> Intersect(SortedSet<T> secondSet)
        {
            if (secondSet == null) throw new ArgumentNullException();
            var newSet = new SortedSet<T>();
            _bst.Where(secondSet.Contains).ForEach(x => newSet.Add(x));
            return newSet;
        }

        /* Разность множеств this и secondSet */
        public SortedSet<T> Difference(SortedSet<T> secondSet)
        {
            if (secondSet == null) throw new ArgumentNullException();
            var newSet = new SortedSet<T>();
            _bst.Where(value => !secondSet.Contains(value)).ForEach(x => newSet.Add(x));
            return newSet;
        }

        /* Разность множеств this и secondSet */
        public static SortedSet<T> operator -(SortedSet<T> x, SortedSet<T> y)
        {
            return x.Difference(y);
        }

        public static implicit operator Set<T>(SortedSet<T> sortedSet)
        {
            return new Set<T>(sortedSet.ToArray());
        }

        public static explicit operator SortedSet<T>(Set<T> set)
        {
            return new SortedSet<T>(set.ToArray());
        }

        public virtual object Clone()
        {
            return new SortedSet<T>(_bst.ToArray());
        }

        public override string ToString()
        {
            return _bst.ToString();
        }

        public BST<T> ToLinkedList()
        {
            return _bst;
        }

        public T[] ToArray()
        {
            return _bst.ToArray();
        }
    }

}
