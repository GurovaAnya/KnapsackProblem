using System;
using System.Collections.Generic;
using System.Text;

namespace KnapsackProblem
{
    /// <summary>
    /// Здесь будет куча!
    /// </summary>
    class Heap
    {
        public List<Node> heap;

        public Heap()
        {
            heap = new List<Node>();
        }

        //Добавление элемента
        public void Add(Node node)
        {
            heap.Add(node);
        }

        //нахождение элемента с максимальной оценкой (Func). Желательно, чтобы возвращал с максимальным значением уровня (Level)
        public Node GetMaximum()
        {
            Node max = heap[0];
            for (int i = 1; i < heap.Count; i++)
                if (heap[i].Func > max.Func)
                    max = heap[i];
            return max;
        }

        //Удаление элемента
        public bool Remove(Node node)
        {
            return heap.Remove(node);
        }

    }
}
