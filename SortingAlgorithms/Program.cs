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
           
            IComparable[] test = new IComparable[100];
            //var random = new Random(0);
            //for (int i = 0; i < test.Length; i++)
            //{
            //    test[i] = random.Next(1, 100);
            //}

            string temp = RandomString(100);
            for(int i=0; i<temp.Length; i++)
            {
                test[i] = temp[i];
            }
            
            for (int i = 0; i < test.Length; i++)
            {
                Console.Write(test[i] + " ");
            }
            Console.WriteLine("");
            SelectionSort selectionSort = new SelectionSort(test);
            InsertionSort insertionSort = new InsertionSort(test);
            ShellSort shellSort = new ShellSort(test);
            Console.WriteLine("Selection Sort\n");
            selectionSort.Display();
            Console.WriteLine("Insertion Sort\n");
            insertionSort.Display();
            Console.WriteLine("Shell Sort\n");
            shellSort.Display();
            Console.WriteLine("Merge Sort\n");
            temp = "MERGESORTEXAMPLE";
            IComparable[] test2 = new IComparable[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                test2[i] = temp[i];
            }
            MergeSort mergeSort = new MergeSort(test);
            mergeSort.Display();
            Console.WriteLine("Merge Sort with Insertion sort");
            MergeSortInsertionSort mergeSortInsertionSort = new MergeSortInsertionSort(test);
            mergeSortInsertionSort.Display();

        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
