using System;
using System.Collections.Generic;
using System.Text;

namespace KnapsackProblem
{
    /// <summary>
    /// Листа дерева
    /// </summary>
    class Node
    {
        public List<Item> Items { get; set; }
        public double Price { get; set; }
        public double Mass { get; set; }
        public int Level { get; set; }
        public double Func { get; private set; }

        /// <summary>
        /// Создание первого элемента
        /// </summary>
        public Node()
        {
            Items = new List<Item>();
            Price = 0;
            Mass = 0;
            Func = -1;
            Level = -1;
        }

        /// <summary>
        /// Создание элемента
        /// </summary>
        /// <param name="descendant"> Родительский узел</param>
        /// <param name="currentItem"> Добавляемый предмет </param>
        /// <param name="nextItem"> Следующий за проверяемым предмет (по приоритету) </param>
        /// <param name="MaxCapacity"> Вместимость рюкзака</param>
        /// <param name="addItem">Добавить/не добавить предмет</param>
        public Node(Node descendant, Item currentItem, Item nextItem, int MaxCapacity, bool addItem)
        {
            Items = new List<Item>(descendant.Items);
            Level = descendant.Level + 1;
            //Если добавляем предмет, то включаем стоимость и массу
            if (addItem)
            {
                Items.Add(currentItem);
                Price = descendant.Price + currentItem.Price;
                Mass = descendant.Mass + currentItem.Mass;
            }
            //Если не добавляем предмет, то масса и стоимость наследуется от предыдущего узла
            else
            {
                Price = descendant.Price;
                Mass = descendant.Mass;
            }
            if (Mass <= MaxCapacity)
                Func = Price + (MaxCapacity - Mass) * nextItem.RelativePrice;
            else 
                Func = -1;
        }
    }
}
