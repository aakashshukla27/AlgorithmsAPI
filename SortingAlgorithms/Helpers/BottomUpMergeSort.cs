using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    /// <summary>
    /// Non recursive merge sort
    /// </summary>
    class BottomUpMergeSort : Library
    {
        private IComparable[] returnResult;
        private IComparable[] aux;
        /// <summary>
        /// Constructor for Merge sort
        /// </summary>
        /// <param name="a">input list</param>
        public BottomUpMergeSort(IComparable[] a)
        {
            Sort(a);
        }

        /// <summary>
        /// Merge process
        /// </summary>
        /// <param name="a">input list</param>
        /// <param name="lo">lower bound</param>
        /// <param name="mid">mid point</param>
        /// <param name="hi">upper bound</param>
        private void Merge(IComparable[] a, int lo, int mid, int hi)
        {
            //Copying into auxiliary array
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

        /// <summary>
        /// Driver function for sort functionality
        /// </summary>
        /// <param name="a">Input list</param>
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
        /// <summary>
        /// Display List
        /// </summary>
        public void Display()
        {
            Show(returnResult);
        }
        
    }
}
