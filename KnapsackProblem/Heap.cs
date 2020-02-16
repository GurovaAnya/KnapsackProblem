using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnapsackProblem
{
    // Здесь будет куча!
    class Heap
    {
        private List<Node> heap;

        public int HeapSize
        {
            get
            {
                return heap.Count;
            }
        }

        public Heap()
        {
            heap = new List<Node>();
        }

        public void Add(Node value)
        {
            heap.Add(value);
            int i = HeapSize - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && heap[parent].Func < heap[i].Func)
            {
                Node temp = heap[i];
                heap[i] = heap[parent];
                heap[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public void Heapify(int i)
        {
            int leftChild;
            int rightChild;
            int largestChild;

            for (; ; )
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;

                if (leftChild < HeapSize && heap[leftChild].Func > heap[largestChild].Func)
                {
                    largestChild = leftChild;
                }

                if (rightChild < HeapSize && heap[rightChild].Func > heap[largestChild].Func )
                {
                    largestChild = rightChild;
                }

                if (largestChild == i)
                {
                    break;
                }

                Node temp = heap[i];
                heap[i] = heap[largestChild];
                heap[largestChild] = temp;
                i = largestChild;
            }
        }

        public Node GetMaximum()
        {
            Node result = heap[0];
            heap[0] = heap[HeapSize - 1];
            heap.RemoveAt(HeapSize - 1);
            Heapify(0);
            return result;
        }

        public bool Remove(Node node)
        {
            return heap.Remove(node);
        }
    }
}
