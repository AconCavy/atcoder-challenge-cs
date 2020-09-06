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
            var W = Scanner.Scan<int>();
            var (N, K) = Scanner.Scan<int, int>();
            var A = new int[N];
            var B = new int[N];
            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                A[i] = a;
                B[i] = b;
            }

            var dp = new int[2][][].Select(x => new int[W + 1][].Select(y => new int[K + 1]).ToArray()).ToArray();
            var t = 1;
            for (var i = 0; i < N; i++)
            {
                t ^= 1;
                for (var j = 0; j <= W; j++)
                {
                    for (var k = 0; k <= K; k++)
                    {
                        dp[t ^ 1][j][k] = Math.Max(dp[t ^ 1][j][k], dp[t][j][k]);
                        if (j >= A[i] && k < K)
                            dp[t ^ 1][j][k] = Math.Max(dp[t ^ 1][j][k], dp[t][j - A[i]][k + 1] + B[i]);
                    }
                }
            }

            var answer = 0;
            t ^= 1;
            for (var i = 0; i < K; i++)
            {
                answer = Math.Max(answer, dp[t][W][i]);
            }

            Console.WriteLine(answer);
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
