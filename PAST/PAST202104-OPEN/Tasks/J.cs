using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class J
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
            var (N, C) = Scanner.Scan<int, long>();
            var P = new Point[N];
            const double inf = 2e5;
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<long, long>();
                P[i] = new Point(x, y);
            }

            double CalcCost(double x)
            {
                var sum = 0d;
                foreach (var p in P)
                {
                    var (dx, dy) = (x - p.X, C - p.Y);
                    sum += dx * dx + dy * dy;
                }

                return sum;
            }

            var p = GoldenSearch(-inf, inf, CalcCost);
            var answer = CalcCost(p);
            Console.WriteLine(answer);
        }

        public static double GoldenSearch(double l, double r, Func<double, double> func, double eps = 1e-9)
        {
            var phi = (1.0 + Math.Sqrt(5)) / 2;
            while (r - l > eps)
            {
                var (ml, mr) = ((l * phi + r) / (phi + 1), (l + r * phi) / (phi + 1));
                if (func(ml) < func(mr)) r = mr;
                else l = ml;
            }
            return (l + r) / 2;
        }

        public readonly struct Point
        {
            public readonly long X;
            public readonly long Y;
            public Point(long x, long y) => (X, Y) = (x, y);
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
