using Stack.Helpers;
using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            DijkstraTwoStack stack = new DijkstraTwoStack("(1+(2+3))");
            Console.WriteLine(stack.returnValue());
        }
    }
}
