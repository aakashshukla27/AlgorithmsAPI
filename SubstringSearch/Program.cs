using StringAlgorithms.Helpers;
using System;

namespace StringAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //PatternSearch ps = new PatternSearch();
            //var temp = ps.SearchBruteForce("ABRA", "ABACADABRAC");

            KnuthMorrisPratt kmp = new KnuthMorrisPratt("TEST");
            int temp = kmp.search("THIS IS A TEST TEXT");
        }
    }
}
