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
            var answer = 0L;
            var current = 0L;
            var cum = A.Cumulate((x, y) => x + y).ToArray();
            var max = new long[cum.Length];
            for (var i = 1; i < cum.Length; i++) max[i] = Math.Max(max[i - 1], cum[i]);
            for (var i = 0; i < cum.Length; i++)
            {
                answer = Math.Max(answer, current + max[i]);
                current += cum[i];
                answer = Math.Max(answer, current);
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