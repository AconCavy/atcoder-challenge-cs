using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E
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
            var NW = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, W) = (NW[0], NW[1]);
            var w = new int[N];
            var v = new int[N];
            var maxV = 0;
            for (var i = 0; i < N; i++)
            {
                var wv = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                (w[i], v[i]) = (wv[0], wv[1]);
                maxV = Math.Max(maxV, v[i]);
            }

            const long Infinity = (long)1e18;
            var dp = (new long[2][]).Select(x => x = Enumerable.Repeat(Infinity, N * maxV + 1).ToArray()).ToArray();
            dp[0][0] = 0;
            var t = 1;
            for (var i = 0; i < N; i++)
            {
                t ^= 1;
                for (var j = 0; j <= N * maxV; j++)
                {
                    if (j < v[i]) dp[t ^ 1][j] = dp[t][j];
                    else dp[t ^ 1][j] = Math.Min(dp[t][j], dp[t][j - v[i]] + w[i]);
                }
            }

            // Console.WriteLine(string.Join("\n", dp.Select(x => string.Join(" ", x))));
            var answer = 0L;
            for (var i = 0; i <= N * maxV; i++)
            {
                var val = dp[t ^ 1][i];
                if (val <= W) answer = i;
            }

            Console.WriteLine(answer);
        }
    }
}
