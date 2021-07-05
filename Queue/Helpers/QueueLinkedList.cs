using System;
using System.Collections.Generic;
using System.Text;

namespace Queue.Helpers
{
    class QueueLinkedList
    {
        LinkedList<int> queue;

        public QueueLinkedList()
        {
            queue = new LinkedList<int>();
        }

        public void Enqueue(int n)
        {
            queue.AddLast(n);            
        }

        public int Dequeue()
        {
            int temp = queue.Last.Value;
            queue.RemoveLast();
            return temp;
        }





    }
}
