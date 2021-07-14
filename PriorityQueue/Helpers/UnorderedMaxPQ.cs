using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.Helpers
{
    class UnorderedMaxPQ<Key> where Key : IComparable<Key>
    {
        private Key[] pq;
        private int N = 0;
        public UnorderedMaxPQ(int capacity) => pq = new Key[capacity];

        public bool IsEmpty() => N == 0;

        public void Insert(Key x) => pq[N++] = x;

        public Key DelMax()
        {
            int max = 0;
            for (int i = 1; i < N; i++)
            {
                if (Less(max, i)) max = i;
            }
            Exchange(max, N - 1);
            return pq[--N];
        }

        private void Exchange(int i, int j)
        {
            Key swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
        }
        private bool Less(int i, int j) => pq[i].CompareTo(pq[j]) < 0;
    }
}
