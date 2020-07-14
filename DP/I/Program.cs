using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace I
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
            var P = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            var dp = new double[N + 1][].Select(x => x = new double[N + 1]).ToArray();
            dp[0][0] = 1;
            for (var i = 0; i < N; i++)
            {
                var p = P[i];
                var q = 1 - p;
                for (var j = 0; j <= i; j++)
                {
                    dp[i + 1][j + 1] += dp[i][j] * p;
                    dp[i + 1][j] += dp[i][j] * q;
                }
            }
            var answer = 0d;
            for (var i = N / 2 + 1; i <= N; i++)
            {
                answer += dp[N][i];
            }

            Console.WriteLine(answer);
        }
    }
}
