using StringAlgorithms.Helpers;
using System;

namespace StringAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            BoyerMoore bm = new BoyerMoore("NEEDLE");
            int temp = bm.search("FINADINAHAYSTACKNEEDLEINA");
        }
    }
}
