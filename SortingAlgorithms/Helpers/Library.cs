using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class Library
    {
        protected bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        protected void Exchange(IComparable[] a, int i, int j)
        {
            IComparable t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        protected void Show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " " );
            }
            Console.WriteLine("");
        }

        protected Boolean IsSorted(IComparable[] a, int start, int end)
        {            
            for (int i = start+1; i < end; i++)
            {
                if (Less(a[i], a[i - 1])) return false;                
            }
            return true;
        }
        protected Boolean IsSorted(IComparable[] a)
        {
          
            for (int i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1])) return false;
            }
            return true;
        }
    }
}
