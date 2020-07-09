using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var over3200 = 0;
            var checker = new bool[8];
            for (var i = 0; i < A.Length; i++)
            {
                var rate = A[i] / 400;
                if (rate < 8) checker[rate] = true;
                else over3200++;
            }
            var min = checker.Count(x => x);
            if (min == 0 && over3200 > 0)
            {
                min = 1;
                over3200--;
            }
            var max = min + over3200;

            Console.WriteLine($"{min} {max}");
        }
    }
}
