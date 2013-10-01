using System;

namespace Laba_3_ISP
{
    public class BST<TKey, TValue> where TKey : IComparable
    {
        private Node<TKey, TValue> _root;

        #region Private Internal Methods

        private static Node<TKey, TValue> InternalSearch(Node<TKey, TValue> root, int key)
        {
            if (root == null)
                return null;
            if (key.CompareTo(root.Data.Key) < 0)
                return InternalSearch(root.Left, key);
            if (key.CompareTo(root.Data.Key) > 0)
                return InternalSearch(root.Right, key);
            return root;
        }

        private static string InternalToString(Node<TKey, TValue> root)
        {
            var resultString = "";
            if (root != null)
                resultString += InternalToString(root.Left) + root + Environment.NewLine + InternalToString(root.Right);
            return resultString;
        }

        #endregion

        public bool TryFind(int key, out TValue result)
        {
            var res = InternalSearch(_root, key);
            if (res != null)
            {
                result = res.Data.Value;
                return true;
            }
            result = default(TValue);
            return false;
        }

        public void Insert(TKey key, TValue value)
        {
            var data = new Data<TKey, TValue>(key, value);
            if (_root == null)
            {
                _root = new Node<TKey, TValue>(data);
                return;
            }
            var root = _root;
            while (true)
            {
                if (data == root.Data)
                {
                    /* такой элемент уже есть */
                    return;
                }
                if (data.Key.CompareTo(root.Data.Key) < 0)
                {
                    // insert left
                    if (root.Left == null)
                    {
                        root.Left = new Node<TKey, TValue>(data);
                        return;
                    }
                    root = root.Left;
                }
                else
                    if (data.Key.CompareTo(root.Data.Key) > 0)
                    {
                        // insert right
                        if (root.Right == null)
                        {
                            root.Right = new Node<TKey, TValue>(data);
                            return;
                        }
                        root = root.Right;
                    }
            }
        }

        public void Remove(int key)
        {
            var root = _root;
            Node<TKey, TValue> parent = null;
            while (root != null && !root.Data.Key.Equals(key))
            {
                parent = root;
                root = key.CompareTo(root.Data.Key) < 0 ? root.Left : root.Right;
            }
            if (root == null) return;
            if (root.Left == null || root.Right == null)
            {
                Node<TKey, TValue> child = null;
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
                root.Data = lowestNode.Data;
                if (lowestNodeParent.Left == lowestNode)
                    lowestNodeParent.Left = null;
                else
                    lowestNodeParent.Right = lowestNode.Right;
            }
        }

        public override string ToString()
        {
            return InternalToString(_root);
        }
    }
}
