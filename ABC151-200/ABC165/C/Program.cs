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
            var nmq = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var q = new IntegerPair[nmq[2]];
            for (var i = 0; i < nmq[2]; i++)
            {
                var abcd = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                q[i] = new IntegerPair { A = abcd[0], B = abcd[1], C = abcd[2], D = abcd[3] };
            }

            var max = 0;
            void Dfs(IEnumerable<int> items)
            {
                var list = items.ToList();
                if (items.Count() == nmq[0])
                {
                    var current = 0;
                    current = q.Where(x => list[x.B - 1] - list[x.A - 1] == x.C).Sum(x => x.D);
                    max = Math.Max(max, current);
                    return;
                }

                var last = list.LastOrDefault();
                list.Add(last != 0 ? last : 1);
                while (list.LastOrDefault() <= nmq[1])
                {
                    Dfs(list);
                    list[list.Count() - 1]++;
                }
            }

            Dfs(new int[] { 1 });
            Console.WriteLine(max);
        }

        public struct IntegerPair
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
            public int D { get; set; }

        }
    }
}
