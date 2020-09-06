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
            var F = new int[N][];
            var P = new int[N][];
            var answer = -(1 << 30);
            for (var i = 0; i < N; i++)
            {
                F[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            }
            for (var i = 0; i < N; i++)
            {
                P[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            }
            for (var bit = 1; bit < (1 << 10); bit++)
            {
                var sum = 0;
                for (var i = 0; i < P.Length; i++)
                {
                    var count = 0;
                    for (var j = 0; j < F[i].Length; j++)
                    {
                        if (((bit >> j) & 1) == 1 && F[i][j] == 1) count++;
                    }
                    sum += P[i][count];
                }
                answer = Math.Max(answer, sum);
            }

            Console.WriteLine(answer);
        }
    }
}
