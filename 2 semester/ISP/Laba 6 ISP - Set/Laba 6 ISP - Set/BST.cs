using System;
using System.Collections.Generic;

namespace Laba_6_ISP___Set
{
    public class BST<T> where T : IComparable
    {
        private BSTNode<T> _root;

        public int Count { get; private set; }

        public void Insert(T value)
        {
            if (_root == null)
            {
                _root = new BSTNode<T>(value);
                return;
            }
            var root = _root;
            while (true)
            {
                if (value.Equals(root.Value))
                {
                    /* такой элемент уже есть */
                    return;
                }
                if (value.CompareTo(root.Value) < 0)
                {
                    // insert left
                    if (root.Left == null)
                    {
                        root.Left = new BSTNode<T>(value);
                        Count++;
                        OnInserted(new EventArgs<T>(value));
                        return;
                    }
                    root = root.Left;
                }
                else
                    if (value.CompareTo(root.Value) > 0)
                    {
                        // insert right
                        if (root.Right == null)
                        {
                            root.Right = new BSTNode<T>(value);
                            Count++;
                            OnInserted(new EventArgs<T>(value));
                            return;
                        }
                        root = root.Right;
                    }
            }
        }

        public void Remove(T value)
        {
            var root = _root;
            BSTNode<T> parent = null;
            while (root != null && !root.Value.Equals(value))
            {
                parent = root;
                root = value.CompareTo(root.Value) < 0 ? root.Left : root.Right;
            }
            if (root == null) return;
            if (root.Left == null || root.Right == null)
            {
                BSTNode<T> child = null;
                if (root.Left != null)
                    child = root.Left;
                else if (root.Right != null)
                    child = root.Right;
                if (parent == null)
                    _root = child;
                else
                {
                    if (parent.Left == root)
                        parent.Left = child;
                    else
                        parent.Right = child;
                }
            }
            else
            {
                var lowestNode = root.Right;
                var lowestNodeParent = root;
                while (lowestNode.Left != null)
                {
                    lowestNodeParent = lowestNode;
                    lowestNode = lowestNode.Left;
                }
                root.Value = lowestNode.Value;
                if (lowestNodeParent.Left == lowestNode)
                    lowestNodeParent.Left = null;
                else
                    lowestNodeParent.Right = lowestNode.Right;
            }
            Count--;
            OnRemoved(new EventArgs<T>(value));
        }

        public event EventHandler<EventArgs<T>> Removed;

        protected virtual void OnRemoved(EventArgs<T> e)
        {
            if (Removed != null) Removed(this, e);
        }

        public event EventHandler<EventArgs<T>> Inserted;

        protected virtual void OnInserted(EventArgs<T> e)
        {
            if (Inserted != null) Inserted(this, e);
        }

        /* нерекурсивный обход дерева */
        public void NewForEach(Action<T> f)
        {
            var root = _root;
            var stack = new Stack<BSTNode<T>>();
            while (root != null)
            {
                while (root != null)
                {
                    f(root.Value);
                    if (root.Right != null)
                        stack.Push(root.Right);
                    root = root.Left;
                }
                root = stack.Count != 0 ? stack.Pop() : null;
            }
        } 

        public void ForEach(Action<T> f)
        {
             InternalForEach(f, _root);
        }

        private static void InternalForEach(Action<T> f, BSTNode<T> root)
        {
            if (root == null)
                return;
            InternalForEach(f, root.Left);
            f(root.Value);
            InternalForEach(f, root.Right);
        }


        /* Проверяет, существует ли элемент последовательности, удовлетворяющий предикату */
        public bool Contains(Predicate<T> p)
        {
            var result = false;
            ForEach(x => { if (p(x)) result = true; });
            return result;
        }

        /* Проверяет, все ли элементы последовательности удовлетворяют условию */
        public bool All(Predicate<T> p)
        {
            var result = true;
            ForEach(x => { if (!p(x)) result = false; });
            return result;
        }

        /* Выполняет фильтрацию последовательности значений на основе заданного предиката */
        public BST<T> Where(Predicate<T> p)
        {
            var newBST = new BST<T>();
            ForEach(x => { if (p(x)) newBST.Insert(x); });
            return newBST;
        }

        public override string ToString()
        {
            var result = "";
            ForEach(x => { result += x + " "; });
            return result;
        }

        public T[] ToArray()
        {
            var array = new T[Count + 1];
            var i = 0;
            ForEach(x => { array[i] = x; i++; });
            return array;
        }
    }
}
