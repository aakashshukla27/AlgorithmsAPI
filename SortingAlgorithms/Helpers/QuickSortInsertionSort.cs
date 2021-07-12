using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class QuickSortInsertionSort : Library
    {
        IComparable[] returnResult;
        private int cutoff = 10;
        public QuickSortInsertionSort(IComparable[] a)
        {
            Sort(a);
        }

        private int Partition(IComparable[] a, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            while (true)
            {
                while (Less(a[++i], a[lo]))
                    if (i == hi)
                        break;
                while (Less(a[lo], a[--j]))
                    if (j == lo)
                        break;
                if (i >= j)
                    break;
                Exchange(a, i, j);
            }
            return j;
        }

        private void Sort(IComparable[] a)
        {
            KnuthShuffle knuthShuffle = new KnuthShuffle(a);
            a = knuthShuffle.getShuffledList();
            Sort(a, 0, a.Length - 1);
            returnResult = a;
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            if(hi <= lo + cutoff - 1)
            {
                InsertionSort insertionSort = new InsertionSort(a);
                a = insertionSort.returnSorted();
                return;
            }
            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }

        public void Display()
        {
            Show(returnResult);
        }
    }
}
