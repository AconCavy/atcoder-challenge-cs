using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var NK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, K) = (NK[0], NK[1]);
            var H = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var dp = Enumerable.Repeat((int)1e9, N + 1).ToArray();
            dp[0] = 0;
            for (var i = 0; i < N; i++)
            {
                for (var k = 1; k <= K; k++)
                {
                    if (i + k < N) dp[i + k] = Math.Min(dp[i + k], dp[i] + Math.Abs(H[i] - H[i + k]));
                }
            }

            Console.WriteLine(dp[N - 1]);
        }
    }
}
