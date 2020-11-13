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
            var (N, M) = Scanner.Scan<int, int>();
            var edges = new (int U, int V, long S)[M];
            for (var i = 0; i < M; i++)
            {
                var (A, B, C) = Scanner.Scan<int, int, long>();
                edges[i] = (A - 1, B - 1, -C);
            }

            var Inf = (long)1e18;
            var scores = Enumerable.Repeat(Inf, N).ToArray();
            scores[0] = 0;
            for (var loop = 0; loop < N - 1; loop++)
            {
                for (var i = 0; i < M; i++)
                {
                    var u = edges[i].U;
                    var v = edges[i].V;
                    var s = edges[i].S;
                    if (scores[u] == Inf) continue;
                    if (scores[v] > scores[u] + s) scores[v] = scores[u] + s;
                }
            }
            var answer = scores[N - 1];

            var negative = new bool[N];
            for (var loop = 0; loop < N; loop++)
            {
                for (var i = 0; i < M; i++)
                {
                    var u = edges[i].U;
                    var v = edges[i].V;
                    var s = edges[i].S;
                    if (scores[u] == Inf) continue;

                    if (scores[v] > scores[u] + s)
                    {
                        scores[v] = scores[u] + s;
                        negative[v] = true;
                    }

                    if (negative[u]) negative[v] = true;
                }
            }

            Console.WriteLine(negative[N - 1] ? "inf" : (-answer).ToString());
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
