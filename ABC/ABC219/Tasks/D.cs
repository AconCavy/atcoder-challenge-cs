using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var (X, Y) = Scanner.Scan<int, int>();
            var AB = new (int A, int B)[N];
            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                AB[i] = (a, b);
            }

            var dp = new int[N + 1, X + 1, Y + 1];
            const int inf = (int)1e9;
            for (var i = 0; i <= N; i++)
            {
                for (var j = 0; j <= X; j++)
                {
                    for (var k = 0; k <= Y; k++)
                    {
                        dp[i, j, k] = inf;
                    }
                }
            }
            dp[0, 0, 0] = 0;
            for (var i = 0; i < N; i++)
            {
                var (a, b) = AB[i];

                for (var j = 0; j <= X; j++)
                {
                    for (var k = 0; k <= Y; k++)
                    {
                        dp[i + 1, j, k] = Math.Min(dp[i + 1, j, k], dp[i, j, k]);
                        var s = Math.Min(X, j + a);
                        var t = Math.Min(Y, k + b);
                        dp[i + 1, s, t] = Math.Min(dp[i + 1, s, t], dp[i, j, k] + 1);
                    }
                }
            }

            var answer = dp[N, X, Y];
            if (answer == inf) answer = -1;
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
