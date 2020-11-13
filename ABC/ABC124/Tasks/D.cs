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
            var (N, K) = Scanner.Scan<int, int>();
            var S = Scanner.Scan<string>();
            var counts = new List<int>();
            var count = 0;
            if (S[0] == '0') counts.Add(0);
            for (var i = 0; i < N; i++)
            {
                count++;
                if (i == 0 || S[i] == S[i - 1]) continue;
                counts.Add(count - 1);
                count = 1;
            }
            counts.Add(count);
            if (count != 0) counts.Add(0);

            var cum = Cumulate(counts, (x, y) => x + y).ToArray();
            var answer = 0;
            var W = K * 2 + 1;
            if (cum.Length <= W) answer = cum[^1];
            else
            {
                for (var i = 0; i + W < cum.Length; i += 2)
                {
                    answer = Math.Max(answer, cum[i + W] - cum[i]);
                }
            }

            Console.WriteLine(answer);
        }

        public static IEnumerable<TAccumulate> Cumulate<TSource, TAccumulate>(IEnumerable<TSource> source,
            TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));
            yield return seed;
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext()) yield return seed = func(seed, enumerator.Current);
        }

        public static IEnumerable<TAccumulate> Cumulate<TSource, TAccumulate>(IEnumerable<TSource> source,
            Func<TAccumulate, TSource, TAccumulate> func) => Cumulate(source, default, func);
        public static IEnumerable<TSource> Cumulate<TSource>(IEnumerable<TSource> source,
            Func<TSource, TSource, TSource> func) => Cumulate(source, default, func);

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
