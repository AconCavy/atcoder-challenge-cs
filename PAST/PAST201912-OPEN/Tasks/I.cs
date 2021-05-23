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
            var (N, M) = Scanner.Scan<int, int>();
            var S = new int[M];
            var C = new long[M];
            for (var i = 0; i < M; i++)
            {
                var (s, c) = Scanner.Scan<string, long>();
                var b = 0;
                for (var j = 0; j < N; j++)
                {
                    if (s[j] == 'Y') b |= 1 << j;
                }

                S[i] = b;
                C[i] = c;
            }

            const long inf = (long)1e18;

            var all = 1 << N;
            var dp = new long[M + 1, all];
            for (var i = 0; i <= M; i++)
            {
                for (var j = 0; j < all; j++)
                {
                    dp[i, j] = inf;
                }
            }

            dp[0, 0] = 0;

            for (var i = 0; i < M; i++)
            {
                var (s, c) = (S[i], C[i]);
                for (var j = 0; j < all; j++)
                {
                    dp[i + 1, j] = Math.Min(dp[i + 1, j], dp[i, j]);
                    dp[i + 1, j | s] = Math.Min(dp[i + 1, j | s], dp[i, j] + c);
                }
            }

            var answer = dp[M, all - 1];
            if (answer == inf) answer = -1;

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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
