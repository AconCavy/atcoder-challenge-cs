using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace J
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
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var counts = new int[3];
            for (var i = 0; i < A.Length; i++)
            {
                counts[A[i] - 1]++;
            }
            var ep = 1.0 / N;
            var dp = new double[N + 1, N + 1, N + 1];
            for (var k = 0; k <= N; k++)
            {
                for (var j = 0; j <= N; j++)
                {
                    for (var i = 0; i <= N; i++)
                    {
                        var z = N - i - j - k;
                        if (z < 0) break;
                        if (z == N) continue;
                        var x = 1 - z * ep;
                        if (i > 0) dp[i, j, k] += dp[i - 1, j, k] * i * ep;
                        if (j > 0) dp[i, j, k] += dp[i + 1, j - 1, k] * j * ep;
                        if (k > 0) dp[i, j, k] += dp[i, j + 1, k - 1] * k * ep;
                        dp[i, j, k] += 1;
                        dp[i, j, k] /= x;
                    }
                }
            }

            Console.WriteLine(dp[counts[0], counts[1], counts[2]]);
        }
    }
}
