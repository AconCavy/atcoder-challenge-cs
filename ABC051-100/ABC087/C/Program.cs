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
            var A1 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var A2 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = 0;
            var aggA1 = new int[N + 1];
            for (var i = 0; i < A1.Length; i++) aggA1[i + 1] = A1[i] + aggA1[i];
            var aggA2 = new int[N + 1];
            for (var i = 0; i < A2.Length; i++) aggA2[i + 1] = A2[i] + aggA2[i];

            for (var i = 0; i < N; i++)
            {
                var a1 = aggA1[i + 1] - aggA1[0];
                var a2 = aggA2[N] - aggA2[i];
                answer = Math.Max(answer, a1 + a2);
            }
            Console.WriteLine(answer);
        }
    }
}
