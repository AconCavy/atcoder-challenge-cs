using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var HW = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var H = HW[0];
            var W = HW[1];
            var costs = new int[10][];
            for (var i = 0; i < costs.Length; i++)
            {
                costs[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            }
            costs[1][1] = 0;

            for (var k = 0; k < 10; k++)
            {
                for (var i = 0; i < 10; i++)
                {
                    for (var j = 0; j < 10; j++)
                    {
                        if (costs[i][j] > costs[i][k] + costs[k][j])
                            costs[i][j] = costs[i][k] + costs[k][j];
                    }
                }
            }

            var answer = 0;
            for (var i = 0; i < H; i++)
            {
                var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                for (var j = 0; j < A.Length; j++)
                {
                    if (A[j] >= 0) answer += costs[A[j]][1];
                }
            }
            Console.WriteLine(answer);
        }
    }
}
