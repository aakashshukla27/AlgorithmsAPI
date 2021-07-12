using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    /// <summary>
    /// Dijkstra's improvements to Quick Sort to handle equal keys
    /// </summary>
    class ThreeWayQuickSort : Library
    {
        IComparable[] returnResult;
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="a">input array</param>
        public ThreeWayQuickSort(IComparable[] a)
        {
            Sort(a);
        }

        /// <summary>
        /// Quick Sort main logic
        /// </summary>
        /// <param name="a">input array</param>
        /// <param name="lo">lower bound</param>
        /// <param name="hi">upper bound</param>
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

        /// <summary>
        /// Driver function for sorting
        /// </summary>
        /// <param name="a">input array</param>
        private void Sort(IComparable[] a)
        {
            KnuthShuffle knuthShuffle = new KnuthShuffle(a);
            a = knuthShuffle.getShuffledList();
            Sort(a, 0, a.Length - 1);
            returnResult = a;
        }
        /// <summary>
        /// Display the sorted list
        /// </summary>
        public void Display()
        {
            Show(returnResult);
        }
    }
}
