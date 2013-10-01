using System;
using Collections;

namespace Laba_6_ISP___Set
{
    static class Program
    {
        static void Main()
        {
            var s1 = new Set<int>();
            s1.Added += (sender, args) => Console.WriteLine("Добавлено: " + args);
            s1.Add(8,2,9);
            var ss1 = new SortedSet<int>(2, 5, 7, 4);
            Console.WriteLine("The first SortedSet: " + ss1);
            Console.WriteLine("Приведённое:" + (Set<int>)ss1);
            var ss2 = new SortedSet<int>(2, 9, 7, 4);
            Console.WriteLine("The second SortedSet: " + ss2);
            Console.WriteLine("Intersection: " + ss1.Intersect(ss2));
            Console.WriteLine("Union: " + ss1.Union(ss2));
            Console.WriteLine("Is the first SortedSet contain " + 5 + ": " + ss1.Contains(5));
            Console.ReadKey();
        }
    }
}