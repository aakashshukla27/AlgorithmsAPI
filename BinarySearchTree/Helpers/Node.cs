using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Helpers
{
    class Node<Key, Value> where Key : IComparable<Key> where Value : IComparable<Value>
    {
        public Key key { get; internal set; }
        public Value value { get; internal set; }
        public Node<Key, Value> left { get; internal set; }
        public Node<Key, Value> right { get; internal set; }
        public int N { get; set; }

        public Node(Key key, Value value, int N)
        {
            this.key = key;
            this.value = value;
            this.N = N;
        }

        
    }
}
