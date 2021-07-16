using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Helpers
{
    class RedBlackTreeNode<Key, Value> where Key : IComparable<Key> where Value : IComparable<Value>
    {
        public Key key { get; internal set; }
        public Value value { get; internal set; }
        public RedBlackTreeNode<Key, Value> left, right;
        public int N { get; internal set; }
        public bool color { get; internal set; }

        public RedBlackTreeNode(Key key, Value value, int N, bool color)
        {
            this.key = key;
            this.value = value;
            this.N = N;
            this.color = color;
        }
    }
}
