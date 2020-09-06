using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
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
            var (R, C, K) = Scanner.Scan<int, int, long>();
            var dp = new long[R + 1][][]
            .Select(x => x = new long[C + 1][]
            .Select(x => x = new long[4])
            .ToArray())
            .ToArray();

            var V = new long[R + 1][].Select(x => x = new long[C + 1]).ToArray();
            for (var i = 0; i < K; i++)
            {
                var (r, c, v) = Scanner.Scan<int, int, long>();
                V[r][c] = v;
            }

            for (var i = 1; i <= R; i++)
            {
                for (var j = 1; j <= C; j++)
                {
                    for (var k = 0; k <= 3; k++)
                    {
                        dp[i][j][k] = Math.Max(dp[i][j - 1][k], dp[i - 1][j][3]);
                        if (k > 0)
                        {
                            var tmp = Math.Max(dp[i][j - 1][k - 1], dp[i - 1][j][3]) + V[i][j];
                            dp[i][j][k] = Math.Max(dp[i][j][k], tmp);
                        }
                    }
                }
            }

            Console.WriteLine(dp[R][C][3]);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
        }
    }
}
