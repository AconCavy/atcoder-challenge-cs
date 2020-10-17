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
            var N = Scanner.Scan<int>();
            var P = new (int X, int Y, int Z)[N];
            for (var i = 0; i < N; i++)
            {
                var (X, Y, Z) = Scanner.Scan<int, int, int>();
                P[i] = (X, Y, Z);
            }

            static long GetCost((int X, int Y, int Z) from, (int X, int Y, int Z) to)
            {
                long x = Math.Abs(to.X - from.X);
                long y = Math.Abs(to.Y - from.Y);
                long z = Math.Max(0, to.Z - from.Z);
                return x + y + z;
            }

            var dp = new long[1 << N][].Select(_ => Enumerable.Repeat((long)1e18, N).ToArray()).ToArray();
            dp[0][0] = 0;
            for (var b = 0; b < 1 << N; b++)
            {
                for (var i = 0; i < N; i++)
                {
                    if ((b >> i & 1) == 0) continue;
                    for (var j = 0; j < N; j++)
                    {
                        dp[b][i] = Math.Min(dp[b][i], dp[b - (1 << i)][j] + GetCost(P[i], P[j]));
                    }
                }
            }

            Console.WriteLine(dp[^1][0]);
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
