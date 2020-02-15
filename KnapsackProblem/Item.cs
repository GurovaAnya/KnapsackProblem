using System;
using System.Collections.Generic;
using System.Text;

namespace KnapsackProblem
{
    /// <summary>
    /// Предметы
    /// </summary>
    class Item:IComparable<Item>
    {
        public int Number { get; private set; }
        public int Mass { get; private set; }
        public int Price { get; private set; }
        public double RelativePrice { get; private set; } //Удельная масса

        /// <summary>
        /// Создание предмета
        /// </summary>
        /// <param name="number">Порядковый номер предмета</param>
        /// <param name="mass"> Масса предмета</param>
        /// <param name="price"> Стоимость предмета</param>
        public Item(int number, int mass, int price)
        {
            Number = number;
            Mass = mass;
            Price = price;
            RelativePrice = (double)price / mass;
        }

        //Сравнение по удельной цене
        int IComparable<Item>.CompareTo(Item other)
        {
            return RelativePrice.CompareTo(other.RelativePrice);
        }
    }
}
