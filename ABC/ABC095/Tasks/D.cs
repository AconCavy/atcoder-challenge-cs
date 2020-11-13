using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SandboxCSharp.Extensions;

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
            var (N, C) = Scanner.Scan<int, long>();
            var L = new (long, long)[N];
            var R = new (long, long)[N];
            for (var i = 0; i < N; i++)
            {
                var (x, v) = Scanner.Scan<long, long>();
                L[i] = (x, v);
                R[N - 1 - i] = (C - x, v);
            }
            var cumL = L.Cumulate((0L, 0L), (l, r) => (r.Item1, l.Item2 + r.Item2)).ToArray();
            var cumR = R.Cumulate((0L, 0L), (l, r) => (r.Item1, l.Item2 + r.Item2)).ToArray();

            var lMax1 = new long[N + 1];
            var lMax2 = new long[N + 1];
            var rMax1 = new long[N + 1];
            var rMax2 = new long[N + 1];
            for (var i = 1; i <= N; i++)
            {
                var (lx, lv) = cumL[i];
                var (rx, rv) = cumR[i];
                lMax1[i] = Math.Max(lMax1[i - 1], lv - lx);
                lMax2[i] = Math.Max(lMax2[i - 1], lv - lx * 2);
                rMax1[i] = Math.Max(rMax1[i - 1], rv - rx);
                rMax2[i] = Math.Max(rMax2[i - 1], rv - rx * 2);
            }
            var answer = 0L;
            for (var i = 0; i <= N; i++)
            {
                answer = Math.Max(answer, lMax1[i] + rMax2[N - i]);
                answer = Math.Max(answer, rMax1[i] + lMax2[N - i]);
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));

        }
    }
}

namespace SandboxCSharp.Extensions
{
    public static partial class EnumerableExtension
    {
        public static IEnumerable<TAccumulate> Cumulate<TSource, TAccumulate>(this IEnumerable<TSource> source,
            TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));
            IEnumerable<TAccumulate> Inner()
            {
                yield return seed;
                foreach (var item in source) yield return seed = func(seed, item);
            }
            return Inner();
        }
        public static IEnumerable<TAccumulate> Cumulate<TSource, TAccumulate>(this IEnumerable<TSource> source,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));
            IEnumerable<TAccumulate> Inner()
            {
                TAccumulate seed = default;
                yield return seed;
                foreach (var item in source) yield return seed = func(seed, item);
            }
            return Inner();
        }
        public static IEnumerable<TSource> Cumulate<TSource>(this IEnumerable<TSource> source,
            Func<TSource, TSource, TSource> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));
            IEnumerable<TSource> Inner()
            {
                TSource seed = default;
                yield return seed;
                foreach (var item in source) yield return seed = func(seed, item);
            }
            return Inner();
        }
    }
}
