using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class I
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (H, W) = Scanner.Scan<int, int>();
            var A = new long[H][];
            for (var i = 0; i < H; i++)
            {
                A[i] = Scanner.ScanEnumerable<long>().ToArray();
            }

            var dp = new long[H + 1, W + 1, H + W];
            for (var i = 1; i <= H; i++)
            {
                for (var j = 1; j <= W; j++)
                {
                    var a = A[i - 1][j - 1];
                    for (var k = 0; k < H + W; k++)
                    {
                        dp[i, j, k] = Math.Max(dp[i, j, k], dp[i - 1, j, k]);
                        dp[i, j, k] = Math.Max(dp[i, j, k], dp[i, j - 1, k]);
                        if (k + 1 < H + W)
                        {
                            dp[i, j, k + 1] = Math.Max(dp[i, j, k + 1], dp[i - 1, j, k] + a);
                            dp[i, j, k + 1] = Math.Max(dp[i, j, k + 1], dp[i, j - 1, k] + a);
                        }
                    }
                }
            }

            for (var i = 1; i < H + W; i++)
            {
                Console.WriteLine(dp[H, W, i]);
            }
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
