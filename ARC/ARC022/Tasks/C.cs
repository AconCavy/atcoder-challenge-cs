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
            var N = Scanner.Scan<int>();
            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            var E = new int[N];
            for (var i = 0; i < N - 1; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--; b--;
                G[a].Add(b);
                G[b].Add(a);
                E[a]++;
                E[b]++;
            }
            var L = new List<int>();
            for (var i = 0; i < N; i++)
            {
                if (E[i] == 1) L.Add(i);
            }

            var (u, v) = (L[0], 0);
            for (var i = 0; i < 2; i++)
            {
                var queue = new Queue<int>();
                var x = i % 2 == 0 ? u : v;
                queue.Enqueue(x);
                var depths = Enumerable.Repeat(-1, N).ToArray();
                depths[x] = 0;
                while (queue.Any())
                {
                    var current = queue.Dequeue();
                    foreach (var next in G[current])
                    {
                        if (depths[next] != -1) continue;
                        depths[next] = depths[current] + 1;
                        queue.Enqueue(next);
                    }
                }
                var max = 0;
                foreach (var w in L)
                {
                    if (max < depths[w])
                    {
                        max = depths[w];
                        if (i % 2 == 0) v = w;
                        else u = w;
                    }
                }
            }

            Console.WriteLine($"{u + 1} {v + 1}");
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
