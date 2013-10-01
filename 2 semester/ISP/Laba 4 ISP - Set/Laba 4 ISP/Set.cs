using System;
using System.Linq;

namespace Laba_4_ISP
{
    public class Set<T> : ICloneable
    {
        private readonly LinkedList<T> _list;

        public LinkedList<T> GetList { get { return _list; } }

        public int Size { get; protected set; }

        public Set(params T[] elements)
        {
            _list = new LinkedList<T>();
            if (elements.Length == 0) return;
            foreach (var value in elements)
                _list.PushBack(value);
            Size = elements.Length;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public bool Contains(T value)
        {
            return _list.Contains(obj => obj.Equals(value)); //TODO: доконца разобраться с лямбда-выражениями
        }

        public bool IsSubset(Set<T> secondSet) //является ли this подмножеством seconSet
        {
            return _list.All(secondSet.Contains);
        }

        // придётся переопределять GetHashCode
        /* public bool Equals(Set<T> secondSet) 
        {
            return IsSubset(secondSet) && secondSet.IsSubset(this);
        } */

        public virtual object Clone()
        {
            return new Set<T>(_list.ToArray());
        }

        public virtual void Add(T element)
        {
            if (Contains(element)) return;
            _list.PushFront(element);
            Size++;
        }

        /* Объединение множеств this и secondSet */
        public Set<T> Union(Set<T> secondSet) 
        {
            var newSet = new Set<T>();
            foreach (var value in ToArray().Where(value => !newSet.Contains(value)))
                newSet.Add(value);
            foreach (var value in secondSet.ToArray().Where(value => !newSet.Contains(value)))
                newSet.Add(value);
            return newSet;
        }
        
        /* Пересечение множеств this и secondSet */
        public Set<T> Intersection(Set<T> secondSet)
        {
            var newSet = new Set<T>();
            foreach (var value in _list.Where(secondSet.Contains).ToArray())
                newSet.Add(value);
            return newSet;
        }

        /* Разность множеств this и secondSet */
        public Set<T> Difference(Set<T> secondSet) 
        {
            var newSet = new Set<T>();
            foreach (var value in _list.Where(value => !secondSet.Contains(value)).ToArray())
                newSet.Add(value);
            return newSet;
        }

        public override string ToString()
        {
            return _list.ToString();
        }

        public LinkedList<T> ToLinkedList()
        {
            return _list;
        }

        public T[] ToArray()
        {
            return _list.ToArray();
        }
    }
}
