using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Knapsack knapsack = new Knapsack(12);
            knapsack.AddItem(new Item(1, 4, 8));
            knapsack.AddItem(new Item(2, 8, 13));
            knapsack.AddItem(new Item(3, 4, 9));
            knapsack.AddItem(new Item(4, 4, 7));
            knapsack.AddItem(new Item(5, 6, 12));
            List<Item> answer= knapsack.SolveProblem();
            Console.WriteLine(knapsack.Max);
            foreach (Item it in answer)
                Console.WriteLine(it.Number);
        }
    }
}
