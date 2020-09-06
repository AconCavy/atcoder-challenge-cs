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
            var X = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            var ordered = X.Select((x, i) => new { Value = x, Index = i }).OrderBy(x => x.Value).ToArray();
            var mid1 = ordered[N / 2].Value;
            var mid2 = ordered[N / 2 - 1].Value;
            var answer = new int[N];
            for (var i = 0; i < ordered.Length; i++)
            {
                answer[ordered[i].Index] = (i < N / 2) ? mid1 : mid2;
            }
            Console.WriteLine(string.Join("\n", answer));
        }
    }
}