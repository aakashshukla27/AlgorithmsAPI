using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries.Helpers
{
    public class TrieST
    {
        private int R = 256;
        private Node root;

        public class Node
        {            
            public object val;
            public Node[] next = new Node[256];
        }

        public object Get(string key)
        {
            Node x = Get(root, key, 0);
            if (x == null) return null;
            return x.val;
        }

        private Node Get(Node x, string key, int d)
        {
            if (x == null) return null;
            if (d == key.Length) return x;
            char c = key[d];
            return Get(x.next[c], key, d + 1);
        }
        public void Put(string key, object val) { 
        }

        private Node Put(Node x, string key, object val, int d)
        {
            if (x == null) x = new Node();
            if(d == key.Length)
            {
                x.val = val;
                return x;
            }
            char c = key[d];
            x.next[c] = Put(x.next[c], key, val, d + 1);
            return x;
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(Node x)
        {
            if (x == null) return 0;
            int count = 0;
            if (x.val != null) count++;
            for(char c = (char)0; c < R; c++)
            {
                count += Size(x.next[c]);
            }
            return count;
        }


        public Queue<string> keys()
        { return keysWithPrefix(""); }
        public Queue<string> keysWithPrefix(String pre)
        {
            Queue<string> q = new Queue<string>();
            collect(Get(root, pre, 0), pre, q);
            return q;
        }
        private void collect(Node x, String pre, Queue<String> q)
        {
            if (x == null) return;
            if (x.val != null) q.Enqueue(pre);
            for (char c = (char)0; c < R; c++)
                collect(x.next[c], pre + c, q);
        }





    }
}
