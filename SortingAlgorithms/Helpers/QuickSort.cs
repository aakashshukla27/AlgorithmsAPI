using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    /// <summary>
    /// Quick sort implementation
    /// </summary>
    class QuickSort : Library
    {
        IComparable[] returnResult;
        /// <summary>
        /// Constructor for quick sort
        /// </summary>
        /// <param name="a">input list</param>
        public QuickSort(IComparable[] a)
        {
            Sort(a);
        }

        /// <summary>
        /// Partition Logic 
        /// </summary>
        /// <param name="a">input list</param>
        /// <param name="lo">lower bound</param>
        /// <param name="hi">upper bound</param>
        /// <returns>pivots sorted position</returns>
        private int Partition(IComparable[] a, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            while (true)
            {
                // run till we encounter an item larger than pivot
                while(Less(a[++i], a[lo]))
                    if(i == hi)
                        break;
                // run till we encounter item smaller than pivot
                while (Less(a[lo], a[--j]))
                    if (j == lo)
                        break;
                // if left and right pointers cross break
                if (i >= j) break;
                // exchange ith and jth items
                Exchange(a, i, j);
            }
            
            return j;

        }
        /// <summary>
        /// Driver function
        /// </summary>
        /// <param name="a">input list</param>
        private void Sort(IComparable[] a)
        {
            // Implementing Knuth Shuffle over the input list
            KnuthShuffle knuthShuffle = new KnuthShuffle(a);
            a = knuthShuffle.getShuffledList();
            Sort(a, 0, a.Length - 1);
            returnResult = a;
        }
        /// <summary>
        /// Quick Sort Sub Arrays of main array
        /// </summary>
        /// <param name="a">input array</param>
        /// <param name="lo">lower bound</param>
        /// <param name="hi">upper bound</param>
        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }
        /// <summary>
        /// Display the result
        /// </summary>
        public void Display()
        {
            Show(returnResult);
        }
    }
}
