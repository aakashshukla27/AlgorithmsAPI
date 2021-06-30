using Stack.Helpers;
using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            //StackArray stackArray = new StackArray(100);
            //Random rnd = new Random(0);
            //for (int i = 0; i < 100; i++)
            //{
            //    stackArray.Push(rnd.Next(0, 100));
            //}
            //Console.WriteLine("Peek:" + stackArray.Peek().ToString());

            //stackArray.Pop();

            //Console.WriteLine("Peek:" + stackArray.Peek().ToString());

            StackLinkedList stackLinkedList = new StackLinkedList();
            stackLinkedList.Push(10);
            stackLinkedList.Push(100);
            Console.WriteLine("Peek: " + stackLinkedList.Peek().ToString());
            stackLinkedList.Pop();
            Console.WriteLine("Peek: " + stackLinkedList.Peek().ToString());

        }
    }
}
