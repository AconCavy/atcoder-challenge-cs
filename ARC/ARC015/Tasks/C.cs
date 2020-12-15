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
            var dict = new Dictionary<string, int>();
            var units = new List<string>();
            var G = new double[N + 2, N + 2];
            for (var i = 0; i < N; i++)
            {
                var (large, m, small) = Scanner.Scan<string, long, string>();
                if (!dict.ContainsKey(large))
                {
                    dict[large] = dict.Count;
                    units.Add(large);
                }
                if (!dict.ContainsKey(small))
                {
                    dict[small] = dict.Count;
                    units.Add(small);
                }
                var (idx1, idx2) = (dict[large], dict[small]);
                G[idx1, idx2] = Math.Max(G[idx1, idx2], m);
                G[idx2, idx1] = Math.Max(G[idx2, idx1], 1.0 / m);
            }

            for (var k = 0; k < dict.Count; k++)
                for (var i = 0; i < dict.Count; i++)
                    for (var j = 0; j < dict.Count; j++)
                        if (G[i, j] == 0) G[i, j] = Math.Max(G[i, j], G[i, k] * G[k, j]);

            var (A, M, B) = ("", 0.0, "");

            for (var i = 0; i < dict.Count; i++)
                for (var j = 0; j < dict.Count; j++)
                {
                    if (G[i, j] <= M) continue;
                    M = G[i, j];
                    A = units[i];
                    B = units[j];
                }

            Console.WriteLine($"1{A}={(int)Math.Round(M)}{B}");
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
