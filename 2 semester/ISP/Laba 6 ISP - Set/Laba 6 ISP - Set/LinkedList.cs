using System;

namespace Laba_6_ISP___Set
{
    public class LinkedList<T>
    {
        private LinkedListItem<T> _head;

        private LinkedListItem<T> _teil;

        public int Count { get; private set; }

        public LinkedList()
        {
            _head = null;
            _teil = null;
            Count = 0;
        }

        private bool IsEmpty()
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
                _teil.Next = new LinkedListItem<T>(value) { Prev = _teil };
                _teil = _teil.Next;
            }
            Count++;
            OnPushed(new EventArgs<T>(value));
        }

        public void PushFront(T value)
        {
            if (IsEmpty())
            {
                PushIntoEmpty(value);
            }
            else
            {
                _head.Prev = new LinkedListItem<T>(value) { Next = _head };
                _head = _head.Prev;
            }
            Count++;
            OnPushed(new EventArgs<T>(value));
        }

        public void PushIntoEmpty(T value)
        {
            _head = new LinkedListItem<T>(value);
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
                OnPoped(new EventArgs<T>(value));
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
                OnPoped(new EventArgs<T>(value));
                return value;
            }
            return default(T);
        }

        public event EventHandler<EventArgs<T>> Poped;

        protected virtual void OnPoped(EventArgs<T> e)
        {
            if (Poped != null) Poped(this, e);
        }

        public event EventHandler<EventArgs<T>> Pushed;

        protected virtual void OnPushed(EventArgs<T> e)
        {
            if (Pushed != null) Pushed(this, e);
        }

        public void ForEach(Action<T> f)
        {
            var x = _head;
            while (x != null)
            {
                f(x.Value);
                x = x.Next;
            }
        }

        /* Выполняет фильтрацию последовательности значений на основе заданного предиката */
        public LinkedList<T> Where(Predicate<T> p)
        {
            var newList = new LinkedList<T>();
            ForEach(x => { if (p(x)) newList.PushBack(x); });
            return newList;
        }

        /* Проверяет, все ли элементы последовательности удовлетворяют условию */
        public bool All(Predicate<T> p)
        {
            var result = true;
            ForEach(x => { if (!p(x)) result = false; });
            return result;
        }

        public bool Contains(Predicate<T> p)
        {
            var result = false;
            ForEach(x => { if (p(x)) result = true; });
            return result;
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            var i = 0;
            ForEach(x => { array[i] = x; i++; });
            return array;
        }

        public override string ToString()
        {
            var result = "";
            ForEach(x => { result += x + " "; });
            return result;
        }
    }
}