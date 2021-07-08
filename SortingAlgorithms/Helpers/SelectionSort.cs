using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class SelectionSort : Library
    {
        IComparable[] input;
        public SelectionSort(IComparable[] a)
        {
            sort(a);
        }

        public void sort(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int min = i;
                for(int j=i+1; j < N; j++)
                {
                    if(Less(a[j], a[min]))
                    {
                        min = j;
                    }                    
                }
                Exchange(a, i, min);
            }
            input = a;
        }

        public void Display()
        {
            Show(input);
        }

    }
}
 