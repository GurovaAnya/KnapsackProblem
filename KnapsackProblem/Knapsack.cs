using System;
using System.Collections.Generic;
using System.Text;

namespace KnapsackProblem
{
    /// <summary>
    /// Рюкзак
    /// </summary>
    class Knapsack
    {
        public Heap nodes; //Узлы дерева
        public List<Item> items; //Все предметы
        public int MaxCapacity { get; private set; } //Вместимость рюкзака
        public double Max { get; private set; } //Сумма стоимостей 

        /// <summary>
        /// Создание рюкзака
        /// </summary>
        /// <param name="maxCapacity"> Вместимость рюкзака</param>
        public Knapsack(int maxCapacity)
        {
            items = new List<Item>();
            nodes = new Heap();
            MaxCapacity = maxCapacity;
        }

        /// <summary>
        /// Добавление предмета в рюкзак
        /// </summary>
        /// <param name="item"> Предмет</param>
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Нахождение решения методом ветвей и границ
        /// </summary>
        /// <returns> Список предметов, вместившихся в рюкзак</returns>
        public List<Item> SolveProblem()
        {
            //Сортиируем по убыванию удельной стоимости
            items.Sort();
            items.Reverse();

            //Добавляем фикивный элемент, чтобы не было выхода за границы
            items.Add(new Item(-1, 1, -1));
            int currentLevel = -1; //текущий уровень

            //Добавляем нулевой узел, в котором не лежит ни одного предмета
            Node currentNode = new Node();

            //Пока не дойдем до предмета с последним приоритетом
            while (currentLevel < items.Count - 2)
            {
                WorkWithNode(currentNode);
                //Получаем максимальный узел и удаляем его из списка рабочих узлов
                currentNode = nodes.GetMaximum();
                nodes.Remove(currentNode);
                
                currentLevel = currentNode.Level;
            }
            Max = currentNode.Func;
            return currentNode.Items;
        }

        //Добавление левого и правого листа для узла 
        private void WorkWithNode(Node node)
        {
            //Берем предмет
            Node includeNode = new Node(node, items[node.Level + 1], items[node.Level + 2], MaxCapacity, true);
            if (includeNode.Func != -1)
                nodes.Add(includeNode);
            //Не берем предмет
            Node excludeNode = new Node(node, items[node.Level + 1], items[node.Level + 2], MaxCapacity, false);
            if (excludeNode.Func != -1)
                nodes.Add(excludeNode);

        }
    }
}
