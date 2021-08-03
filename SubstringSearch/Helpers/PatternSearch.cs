using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAlgorithms.Helpers
{
    class PatternSearch
    {
        public int SearchBruteForce(string pattern, string text)
        {
            int m = pattern.Length;
            int n = text.Length;

            for(int i=0; i<= n-m; i++)
            {
                int j;
                for (j = 0; j < m; j++)
                {
                    if(text[i+j] != pattern[j])
                    {
                        break;
                    }
                    
                }
                if (j == m) return i;
            }

            return n;
        }

        public int SearchBruteForce2(string pattern, string text)
        {
            int i, n = text.Length;
            int j, m = pattern.Length;

            for(i =0, j=0; i<n && j<m; i++)
            {
                if (text[i] == pattern[j]) j++;
                else
                {
                    i -= j;
                    j = 0;
                }
            }
            if (i == m) return i - m;
            else return n;
        }
    }
}
