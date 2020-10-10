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
            var (N, M, P) = Scanner.Scan<int, int, int>();
            var edges = new (int u, int v, long w)[M];
            for (var i = 0; i < M; i++)
            {
                var (a, b, c) = Scanner.Scan<int, int, long>();
                edges[i] = (a - 1, b - 1, c - P);
            }

            const long inf = (long)1e18;
            var coins = Enumerable.Repeat(-inf, N).ToArray();
            coins[0] = 0;
            var isLoop = new bool[N];
            for (var i = 0; i < N; i++)
            {
                foreach (var edge in edges)
                {
                    if (coins[edge.u] == -inf) continue;
                    var coin = coins[edge.u] + edge.w;
                    if (coins[edge.v] >= coin) continue;
                    coins[edge.v] = coin;
                    if (i == N - 1) isLoop[edge.v] = true;
                }
            }

            for (var i = 0; i < N; i++)
            {
                foreach (var edge in edges)
                {
                    if (!isLoop[edge.u]) continue;
                    isLoop[edge.v] = true;
                }
            }

            Console.WriteLine(isLoop[N - 1] ? -1 : Math.Max(0, coins[N - 1]));
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
