using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.Helpers
{
    class PQ<Key> where Key : IComparable<Key>
    {
        private readonly List<Key> _pq;
        
        public void Enqueue(Key item)
        {
            _pq.Add(item);
            BubbleUp();
        }
        public Key Dequeue()
        {
            var item = _pq[0];
            MoveLastItemToTop();
            SinkDown();
            return item;
        }
        private void BubbleUp()
        {
            var childIndex = _pq.Count - 1;
            while(childIndex > 0)
            {
                var parentIndex = (childIndex - 1) / 2;
                if(_pq[childIndex].CompareTo(_pq[parentIndex]) >= 0)
                {
                    break;
                }
                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        private void MoveLastItemToTop()
        {
            var lastIndex = _pq.Count - 1;
            _pq[0] = _pq[lastIndex];
            _pq.RemoveAt(lastIndex);
        }

        private void SinkDown() // Implementation of the Min Heap Sink Down operation
        {
            var lastIndex = _pq.Count - 1;
            var parentIndex = 0;

            while (true)
            {
                var firstChildIndex = parentIndex * 2 + 1;
                if (firstChildIndex > lastIndex)
                {
                    break;
                }
                var secondChildIndex = firstChildIndex + 1;
                if (secondChildIndex <= lastIndex && _pq[secondChildIndex].CompareTo(_pq[firstChildIndex]) < 0)
                {
                    firstChildIndex = secondChildIndex;
                }
                if (_pq[parentIndex].CompareTo(_pq[firstChildIndex]) < 0)
                {
                    break;
                }
                Swap(parentIndex, firstChildIndex);
                parentIndex = firstChildIndex;
            }
        }

        private void Swap(int index1, int index2)
        {
            var tmp = _pq[index1];
            _pq[index1] = _pq[index2];
            _pq[index2] = tmp;
        }
    }
}
