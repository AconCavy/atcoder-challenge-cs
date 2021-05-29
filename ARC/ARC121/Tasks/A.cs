using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
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
            var P = new Point[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<long, long>();
                P[i] = new Point(i, x, y);
            }

            long GetDistance(Point p1, Point p2)
            {
                return Math.Max(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            }

            var dict = new Dictionary<(int, int), long>();
            Array.Sort(P, (x, y) => x.X.CompareTo(y.X));

            for (var i = 0; i < Math.Min(N, 3); i++)
            {
                for (var j = Math.Max(N - 4, 0); j < N; j++)
                {
                    if (i == j) continue;
                    var (a, b) = (P[i], P[j]);
                    var d = GetDistance(a, b);
                    if (a.Idx < b.Idx) dict[(a.Idx, b.Idx)] = d;
                    else dict[(b.Idx, a.Idx)] = d;
                }
            }

            Array.Sort(P, (x, y) => x.Y.CompareTo(y.Y));

            for (var i = 0; i < Math.Min(N, 3); i++)
            {
                for (var j = Math.Max(N - 4, 0); j < N; j++)
                {
                    if (i == j) continue;
                    var (a, b) = (P[i], P[j]);
                    var d = GetDistance(a, b);
                    if (a.Idx < b.Idx) dict[(a.Idx, b.Idx)] = d;
                    else dict[(b.Idx, a.Idx)] = d;
                }
            }

            var values = dict.Values.ToArray();
            Array.Sort(values, (x, y) => y.CompareTo(x));

            var answer = values[1];
            Console.WriteLine(answer);
        }

        public readonly struct Point
        {
            public readonly int Idx;
            public readonly long X;
            public readonly long Y;
            public Point(int idx, long x, long y) => (Idx, X, Y) = (idx, x, y);
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
