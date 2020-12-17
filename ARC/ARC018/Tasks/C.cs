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
            var (N, M) = Scanner.Scan<int, int>();
            var (x0, a, p) = Scanner.Scan<int, int, int>();
            var G = new long[N * M];
            G[0] = x0;
            for (var i = 1; i < G.Length; i++) G[i] = (G[i - 1] + a) % p;
            var sorted = G.ToArray();
            Array.Sort(sorted);
            var from = new List<int>[N].Select(_ => new List<int>()).ToArray();
            var to = new List<int>[N].Select(_ => new List<int>()).ToArray();
            var dict = new Dictionary<long, int>();
            var answer = 0L;
            for (var i = 0; i < G.Length; i++)
            {
                if (!dict.ContainsKey(G[i])) dict[G[i]] = 0;
                var idx = sorted.LowerBound(G[i]) + dict[G[i]];
                dict[G[i]]++;
                if (i / M == idx / M) continue;
                from[i / M].Add(i % M);
                to[idx / M].Add(i % M);
                var dy = Math.Abs(i / M - idx / M);
                answer += dy;
            }

            for (var i = 0; i < N; i++)
            {
                from[i].Sort();
                to[i].Sort();
                for (var j = 0; j < from[i].Count; j++)
                {
                    var dx = Math.Abs(to[i][j] - from[i][j]);
                    answer += dx;
                }
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

    public static class ReadonlyListExtension
    {
        public static int BinarySearch<T>(this IReadOnlyList<T> source, T key, Comparison<T> comparison = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (source.Count == 0) return -1;
            comparison ??= Comparer<T>.Default.Compare;
            var (l, r) = (-1, source.Count);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                var result = comparison(source[m], key);
                if (result < 0) l = m;
                else if (result > 0) r = m;
                else return m;
            }
            return -1;
        }
        public static int LowerBound<T>(this IReadOnlyList<T> source, T key, Comparison<T> comparison = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (source.Count == 0) return 0;
            comparison ??= Comparer<T>.Default.Compare;
            var (l, r) = (-1, source.Count);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (comparison(source[m], key) >= 0) r = m;
                else l = m;
            }
            return r;
        }
        public static int UpperBound<T>(this IReadOnlyList<T> source, T key, Comparison<T> comparison = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (source.Count == 0) return 0;
            comparison ??= Comparer<T>.Default.Compare;
            var (l, r) = (-1, source.Count);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (comparison(source[m], key) > 0) r = m;
                else l = m;
            }
            return r;
        }
    }
}
