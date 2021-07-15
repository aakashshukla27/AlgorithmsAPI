using System;
using Tree.Helpers;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BST<int, string> bST = new BST<int, string>();
            bST.Put(1, "Hello");
            bST.Put(10, "ABC");

        }
    }
}
