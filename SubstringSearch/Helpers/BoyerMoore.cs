using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAlgorithms.Helpers
{
    class BoyerMoore
    {
        private int[] right;
        private string pattern;
        public BoyerMoore(string pattern)
        {
            // skip table
            this.pattern = pattern;
            int m = pattern.Length;
            int r = 256;
            right = new int[r];
            for (int i = 0; i < r; i++)
            {
                right[i] = -1;
            }
            for (int i = 0; i < m; i++)
            {
                right[pattern[i]] = i;
            }
        }

        public int search(String txt)
        { // Search for pattern in txt.
            int N = txt.Length;
            int M = pattern.Length;
            int skip;
            for (int i = 0; i <= N - M; i += skip)
            { // Does the pattern match the text at position i ?
                skip = 0;
                for (int j = M - 1; j >= 0; j--)
                    if (pattern[j] != txt[i + j])
                    {
                        skip = j - right[txt[i + j]];
                        if (skip < 1) skip = 1;
                        break;
                    }
                if (skip == 0) return i; // found.
            }
            return N; // not found.
        }
    }
}
