using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.Helpers
{
    class HeapSort
    {
        IComparable[] returnResult;
        public HeapSort(IComparable[] a) {
            Sort(a);
        }
        
        public void Sort(IComparable[] a)
        {
            int n = a.Length;

            // heapify phase
            for (int x = n / 2; x >= 1; x--)
                Sink(a, x, n);

            // sortdown phase
            int k = n;
            while (k > 1)
            {
                Exchange(a, 1, k--);
                Sink(a, 1, k);
            }
            returnResult = a;
        }

        private bool Less(IComparable[] a, int i, int j) => a[i-1].CompareTo(a[j-1]) < 0;
      
        private void Exchange(IComparable[] a, int i, int j)
        {
            IComparable temp = a[i-1];
            a[i-1] = a[j-1];
            a[j-1] = temp;
        }
        private void Sink(IComparable[] a, int k, int n)
        {
            while(2*k <= n)
            {
                int j = 2 * k;
                if (j < n && Less(a, j, j + 1)) j++;
                if (!Less(a, k, j)) break;
                Exchange(a, k, j);
                k = j;
            }
        }
        public void Display()
        {
            Show(returnResult);
        }

        private void Show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine("");
        }
    }
}
