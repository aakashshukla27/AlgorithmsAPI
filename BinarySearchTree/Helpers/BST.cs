using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Helpers
{
    class BST<Key, Value> where Key : IComparable<Key> where Value: IComparable<Value>
    {
        public Node<Key, Value> root { get; internal set; }

        public Value Get(Key key)
        {
            return Get(root, key);
        }
        
        private Value Get(Node<Key, Value> x, Key key)
        {
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return Get(x.left, key);
            if (cmp > 0) return Get(x.right, key);
            else return x.value;

        }

        public void Put(Key key, Value value)
        {
            root = Put(root, key, value);
        }

        private Node<Key, Value> Put(Node<Key, Value> x, Key key, Value value)
        {
            if(x == null) { return new Node<Key, Value>(key, value, 1); }

            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = Put(x.left, key, value);
            if (cmp > 0) x.right = Put(x.right, key, value);
            else x.value = value;
            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        public int Size() => Size(root);
       
        private static int Size(Node<Key, Value> x)
        {
            if (x == null) return 0;
            else return x.N;
        }

        public Key Floor(Key key)
        {
            Node<Key,Value> x = Floor(root, key);
            if (x == null) return x.key;
            return x.key;
        }

        private Node<Key, Value> Floor(Node<Key, Value> x, Key key)
        {
            if (x == null) return x;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0) return Floor(x.left, key);
            Node<Key, Value> t = Floor(x.right, key);
            if (t != null) return t;
            else return x;
        }

        public int Rank(Key key)
        {
            return Rank(key, root);
        }

        private int Rank(Key key, Node<Key, Value> x)
        {
            if (x == null) return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return Rank(key, x.left);
            else if (cmp > 0) return 1 + Size(x.left) + Rank(key, x.right);
            else return Size(x.left);
        }

        public IEnumerable<Key> Keys()
        {
            Queue<Key> q = new Queue<Key>();
            Inorder(root, q);
            return q;
        }

        private void Inorder(Node<Key, Value> x, Queue<Key> q)
        {
            if (x == null) return;
            Inorder(x.left, q);
            q.Enqueue(x.key);
            Inorder(x.right, q);
        }

        private void Preorder(Node<Key, Value> x, Queue<Key> q)
        {
            if (x == null) return;
            q.Enqueue(x.key);
            Preorder(x.left, q);
            Preorder(x.right, q);
        }

        private void PostOrder(Node<Key, Value> x, Queue<Key> q)
        {
            if (x == null) return;
            PostOrder(x.left, q);
            PostOrder(x.right, q);
            q.Enqueue(x.key);
        }

        public void DeleteMin()
        {
            root = DeleteMin(root);
        }

        private Node<Key, Value> DeleteMin(Node<Key, Value> x)
        {
            if (x.left == null) return x.right;
            x.left = DeleteMin(x.left);
            x.N = 1 + Size(x.left) + Size(x.right);
            return x;
        }

        public void Delete(Key key)
        {
            root = Delete(root, key);
        }

        private Node<Key, Value> Delete(Node<Key, Value> x, Key key)
        {
            if (x == null) return x;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = Delete(x.left, key);
            else if (cmp > 0) x.right = Delete(x.right, key);
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;
                Node<Key, Value> t = x;
                x = Min(t.right);
                x.right = DeleteMin(t.right);
                x.left = t.left;
            }
            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        public Key Min()
        {
            return Min(root).key;
        }
        private Node<Key, Value> Min(Node<Key, Value> x)
        {
            if (x.left == null) return x;
            return Min(x.left);
        }
    }
}
 