using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class K
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
            var N = Scanner.Scan<int>();
            var T = new (int D, int C, long S)[N];
            for (var i = 0; i < N; i++)
            {
                var (d, c, s) = Scanner.Scan<int, int, long>();
                T[i] = (d, c, s);
            }

            Array.Sort(T, (x, y) => x.D.CompareTo(y.D));

            var dp = new long[N + 1, 5001];
            for (var i = 0; i < N; i++)
            {
                var (d, c, s) = T[i];
                for (var j = 0; j <= 5000; j++)
                {
                    dp[i + 1, j] = Math.Max(dp[i + 1, j], dp[i, j]);
                    if (j + c <= d) dp[i + 1, j + c] = Math.Max(dp[i + 1, j + c], dp[i, j] + s);
                }
            }

            var answer = 0L;
            for (var i = 0; i <= 5000; i++)
            {
                answer = Math.Max(answer, dp[N, i]);
            }

            Console.WriteLine(answer);
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
