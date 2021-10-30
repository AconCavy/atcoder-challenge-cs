using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var P = new (Point L, Point R)[N];

            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<long, long>();
                P[i] = (new Point(x, y - 1), new Point(x - 1, y));
            }

            Array.Sort(P, (x, y) => (x.R.Y * y.R.X).CompareTo(y.R.Y * x.R.X));

            var rr = new Point(0, 0);
            var answer = 0;
            foreach (var (l, r) in P)
            {
                if (l.Y * rr.X < rr.Y * l.X) continue;
                rr = r;
                answer++;
            }

            Console.WriteLine(answer);
        }

        public readonly struct Point : IEquatable<Point>
        {
            public readonly long X;
            public readonly long Y;
            public Point(long x, long y) => (X, Y) = (x, y);

            public bool Equals([AllowNull] Point other)
            {
                return X == other.X && Y == other.Y;
            }
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
