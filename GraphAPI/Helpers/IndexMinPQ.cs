using GraphAPI.GraphClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.Helpers
{
    class IndexMinPQ
    {
        private int maxN;        // maximum number of elements on PQ
        private int n;           // number of elements on PQ
        private int[] pq;        // binary heap using 1-based indexing
        private int[] qp;        // inverse of pq - qp[pq[i]] = pq[qp[i]] = i
        private double[] keys;      // keys[i] = priority of i

        public IndexMinPQ(int capacity)
        {
            this.maxN = capacity;
            pq = new int[capacity + 1];
            qp = new int[capacity + 1];
            n = 0;
            keys = new double[capacity + 1];
            for (int i = 0; i <= maxN; i++)
                qp[i] = -1;
        }

        public bool isEmpty() => n == 0;

        public bool contains(int i) => qp[i] != -1;

        public int size() => n;

        public void insert(int i, double key)
        {
            if (contains(i)) throw new Exception("index is already in the priority queue");
            n++;
            qp[i] = n;
            pq[n] = i;
            keys[i] = key;
            swim(n);
        }

        public int minIndex()
        {
            if (n == 0) throw new Exception("Priority queue underflow");
            return pq[1];
        }

        public double minKey()
        {
            if (n == 0) throw new Exception("Priority queue underflow");
            return keys[pq[1]];
        }

        public int delMin()
        {
            if (n == 0) throw new Exception("Priority queue underflow");
            int min = pq[1];
            exch(1, n--);
            sink(1);
            qp[min] = -1;        // delete
            pq[n + 1] = -1;        // not needed
            return min;
        }

        public double keyOf(int i)
        {
            if (!contains(i)) throw new Exception("index is not in the priority queue");
            else return keys[i];
        }

        public void changeKey(int i, double key)
        {
            if (!contains(i)) throw new Exception("index is not in the priority queue");
            keys[i] = key;
            swim(qp[i]);
            sink(qp[i]);
        }

        public void decreaseKey(int i, double key)
        {
            if (!contains(i)) throw new Exception("index is not in the priority queue");
            if (keys[i].CompareTo(key) == 0)
                throw new Exception("Calling decreaseKey() with a key equal to the key in the priority queue");
            if (keys[i].CompareTo(key) < 0)
                throw new Exception("Calling decreaseKey() with a key strictly greater than the key in the priority queue");
            keys[i] = key;
            swim(qp[i]);
        }

        public void increaseKey(int i, double key)
        {
            if (!contains(i)) throw new Exception("index is not in the priority queue");
            if (keys[i].CompareTo(key) == 0)
                throw new Exception("Calling increaseKey() with a key equal to the key in the priority queue");
            if (keys[i].CompareTo(key) > 0)
                throw new Exception("Calling increaseKey() with a key strictly less than the key in the priority queue");
            keys[i] = key;
            sink(qp[i]);
        }

        public void delete(int i)
        {
            if (!contains(i)) throw new Exception("index is not in the priority queue");
            int index = qp[i];
            exch(index, n--);
            swim(index);
            sink(index);
            qp[i] = -1;
        }

        private bool greater(int i, int j)
        {
            return keys[pq[i]].CompareTo(keys[pq[j]]) > 0;
        }

        private void exch(int i, int j)
        {
            int swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }

        private void swim(int k)
        {
            while (k > 1 && greater(k / 2, k))
            {
                exch(k, k / 2);
                k /= 2;
            }
        }

        private void sink(int k)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && greater(j, j + 1)) j++;
                if (!greater(k, j)) break;
                exch(k, j);
                k = j;
            }
        }

    }
}
