using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var N = long.Parse(Console.ReadLine());
            var p = (int)1e9 + 7;
            var dp = new int[61][].Select(x => x = new int[3]).ToArray();
            dp[60][0] = 1;
            for (var i = 59; i >= 0; i--)
            {
                for (var j = 0; j <= 2; j++)
                {
                    var u = (N >> i) & 1;
                    if (j * 2 - 2 + u >= 0)
                    {
                        var j11 = Math.Min(2, j * 2 - 2 + u);
                        dp[i][j11] += dp[i + 1][j];
                        dp[i][j11] %= p;
                    }

                    if (j * 2 - 1 + u >= 0)
                    {
                        var j01 = Math.Min(2, j * 2 - 1 + u);
                        dp[i][j01] += dp[i + 1][j];
                        dp[i][j01] %= p;
                    }

                    var j00 = Math.Min(2, j * 2 + u);
                    dp[i][j00] += dp[i + 1][j];
                    dp[i][j00] %= p;
                }
            }

            var answer = 0L;
            for (var i = 0; i <= 2; i++)
            {
                answer += dp[0][i];
                answer %= p;
            }
            Console.WriteLine(answer);
        }
    }
}
