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
            var (N, M, R, T) = Scanner.Scan<int, int, int, int>();
            var G = new List<Edge>[N].Select(_ => new List<Edge>(M / 2)).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (a, b, c) = Scanner.Scan<int, int, long>();
                a--; b--;
                G[a].Add(new Edge(b, c));
                G[b].Add(new Edge(a, c));
            }

            const long inf = (long)1e18;
            var queue = new Queue<Edge>();
            var depths = new long[N];
            var answer = 0L;
            for (var a = 0; a < N; a++)
            {
                queue.Enqueue(new Edge(a, 0));
                Array.Fill(depths, inf);
                depths[a] = 0;
                var inq = new bool[N];
                while (queue.Count > 0)
                {
                    var u = queue.Dequeue();
                    inq[u.Idx] = false;
                    foreach (var v in G[u.Idx])
                    {
                        if (depths[v.Idx] <= depths[u.Idx] + v.Cost) continue;
                        depths[v.Idx] = depths[u.Idx] + v.Cost;
                        if (inq[v.Idx]) continue;
                        inq[v.Idx] = true;
                        queue.Enqueue(v);
                    }
                }

                Array.Sort(depths);
                for (var c = 1; c < N; c++)
                {
                    var (l, r) = (-1, N);
                    while (r - l > 1)
                    {
                        var m = l + (r - l) / 2;
                        if (depths[m] * T > depths[c] * R) r = m;
                        else l = m;
                    }
                    answer += N - r;
                    if (r <= c) answer--;
                }
            }

            Console.WriteLine(answer);
        }

        public readonly struct Edge
        {
            public readonly int Idx;
            public readonly long Cost;
            public Edge(int v, long cost) => (Idx, Cost) = (v, cost);
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
