using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class InsertionSort : Library
    {
        IComparable[] input;
        public InsertionSort(IComparable[] a)
        {
            sort(a);
        }

        public void sort(IComparable[] a)
        {
            int N = a.Length;
            for(int i=1; i<N; i++)
            {
                //for(int j=i; j>0 && Less(a[j], a[j-1]); j--)
                //{
                //    Exchange(a, j, j-1);
                //}
                for (int j = i; j > 0; j--)
                {
                    if(Less(a[j], a[j - 1]))
                    {
                        Exchange(a, j, j - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            input = a;
        }
        public void Display()
        {
            Show(input);
        }
        public IComparable[] returnSorted()
        {
            return input;
        }
    }
}
