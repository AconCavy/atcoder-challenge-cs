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
            var (N, M) = Scanner.Scan<int, int>();
            var G = new List<int>[N + 1].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (u, v) = Scanner.Scan<int, int>();
                G[u].Add(v);
            }
            var (S, T) = Scanner.Scan<int, int>();
            const int inf = (int)1e9;
            var depths = new int[N + 1][].Select(_ => new[] { inf, inf, inf }).ToArray();
            depths[S][0] = 0;
            var queue = new Queue<(int current, int step)>();
            queue.Enqueue((S, 0));
            while (queue.Any())
            {
                var (u, s) = queue.Dequeue();
                var ns = (s + 1) % 3;
                foreach (var v in G[u])
                {
                    if (depths[v][ns] != inf) continue;
                    depths[v][ns] = depths[u][s] + 1;
                    queue.Enqueue((v, ns));
                }
            }

            Console.WriteLine(depths[T][0] == inf ? -1 : depths[T][0] / 3);
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
