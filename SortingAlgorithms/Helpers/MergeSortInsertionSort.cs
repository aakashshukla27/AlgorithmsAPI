using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class MergeSortInsertionSort : Library
    {
        IComparable[] returnResult;
        private int cutOff = 7;

        public MergeSortInsertionSort(IComparable[] a)
        {
            Sort(a);
        }

        private void Merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {
            for (int k = lo; k <= hi; k++)
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
        private void Sort(IComparable[] a, IComparable[] aux, int lo, int hi)
        {
           
            if(hi <= lo + cutOff -1)
            {
                InsertionSort insertionSort = new InsertionSort(a);
                a = insertionSort.returnSorted();
                return;
            }
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);

        }

        private void Sort(IComparable[] a)
        {
            IComparable[] aux = new IComparable[a.Length];
            Sort(a, aux, 0, a.Length - 1);
            returnResult = a;
        }

        public void Display()
        {
            Show(returnResult);
        }
    }
}
