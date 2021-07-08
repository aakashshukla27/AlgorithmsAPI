using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class BottomUpMergeSort : Library
    {
        private IComparable[] returnResult;
        private IComparable[] aux;
        public BottomUpMergeSort(IComparable[] a)
        {
            Sort(a);
        }


        private void Merge(IComparable[] a, int lo, int mid, int hi)
        {
            for(int k=0; k<a.Length; k++)
            {
                aux[k] = a[k];
            }
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    a[k] = aux[j++];
                }
                else if (j > hi)
                {
                    a[k] = aux[i++];
                }
                else if (Less(aux[j], aux[i]))
                {
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
            }
        }

        private void Sort(IComparable[] a)
        {
            int N = a.Length;
            aux = new IComparable[N];
            for (int i = 1; i < N; i *= 2)
            {
                for (int lo = 0; lo < N - i; lo += (2*i))
                {
                    Merge(a, lo, lo + i - 1, Math.Min(lo + i + i - 1, N - 1));
                }
            }
            returnResult = a;
        }

        public void Display()
        {
            Show(returnResult);
        }
        
    }
}
