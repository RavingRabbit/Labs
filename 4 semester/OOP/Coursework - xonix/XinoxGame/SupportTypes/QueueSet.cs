using System;
using System.Collections;
using System.Collections.Generic;

namespace SupportTypes
{
    public class QueueSet<T> : ICollection<T>
    {
        private readonly int _maximumSize;
        private readonly List<T> _queue = new List<T>();

        public QueueSet(int maximumSize)
        {
            if (maximumSize < 0)
                throw new ArgumentOutOfRangeException("maximumSize");
            this._maximumSize = maximumSize;
        }

        public int Count
        {
            get { return _queue.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            Enqueue(item);
        }

        public void Clear()
        {
            _queue.Clear();
        }

        public bool Contains(T item)
        {
            return _queue.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (T value in _queue)
            {
                if (arrayIndex >= array.Length) break;
                if (arrayIndex >= 0)
                {
                    array[arrayIndex] = value;
                }
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            if (Equals(item, Peek()))
            {
                Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        public T Dequeue()
        {
            if (_queue.Count > 0)
            {
                T value = _queue[0];
                _queue.RemoveAt(0);
                return value;
            }
            return default(T);
        }

        public T Peek()
        {
            if (_queue.Count > 0)
            {
                return _queue[0];
            }
            return default(T);
        }

        public void Enqueue(T item)
        {
            if (_queue.Contains(item))
            {
                _queue.Remove(item);
            }
            _queue.Add(item);
            while (_queue.Count > _maximumSize)
            {
                Dequeue();
            }
        }
    }
}