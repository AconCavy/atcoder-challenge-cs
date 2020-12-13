using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var (N, M) = Scanner.Scan<int, int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var B = Scanner.ScanEnumerable<int>().ToArray();
            const int inf = (int)1e9;
            var dp = new int[N + 1].Select(_ => Enumerable.Repeat(inf, M + 1).ToArray()).ToArray();
            for (var i = 0; i <= N; i++) dp[i][0] = i;
            for (var i = 0; i <= M; i++) dp[0][i] = i;

            for (var i = 1; i <= N; i++)
            {
                for (var j = 1; j <= M; j++)
                {
                    dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j] + 1);
                    dp[i][j] = Math.Min(dp[i][j], dp[i][j - 1] + 1);
                    dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j - 1] + (A[i - 1] != B[j - 1] ? 1 : 0));
                }
            }

            Console.WriteLine(dp[N][M]);
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
