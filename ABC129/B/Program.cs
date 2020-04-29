using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var n = int.Parse(Console.ReadLine());
            var wi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var min = 100;
            var aggregated = new int[n + 1];
            for (var i = 1; i <= wi.Length; i++)
            {
                aggregated[i] = wi[i - 1] + aggregated[i - 1];
            }

            var index = 0;
            while (true)
            {
                var left = aggregated[index];
                var right = aggregated[aggregated.Length - 1] - aggregated[index];
                min = Math.Min(min, Math.Abs(right - left));
                if (left >= right) break;
                index++;
            }
            Console.WriteLine(min);
        }
    }
}
