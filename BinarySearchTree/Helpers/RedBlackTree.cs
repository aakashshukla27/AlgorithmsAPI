using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Helpers
{
    class RedBlackTree<Key, Value> where Key : IComparable<Key> where Value : IComparable<Value>
    {
        private readonly bool RED = true;
        private readonly bool BLACK = false;
        public RedBlackTreeNode<Key, Value> root { get; internal set; }
        private bool IsRed(RedBlackTreeNode<Key, Value> x)
        {
            if (x == null) return false; // Null links are black
            return x.color == RED;
        }

        public Value Get(Key key)
        {
            RedBlackTreeNode<Key, Value> x = root;
            
            while(x != null)
            {
                int cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                if (cmp > 0) x = x.right;
                else break;
            }
            return x.value;
        }

        private RedBlackTreeNode<Key, Value> RotateLeft(RedBlackTreeNode<Key, Value> h)
        {
            RedBlackTreeNode<Key, Value> x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = 1 + Size(h.left) + Size(h.right);
            return x;
        }

        public int Size() => Size(root);

        private int Size(RedBlackTreeNode<Key, Value> x)
        {
            if (x == null) return 0;
            else return x.N;
        }

        private RedBlackTreeNode<Key, Value> RotateRight(RedBlackTreeNode<Key, Value> h)
        {
            RedBlackTreeNode<Key, Value> x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = h.color;
            h.color = RED;
           
            return x;
        }

        private void ColorFlip(RedBlackTreeNode<Key, Value> h)
        {
            h.color = RED;
            h.left.color = BLACK;
            h.right.color = BLACK;
        }

        public void Put(Key key, Value value)
        {
            root = Put(root, key, value);
            root.color = BLACK;
        }

        public RedBlackTreeNode<Key, Value> Put(RedBlackTreeNode<Key, Value> h, Key key, Value val)
        {
            if (h == null) // Do standard insert, with red link to parent.
                return new RedBlackTreeNode<Key, Value>(key, val, 1, RED);
            int cmp = key.CompareTo(h.key);
            if (cmp < 0) h.left = Put(h.left, key, val);
            else if (cmp > 0) h.right = Put(h.right, key, val);
            else h.value = val;
            if (IsRed(h.right) && !IsRed(h.left)) h = RotateLeft(h);
            if (IsRed(h.left) && IsRed(h.left.left)) h = RotateRight(h);
            if (IsRed(h.left) && IsRed(h.right)) ColorFlip(h);
            h.N = Size(h.left) + Size(h.right) + 1;
            return h;
        }
    }
}
