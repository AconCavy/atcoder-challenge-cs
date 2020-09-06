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
            var NT = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, T) = (NT[0], NT[1]);
            var t = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            t.Add(t[N - 1] + T);
            var answer = 0L;
            for (var i = 1; i < t.Count; i++)
            {
                answer += Math.Min(T, t[i] - t[i - 1]);
            }

            Console.WriteLine(answer);
        }
    }
}
