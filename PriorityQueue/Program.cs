using PriorityQueue.Helpers;
using System;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //MaxPQ<char> maxPQ = new MaxPQ<char>(11);
            IComparable[] temp = new IComparable[11];
            string temp2 = "SORTEXAMPLE";
            for (int i = 0; i < temp2.Length; i++)
            {
                temp[i] = temp2[i];
            }
            HeapSort heapSort = new HeapSort(temp);
            heapSort.Display();
        }
    }
}
