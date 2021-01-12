using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var RH = new (int R, int H)[N];
            for (var i = 0; i < N; i++)
            {
                var (r, h) = Scanner.Scan<int, int>();
                RH[i] = (r, h - 1);
            }

            var sorted = RH.ToArray();
            Array.Sort(sorted, (x, y) => x.R.CompareTo(y.R));
            var cum = new int[N + 1, 3];
            for (var i = 0; i < N; i++) cum[i + 1, sorted[i].H]++;
            for (var i = 0; i < N; i++)
                for (var j = 0; j < 3; j++)
                    cum[i + 1, j] += cum[i, j];

            var rates = sorted.Select(x => x.R).ToArray();
            for (var i = 0; i < N; i++)
            {
                var (r, h) = RH[i];
                var lb = LowerBound(rates, r);
                var ub = UpperBound(rates, r);
                var (win, draw, lose) = (lb, 0, N - ub);

                var (wi, li) = ((h + 1) % 3, (h - 1 + 3) % 3);
                win += cum[ub, wi] - cum[lb, wi];
                lose += cum[ub, li] - cum[lb, li];
                draw = N - win - lose - 1;
                Console.WriteLine($"{win} {lose} {draw}");
            }
        }

        public static int LowerBound<T>(IReadOnlyList<T> source, T key, Comparison<T> comparison = null)
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

        public static int UpperBound<T>(IReadOnlyList<T> source, T key, Comparison<T> comparison = null)
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
