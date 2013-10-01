using System;

namespace Laba_4_ISP
{
    public class LinkedList<T>
    {
        private LinkedListItem<T> _head;

        public LinkedListItem<T> GetHead { get { return _head; } } 

        private LinkedListItem<T> _teil;

        public int Count { get; private set; }

        public delegate bool Comparer(T x, T y);

        public LinkedList()
        {
            _head = null;
            _teil = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }

        public T PeekBack()
        {
            return !IsEmpty() ? _teil.Value : default(T);
        }

        public T PeekFront()
        {
            return !IsEmpty() ? _head.Value : default(T);
        }

        public void PushBack(T value)
        {
            if (IsEmpty())
            {
                PushIntoEmpty(value);
            }
            else
            {
                _teil.Next = new LinkedListItem<T> { Value = value, Prev = _teil };
                _teil = _teil.Next;
            }
            Count++;
        }

        public void PushFront(T value)
        {
            if (IsEmpty())
            {
                PushIntoEmpty(value);
            }
            else
            {
                _head.Prev = new LinkedListItem<T> { Value = value, Next = _head };
                _head = _head.Prev;
            }
            Count++;
        }

        public void PushIntoEmpty(T value)
        {
            _head = new LinkedListItem<T> { Value = value };
            _teil = _head;
        }

        public T PopBack()
        {
            if (!IsEmpty())
            {
                var value = PeekBack();
                if (_teil != _head)
                {
                    _teil = _teil.Prev;
                    _teil.Next.Prev = null;
                    _teil.Next = null;
                }
                else
                {
                    _teil = null;
                }
                Count--;
                return value;
            }
            return default(T);
        }

        public T PopFront()
        {
            if (!IsEmpty())
            {
                var value = PeekFront();
                if (_head != _teil)
                {
                    _head = _head.Next;
                    _head.Prev.Next = null;
                    _head.Prev = null;
                }
                else
                {
                    _head = null;
                }
                Count--;
                return value;
            }
            return default(T);
        }

        /* Выполняет фильтрацию последовательности значений на основе заданного предиката */
        public LinkedList<T> Where(Predicate<T> p)
        {
            var newList = new LinkedList<T>();
            var x = _head;
            while (x != null)
            {
                if (p(x.Value)) newList.PushBack(x.Value);
                x = x.Next;
            }
            return newList;
        }

        /* Проверяет, все ли элементы последовательности удовлетворяют условию */
        public bool All(Predicate<T> p)
        {
            var x = _head;
            while (x != null)
            {
                if (!p(x.Value))
                {
                    return false;
                }
                x = x.Next;
            }
            return true;
        }

        public bool Contains(Predicate<T> p)
        {
            var x = _head;
            while (x != null)
            {
                if (p(x.Value))
                {
                    return true;
                }
                x = x.Next;
            }
            return false;
        }

        public T[] ToArray()
        {
            var arr = new T[Count];
            var x = _head;
            for (var i = 0; x != null; ++i, x = x.Next)
                arr[i] = x.Value;
            return arr;
        }

        public override string ToString()
        {
            var result = "";
            var x = _head;
            while (x != null)
            {
                result += x.Value + " ";
                x = x.Next;
            }
            return result;
        }
    }
}