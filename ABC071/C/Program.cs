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
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var answer = 0L;
            var dict = new Dictionary<long, long>();
            for (var i = 0; i < A.Length; i++)
            {
                if (dict.ContainsKey(A[i])) dict[A[i]]++;
                else dict[A[i]] = 1;
            }
            var edges = dict.Where(x => x.Value > 1).OrderByDescending(x => x.Key).ToArray();
            if (edges.Length > 0)
            {
                if (edges[0].Value >= 4) answer = edges[0].Key * edges[0].Key;
                else if (edges[0].Value > 1 && edges[1].Value > 1) answer = edges[0].Key * edges[1].Key;
            }
            Console.WriteLine(answer);
        }
    }
}
