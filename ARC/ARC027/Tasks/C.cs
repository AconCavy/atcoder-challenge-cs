using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var (X, Y) = Scanner.Scan<int, int>();
            var N = Scanner.Scan<int>();
            var D = new (int T, long H)[N];
            for (var i = 0; i < N; i++)
            {
                var (t, h) = Scanner.Scan<int, long>();
                D[i] = (t, h);
            }

            var dp = new long[X + 1, X + Y + 1];
            for (var n = 0; n < N; n++)
            {
                var (t, h) = D[n];
                for (var x = X - 1; x >= 0; x--)
                {
                    for (var xy = 0; xy <= X + Y - t; xy++)
                    {
                        dp[x + 1, xy + t] = Math.Max(dp[x + 1, xy + t], dp[x, xy] + h);
                    }
                }
            }

            var answer = 0L;
            for (var i = 0; i <= X; i++)
                for (var j = 0; j <= X + Y; j++)
                    answer = Math.Max(answer, dp[i, j]);

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
