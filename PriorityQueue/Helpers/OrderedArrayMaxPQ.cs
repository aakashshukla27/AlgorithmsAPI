using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.Helpers
{
    class OrderedArrayMaxPQ<T> where T : IComparable<T>
    {
        private T[] pq;
        private int N = 0;

        public OrderedArrayMaxPQ(int capacity) => pq = new T[capacity];

        public bool IsEmpty() => N == 0;

        public int Size()
        {
            return N;
        }

        public T DelMax() => pq[N--];

        public void Insert(T key)
        {
            int i = N - 1;
            while(i >= 0 && Less(key, pq[i]))
            {
                pq[i + 1] = pq[i];
                i--;
            }
            pq[i + 1] = key;
            N++;
        }

        private bool Less(T i, T j) => i.CompareTo(j) < 0;
    }
}
