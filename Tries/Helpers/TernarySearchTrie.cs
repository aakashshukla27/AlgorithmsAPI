using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries.Helpers
{
    public class TernarySearchTrie<T>
    {
        private int n;
        private Node<T> root;

        private class Node<T>
        {
            public char c;
            public Node<T> left, mid, right;
            public T val;
        }

        public TernarySearchTrie() { }

        /// <summary>
        /// Returns the number of key-value pairs in this symbol table.
        /// </summary>
        /// <returns> the number of key-value pairs in this symbol table </returns>
        public int Size() => n;
        /// <summary>
        /// Does this symbol table contain the given key?
        /// </summary>
        /// <param name="key"> the key </param>
        /// <returns> {@code true} if this symbol table contains {@code key} and {@code false} otherwise</returns>
        public bool Contains(string key)
        {
            if(key == null)
            {
                throw new ArgumentException();
            }
            return Get(key) != null;
        }

        public T Get(string key)
        {
            if (key == null) throw new ArgumentException();

            if (key.Length == 0) throw new ArgumentException();
            Node<T> x = Get(root, key, 0);
            if (x == null) return default(T);
            return x.val;
        }

        private Node<T> Get(Node<T> x, string key, int d)
        {
            if (x == null) return null;
            if (key.Length == 0) throw new ArgumentException();
            char c = key[d];
            if (c < x.c) return Get(x.left, key, d);
            else if (c > x.c) return Get(x.right, key, d);
            else if (d < key.Length - 1) return Get(x.mid, key, d + 1);
            else return x;
        }

        public void Put(string key, T val)
        {
            if (key == null) throw new ArgumentException();
            if (!Contains(key)) n++;
            else if (val == null) n--;
            root = Put(root, key, val, 0);
        }

        private Node<T> Put(Node<T> x, string key, T val, int d)
        {
            char c = key[d];
            if(x == null)
            {
                x = new Node<T>();
                x.c = c;
            }
            if (c < x.c) x.left = Put(x.left, key, val, d);
            else if (c > x.c) x.right = Put(x.right, key, val, d);
            else if (d < key.Length - 1) x.mid = Put(x.mid, key, val, d + 1);
            else x.val = val;
            return x;
        }

        public string LongestPrefixOf(string query)
        {
            if (query == null) throw new NullReferenceException();
            if (query.Length == 0) return null;
            int length = 0;
            Node<T> x = root;
            int i = 0;
            while( x!= null && i < query.Length)
            {
                char c = query[i];
                if (c < x.c) x = x.left;
                else if (c > x.c) x = x.right;
                else
                {
                    i++;
                    if (x.val != null) length = i;
                    x = x.mid;
                }
            }
            return query.Substring(0, length);
        }

        public Queue<string> Keys()
        {
            Queue<string> queue = new Queue<string>();
            Collect(root, new StringBuilder(), queue);
            return queue;
        }
        public Queue<string> KeysWithPrefix(string prefix)
        {
            if(prefix == null)
            {
                throw new Exception();
            }
            Queue<string> queue = new Queue<string>();
            Node<T> x = Get(root, prefix, 0);
            if (x == null) return queue;
            if (x.val != null) queue.Enqueue(prefix);
            Collect(x.mid, new StringBuilder(prefix), queue);
            return queue;
        }

        private void Collect(Node<T> x, StringBuilder prefix, Queue<string> queue)
        {
            if (x == null) return;
            Collect(x.left, prefix, queue);
            if (x.val != null) queue.Enqueue(prefix.ToString() + x.c);
            Collect(x.mid, prefix.Append(x.c), queue);
            prefix.Remove(prefix.Length - 1, 1);
            Collect(x.right, prefix, queue);
        }

        public Queue<string> KeysThatMatch(string pattern)
        {
            Queue<string> queue = new Queue<string>();
            Collect(root, new StringBuilder(), 0, pattern, queue);
            return queue;
        }

        private void Collect(Node<T> x, StringBuilder prefix, int i, string pattern, Queue<string> queue)
        {
            if (x == null) return;
            char c = pattern[i];
            if (c == '.' || c < x.c) Collect(x.left, prefix, i, pattern, queue);
            if (c == '.' || c == x.c)
            {
                if (i == pattern.Length - 1 && x.val != null) queue.Enqueue(prefix.ToString() + x.c);
                if (i < pattern.Length - 1)
                {
                    Collect(x.mid, prefix.Append(x.c), i + 1, pattern, queue);
                    prefix.Remove(prefix.Length - 1, 1);
                }
            }
            if (c == '.' || c > x.c) Collect(x.right, prefix, i, pattern, queue);
        }



    }
}
