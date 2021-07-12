using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class ThreeWayQuickSort : Library
    {
        IComparable[] returnResult;
        public ThreeWayQuickSort(IComparable[] a)
        {
            Sort(a);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int lt = lo, gt = hi;
            IComparable v = a[lo];
            int i = lo;
            while(i <= gt)
            {
                int cmp = a[i].CompareTo(v);
                if (cmp < 0) Exchange(a, lt++, i++);
                else if (cmp > 0) Exchange(a, i, gt--);
                else i++;
            }

            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
        }

        private void Sort(IComparable[] a)
        {
            KnuthShuffle knuthShuffle = new KnuthShuffle(a);
            a = knuthShuffle.getShuffledList();
            Sort(a, 0, a.Length - 1);
            returnResult = a;
        }

        public void Display()
        {
            Show(returnResult);
        }
    }
}
