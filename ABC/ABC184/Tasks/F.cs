using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class F
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
            var (N, T) = Scanner.Scan<int, long>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var M = N / 2;
            var T1 = new List<long>();
            var T2 = new List<long>();
            for (var i = 0; i < 1 << M; i++)
            {
                var sum = 0L;
                for (var j = 0; j < M; j++)
                {
                    if ((i >> j & 1) == 1) sum += A[j];
                }
                if (sum <= T) T1.Add(sum);
            }

            for (var i = 0; i < 1 << (N - M); i++)
            {
                var sum = 0L;
                for (var j = 0; j <= N - M; j++)
                {
                    if ((i >> j & 1) == 1) sum += A[M + j];
                }
                if (sum <= T) T2.Add(sum);
            }

            T2.Sort();
            var answer = 0L;
            foreach (var t in T1)
            {
                answer = Math.Max(answer, t);
                var idx = T2.UpperBound(T - t) - 1;
                if (idx > 0) answer = Math.Max(answer, t + T2[idx]);
            }

            Console.WriteLine(answer);
        }

        public static int UpperBound(List<long> source, long key)
        {
            if (source.Count == 0) return 0;
            var (l, r) = (-1, source.Count);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (source[m] > key) r = m;
                else l = m;
            }
            return r;
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
