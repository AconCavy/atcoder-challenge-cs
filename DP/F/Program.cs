using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace F
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
            var S = Console.ReadLine();
            var T = Console.ReadLine();
            var dp = (new int[S.Length + 1][]).Select(x => x = new int[T.Length + 1]).ToArray();
            for (var i = 0; i < S.Length; i++)
            {
                for (var j = 0; j < T.Length; j++)
                {
                    if (S[i] == T[j])
                    {
                        dp[i + 1][j + 1] = dp[i][j] + 1;
                    }
                    else
                    {
                        dp[i + 1][j + 1] = Math.Max(dp[i][j + 1], dp[i + 1][j]);
                    }
                }
            }
            // Console.WriteLine(string.Join("\n", dp.Select(x => string.Join(" ", x))));
            var answer = "";
            var si = S.Length;
            var ti = T.Length;
            while (si > 0 || ti > 0)
            {
                var x = dp[si][ti];
                if (si > 0 && dp[si - 1][ti] == x) si--;
                else if (ti > 0 && dp[si][ti - 1] == x) ti--;
                else
                {
                    si--;
                    ti--;
                    answer = S[si] + answer;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
