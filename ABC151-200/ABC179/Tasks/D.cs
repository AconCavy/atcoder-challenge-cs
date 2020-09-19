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
            var (N, K) = Scanner.Scan<int, int>();
            const int p = 998244353;
            var L = new int[K];
            var R = new int[K];
            for (var i = 0; i < K; i++)
            {
                var (l, r) = Scanner.Scan<int, int>();
                L[i] = l;
                R[i] = r + 1;
            }
            var dp = new long[N];
            dp[0] = 1;
            dp[1] = -1;
            for (var i = 0; i < N; i++)
            {
                if (i > 0)
                {
                    dp[i] += dp[i - 1];
                    dp[i] %= p;
                }
                for (var j = 0; j < K; j++)
                {
                    var (l, r) = (L[j], R[j]);
                    if (i + l < N)
                    {
                        dp[i + l] += dp[i];
                        dp[i + l] %= p;
                    }
                    if (i + r < N)
                    {
                        dp[i + r] -= dp[i];
                        if (dp[i + r] < 0) dp[i + r] += p;
                        dp[i + r] %= p;
                    }
                }
            }

            Console.WriteLine(dp[N - 1]);
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
