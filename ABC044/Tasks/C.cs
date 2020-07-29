using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var NA = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, A) = (NA[0], NA[1]);
            var X = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var max = Math.Max(A, X.Max());
            var answer = 0L;

            var dp = new long[N + 1][][].Select(
                x => x = new long[N + 1][].Select(
                    y => y = new long[N * max + 1]).ToArray()).ToArray();
            dp[0][0][0] = 1;
            for (var j = 1; j <= N; j++)
            {
                for (var k = 0; k <= N; k++)
                {
                    for (var s = 0; s <= N * max; s++)
                    {
                        var xj = X[j - 1];
                        if (s < xj)
                            dp[j][k][s] = dp[j - 1][k][s];
                        else if (s >= xj && k > 0)
                            dp[j][k][s] = dp[j - 1][k][s] + dp[j - 1][k - 1][s - xj];
                    }
                }
            }

            for (var k = 1; k <= N; k++)
            {
                answer += dp[N][k][k * A];
            }
            Console.WriteLine(answer);
        }
    }
}
