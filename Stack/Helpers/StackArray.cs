﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Stack.Helpers
{
    class StackArray
    {
        private readonly int[] stack;
        private int length;
        private int top;
        public StackArray(int n)
        {
            length = n;
            stack = new int[n];
            top = -1;
        }

        public bool IsEmpty()
        {
            return top < 0;
        }
        public bool Push(int n)
        {
            if (top >= length)
            {
                Console.WriteLine("Stack Overflow");
                return false;
            }
            else
            {
                stack[++top] = n;
                return true;
            }
        }

        public int Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }
            else
            {
                return stack[top--];
            }
        }

        public int Peek()
        {
            if(top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }
            else
            {
                return stack[top];
            }
        }


    }
}
