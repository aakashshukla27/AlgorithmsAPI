using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.Helpers
{
    class MaxPQ<T> where T : IComparable<T>
    {
        private T[] pq;
        private int N = 0;

        public MaxPQ(int capacity) => pq = new T[capacity+1];

        public bool IsEmpty() => N == 0;

        private bool Less(int i, int j) => pq[i].CompareTo(pq[j]) < 0;

        private void Exchange(int i, int j)
        {
            T swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
        }

        public void Insert(T key)
        {
            pq[++N] = key;
            Swim(N);
        }

        private void Swim(int k)
        {
            while(k > 1 && Less(k/2, k))
            {
                Exchange(k, k/2);
                k /= 2;
            }
        }

        private void Sink(int k)
        {
            while(2*k <= N)
            {
                int j = 2 * k;
                if (j < N && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Exchange(k, j);
                k = j;
            }
        }

        public T DelMax()
        {
            T max = pq[1];
            Exchange(1, N--);
            Sink(1);
            return max;
        }

    }
}
