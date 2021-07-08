using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class ShellSort : Library
    {
        IComparable[] input;

        public ShellSort(IComparable[] a)
        {
            Sort(a);
        }

        public void Sort(IComparable[] a)
        {
            int N = a.Length;
            int h = 1;
            while(h < (N / 3))
            {
                h = 3 * h + 1;
            }
            while (h >= 1)
            {
                for(int i=h; i<N; i++)
                {
                    for (int j = i; j >= h && Less(a[j], a[j-h]); j -= h)
                    {
                        Exchange(a, j, j - h);
                    }
                }
                h /= 3;
            }
            input = a;
        }

        public void Display()
        {
            Show(input);
        }
    }
}
