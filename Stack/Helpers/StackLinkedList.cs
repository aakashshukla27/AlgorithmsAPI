using System;
using System.Collections.Generic;
using System.Text;

namespace Stack.Helpers
{
    class StackLinkedList
    {
        public Node head;

        public bool IsEmpty()
        {
            if(head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public class Node
        {
            public int data;
            public Node next;

            public Node(int d)
            {
                this.data = d;
                this.next = null;
            }
        }

        public void Push(int d)
        {
            if(head == null)
            {
                head = new Node(d);                
            }
            else
            {
                Node temp = new Node(d);
                temp.next = head;
                head = temp;
            }
        }

        public int Pop()
        {
            if(head == null)
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }
            else
            {
                int temp = head.data;
                head = head.next;
                return temp;
            }
           
        }

        public int Peek()
        {
            if(head == null)
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }
            else
            {
                return head.data;
            }
        }
    }
}
