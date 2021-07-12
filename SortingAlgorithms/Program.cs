using SortingAlgorithms.Helpers;
using System;
using System.Linq;

namespace SortingAlgorithms
{
    class Program
    {
        private static Random random = new Random(0);
        
        static void Main(string[] args)
        {
           
            
            //var random = new Random(0);
            //for (int i = 0; i < test.Length; i++)
            //{
            //    test[i] = random.Next(1, 100);
            //}

            //string temp = RandomString(100);
            //for(int i=0; i<temp.Length; i++)
            //{
            //    test[i] = temp[i];
            //}
            
            //for (int i = 0; i < test.Length; i++)
            //{
            //    Console.Write(test[i] + " ");
            //}

            string tempString = "PABXWPPVPDPCYZ";
            IComparable[] test = new IComparable[tempString.Length];
            for (int i = 0; i < tempString.Length; i++)
            {
                test[i] = tempString[i];
            }

            ThreeWayQuickSort threeWayQuickSort = new ThreeWayQuickSort(test);
            threeWayQuickSort.Display();


        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
