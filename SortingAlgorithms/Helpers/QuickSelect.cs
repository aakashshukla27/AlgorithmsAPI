using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class QuickSelect : Library
    {
        private readonly IComparable returnItem;
        public QuickSelect(IComparable[] a, int k)
        {
            returnItem = Select(a, k);
        }

        private IComparable Select(IComparable[] a, int k)
        {
            KnuthShuffle knuthShuffle = new KnuthShuffle(a);
            a = knuthShuffle.getShuffledList();
            int lo = 0, hi = a.Length - 1;
            while(hi> lo)
            {
                int j = Partition(a, lo, hi);
                if (j < k)
                    lo = j + 1;
                if (j > k)
                    hi = j - 1;
                else
                    return a[k];
            }
            return a[k];
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

        public IComparable ReturnKthItem()
        {
            return returnItem;
        }
    }
}
