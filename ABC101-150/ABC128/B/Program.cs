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
            var reviews = new Tuple<string, int>[n];
            for (var i = 0; i < n; i++)
            {
                var sp = Console.ReadLine().Trim().Split(' ');
                reviews[i] = new Tuple<string, int>(sp[0], int.Parse(sp[1]));
            }
            var indexed = reviews.Select((x, i) => new { Value = x, Index = i + 1 })
            .OrderBy(x => x.Value.Item1)
            .ThenByDescending(x => x.Value.Item2)
            .ToArray();

            for (var i = 0; i < indexed.Length; i++)
            {
                Console.WriteLine(indexed[i].Index);
            }
        }
    }
}
