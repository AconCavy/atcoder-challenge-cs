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
            var NMaMb = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, Ma, Mb) = (NMaMb[0], NMaMb[1], NMaMb[2]);
            var ABC = new (int A, int B, int C)[N];
            (int A, int B, int C) sum = (0, 0, 0);
            for (var i = 0; i < N; i++)
            {
                var abc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var (a, b, c) = (abc[0], abc[1], abc[2]);
                ABC[i] = (a, b, c);
                sum = (sum.A + a, sum.B + b, sum.C + c);
            }

            var dp = new int[2][][];
            var Infinity = (int)1e9;
            var inst = Enumerable.Repeat(Infinity, sum.B + 1);
            for (var i = 0; i < 2; i++)
            {
                dp[i] = new int[sum.A + 1][].Select(x => x = inst.ToArray()).ToArray();
            }
            dp[0][0][0] = 0;
            var t = 1;
            for (var i = 0; i < N; i++)
            {
                t ^= 1;
                for (var a = 0; a <= sum.A; a++)
                {
                    for (var b = 0; b <= sum.B; b++)
                    {
                        if (dp[t][a][b] == Infinity) continue;
                        dp[t ^ 1][a][b] = Math.Min(dp[t ^ 1][a][b], dp[t][a][b]);
                        dp[t ^ 1][a + ABC[i].A][b + ABC[i].B] = Math.Min(dp[t ^ 1][a + ABC[i].A][b + ABC[i].B], dp[t][a][b] + ABC[i].C);
                    }
                }
            }

            var answer = Infinity;
            t ^= 1;
            for (var a = 1; a <= sum.A; a++)
            {
                for (var b = 1; b <= sum.B; b++)
                {
                    if (a * Mb == b * Ma) answer = Math.Min(answer, dp[t][a][b]);
                }
            }
            if (answer == Infinity) answer = -1;

            Console.WriteLine(answer);
        }
    }
}
