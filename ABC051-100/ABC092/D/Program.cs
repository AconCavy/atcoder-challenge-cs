using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var AB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var A = AB[0];
            var B = AB[1];
            var max = Math.Max(A, B);
            var min = Math.Min(A, B);
            var cmin = (A < B) ? '.' : '#';
            var cmax = (A < B) ? '#' : '.';

            Console.WriteLine($"2 {max * 2}");
            for (var i = 0; i < max; i++)
            {
                Console.Write(cmin);
                Console.Write(cmax);
            }
            Console.WriteLine();
            for (var i = 0; i < max; i++)
            {
                Console.Write(cmin);
                Console.Write(i < min - 1 ? cmax : cmin);
            }
        }
    }
}
