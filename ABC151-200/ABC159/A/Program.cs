using System;
using System.Linq;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var even = nm[0];
            var odd = nm[1];
            Func<int, int> func = n => n * (n - 1) / 2;

            Console.WriteLine(func(even) + func(odd));
        }
    }
}
