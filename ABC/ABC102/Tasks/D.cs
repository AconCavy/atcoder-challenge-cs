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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var cum = A.Cumulate((x, y) => x + y).ToArray();
            const long linf = (long)1e18;
            var answer = linf;

            for (var i = 2; i < N - 1; i++)
            {
                var (l, r) = (cum[i], cum[N] - cum[i]);
                var (h1, h2) = ((l + 1) / 2, l + (r + 1) / 2);

                var m1 = cum.LowerBound(h1);
                if (h1 - cum[m1 - 1] <= cum[m1] - h1) m1--;
                var max1 = Math.Max(cum[m1], l - cum[m1]);
                var min1 = l - max1;

                var m2 = cum.LowerBound(h2);
                if (h2 - cum[m2 - 1] <= cum[m2] - h2) m2--;
                var max2 = Math.Max(cum[m2] - l, cum[N] - cum[m2]);
                var min2 = r - max2;

                answer = Math.Min(answer, Math.Max(max1, max2) - Math.Min(min1, min2));

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
}

namespace SandboxCSharp.Extensions
{
    public static class IndexedListExtension
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
            var (l, r) = (-1, source.Count - 1);
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
            var (l, r) = (-1, source.Count - 1);
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
