using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAlgorithms.Helpers
{
    class KnuthMorrisPratt
    {
        private string pattern;
        private int[,] dfa;

        public KnuthMorrisPratt(string pattern)
        {
            this.pattern = pattern;
            int m = pattern.Length;
            int r = 256;
            dfa = new int[r,m];

            dfa[pattern[0], 0] = 1;
            for (int X = 0, j = 1; j < m; j++)
            {
                for(int c = 0; c < r; c++)
                {
                    dfa[c, j] = dfa[c, X];
                }
                dfa[pattern[j], j] = j + 1;
                X = dfa[pattern[j], X];
            }
        }

        public int search(string txt)
        {
            int i, j, N = txt.Length, M = pattern.Length;
            for (i = 0, j = 0; i < N && j < M; i++)
            {
                j = dfa[txt[i], j];
            }
            if (j == M) return i - M;
            else return N;
        }
    }
}
