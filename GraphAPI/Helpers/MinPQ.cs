using GraphAPI.GraphClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.Helpers
{
    class MinPQ
    {
        private Edge[] pq;
        private int n;
        public MinPQ(int capacity)
        {
            pq = new Edge[capacity + 1];
            n = 0;
        }

        public int Size() => n;

        public Edge Min()
        {
            if (IsEmpty()) throw new Exception("Priority queue underflow");
            return pq[1];
        }

        public bool IsEmpty() => n == 0;

        private void Resize(int capacity)
        {
            
            Edge[] temp = new Edge[capacity];
            for (int i = 1; i <= n; i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
        }

        public void Insert(Edge x)
        {
            // double size of array if necessary
            if (n == pq.Length - 1) Resize(2 * pq.Length);

            // add x, and percolate it up to maintain heap invariant
            pq[++n] = x;
            Swim(n);
        }

        private void Swim(int k)
        {
            while (k > 1 && greater(k/2, k))
            {
                Exch(k, k / 2);
                k /= 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && greater(j, j + 1)) j++;
                if (!greater(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }

        private bool greater(int i, int j) => (pq[i].weight).CompareTo(pq[j].weight) > 0;
       

        private void Exch(int i, int j)
        {
            Edge swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
        }

        public Edge delMin()
        {
            if (IsEmpty()) throw new Exception("Priority queue underflow");
            Edge min = pq[1];
            Exch(1, n--);
            Sink(1);
            if ((n > 0) && (n == (pq.Length - 1) / 4)) Resize(pq.Length / 2);
            return min;
        }



    }
}
