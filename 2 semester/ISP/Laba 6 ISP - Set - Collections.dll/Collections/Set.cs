using System;
using System.Linq;

namespace Collections
{
    public class Set<T>
    {
        private readonly LinkedList<T> _list;

        public int Size { get; private set; }

        public Set(params T[] elements)
        {
            _list = new LinkedList<T>();
            Add(elements);
        }

        public void Add(params T[] elements)
        {
            foreach (var value in elements.Where(value => !Contains(value)))
            {
                _list.PushFront(value); //проверить есть ли уже во множестве
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
            return _list.Contains(obj => obj.Equals(value));
        }

        public bool IsSubset(Set<T> secondSet) //является ли this подмножеством seconSet
        {
            if (secondSet == null) throw new ArgumentNullException();
            return _list.All(secondSet.Contains);
        }

        /* Объединение множеств this и secondSet */
        public Set<T> Union(Set<T> secondSet)
        {
            if (secondSet == null) throw new ArgumentNullException();
            var newSet = new Set<T>();
            _list.Where(value => !secondSet.Contains(value)).ForEach(x => newSet.Add()); //берём this без secondSet
            newSet.Add(secondSet.ToArray()); //добавляем secondSet множеством
            return newSet;
        }

        /* Объединение множеств this и secondSet */
        public static Set<T> operator +(Set<T> x, Set<T> y)
        {
            return x.Union(y);
        }

        /* Пересечение множеств this и secondSet */
        public Set<T> Intersect(Set<T> secondSet)
        {
            if (secondSet == null) throw new ArgumentNullException();
            var newSet = new Set<T>();
            newSet.Add(_list.Where(secondSet.Contains).ToArray());
            return newSet;
        }

        /* Разность множеств this и secondSet */
        public Set<T> Difference(Set<T> secondSet)
        {
            if (secondSet == null) throw new ArgumentNullException();
            var newSet = new Set<T>();
            _list.Where(value => !secondSet.Contains(value)).ForEach(x => newSet.Add(x));
            return newSet;
        }

        /* Разность множеств this и secondSet */
        public static Set<T> operator -(Set<T> x, Set<T> y)
        {
            return x.Difference(y);
        }

        public virtual object Clone()
        {
            return new Set<T>(_list.ToArray());
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
