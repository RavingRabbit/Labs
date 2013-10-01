using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AudioSystem
{
    public class ObjectPool<T> where T : class
    {
        private readonly ConcurrentBag<T> _pool;
        private readonly Stack<T> _sleepingObjects;
        private readonly Func<T> _creator;
        private int _instanceCount;

        public ObjectPool(Func<T> creator)
            : this(creator, int.MaxValue)
        {
        }

        public ObjectPool(Func<T> creator, int maxInstances)
        {
            _creator = creator;
            _pool = new ConcurrentBag<T>();
            _sleepingObjects = new Stack<T>();
            SetMaxInstances(maxInstances);
        }

        public int MaxInstances { get; private set; }

        public void SetMaxInstances(int maxInstances)
        {
            if (maxInstances < 1)
                throw new ArgumentException("Number of spiders must be greater then one.", "maxInstances");
            if (maxInstances == MaxInstances)
                return;
            if (MaxInstances < maxInstances)
                IncreaseMaxInstances(maxInstances - MaxInstances);
            if (MaxInstances > maxInstances)
                ReduceMaxInstances(MaxInstances - maxInstances);
            MaxInstances = maxInstances;
        }

        private void IncreaseMaxInstances(int diff)
        {
            if (_sleepingObjects.Count == 0) return;
            if (_sleepingObjects.Count <= diff)
            {
                foreach (var obj in _sleepingObjects)
                {
                    Release(obj);
                }
                _sleepingObjects.Clear();
            }
            else
            {
                for (var i = 0; i < diff; i++)
                    Release(_sleepingObjects.Pop());
            }
        }

        private void ReduceMaxInstances(int diff)
        {
            for (var i = 0; i < diff; i++)
            {
                var webSpider = RemoveObject();
                if (webSpider != null)
                    _sleepingObjects.Push(webSpider);
            }
        }

        public int Size
        {
            get { return _pool.Count; }
        }

        public T GetObject()
        {
            lock (_pool)
            {
                var thisObject = RemoveObject();
                if (thisObject != null)
                    return thisObject;
                if (_instanceCount < MaxInstances)
                    return CreateObject();
                return null;
            }
        }

        public void Release(T obj)
        {
            if (obj == null)
                throw new NullReferenceException();
            lock (_pool)
            {
                _pool.Add(obj);
                OnObjectReleased();
            }
        }

        private T RemoveObject()
        {
            T obj;
            _pool.TryTake(out obj);
            return obj;
        }

        private T CreateObject()
        {
            var newObject = _creator();
            _instanceCount++;
            return newObject;
        }

        public event EventHandler ObjectReleased;

        protected virtual void OnObjectReleased()
        {
            var handler = ObjectReleased;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}