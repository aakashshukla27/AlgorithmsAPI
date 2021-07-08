using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Helpers
{
    class KnuthShuffle : Library
    {
        IComparable[] returnList;
        public KnuthShuffle(IComparable[] a)
        {
            shuffle(a);
        }

        private void shuffle(IComparable[] a)
        {
            int N = a.Length;
            var random = new Random();
            for (int i = 0; i < N; i++)
            {
                int r = random.Next(0, i+1);
                Exchange(a, i, r);
            }
            returnList = a;
        }

        public IComparable[] getShuffledList()
        {
            return returnList;
        }
    }
}
