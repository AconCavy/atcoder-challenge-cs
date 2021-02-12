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
            var (N, W) = Scanner.Scan<int, int>();
            var X = new (int W, int V)[N];
            for (var i = 0; i < N; i++)
            {
                var (w, v) = Scanner.Scan<int, int>();
                X[i] = (w, v);
            }

            var max = N * (int)1e3;
            const long inf = (long)1e18;
            var dp = new long[2][].Select(_ => new long[max + 1]).ToArray();
            Array.Fill(dp[0], inf);
            Array.Fill(dp[1], inf);
            dp[0][0] = 0;
            var t = 1;
            for (var i = 0; i < N; i++)
            {
                t ^= 1;
                var (w, v) = X[i];
                for (var j = 0; j <= max; j++)
                {
                    if (j < v) dp[t ^ 1][j] = dp[t][j];
                    else dp[t ^ 1][j] = Math.Min(dp[t][j], dp[t][j - v] + w);
                }
            }

            var answer = 0;
            t ^= 1;
            for (var i = 0; i <= max; i++)
            {
                if (dp[t][i] <= W) answer = i;
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
