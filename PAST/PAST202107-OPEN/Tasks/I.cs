using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class I
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
            var (rx, ry) = Scanner.Scan<double, double>();
            var (lx, ly) = Scanner.Scan<double, double>();

            var P = new (double X, double Y)[N];
            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<double, double>();
                P[i] = (a, b);
            }

            (double X, double Y) Rotate(double x, double y, double radian)
            {
                var xx = x * Math.Cos(radian) - y * Math.Sin(radian);
                var yy = x * Math.Sin(radian) + y * Math.Cos(radian);
                return (xx, yy);
            }

            (double X, double Y) Move(double x, double y, double dx, double dy)
            {
                return (x + dx, y + dy);
            }

            var (cx, cy) = ((rx + lx) / 2, (ry + ly) / 2);
            var rad = Math.Atan2(ly - cy, lx - cx);

            foreach (var (x, y) in P)
            {
                var (tx, ty) = Move(x, y, -cx, -cy);
                (tx, ty) = Rotate(tx, ty, -rad);
                Console.WriteLine($"{tx} {ty}");
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
