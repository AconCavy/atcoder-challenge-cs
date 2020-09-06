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
            var NM = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var N = NM[0];
            var M = NM[1];
            var answer = 0L;
            if (N == 1 || M == 1)
            {
                answer = N == M ? 1 : N * M - 2;
            }
            else
            {
                var edge = 2 * (N + M - 2);
                answer = N * M - edge;
            }

            Console.WriteLine(answer);
        }
    }
}
