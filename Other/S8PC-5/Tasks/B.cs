using System;
using System.Collections;
using System.Collections.Generic;
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
            var (N, M) = Scanner.Scan<int, int>();
            var cn = new Circle[N];
            var cm = new Circle[M];
            var min = 200.0;
            for (var i = 0; i < N; i++)
            {
                var (x, y, r) = Scanner.Scan<int, int, int>();
                cn[i] = new Circle { X = x, Y = y, R = r };
                min = Math.Min(min, r);
            }

            for (var i = 0; i < M; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                cm[i] = new Circle { X = x, Y = y, R = min };
            }

            bool Check(double r)
            {
                foreach (var c in cm) c.R = r;

                foreach (var c1 in cn)
                    foreach (var c2 in cm)
                        if (Circle.Intersect(c1, c2)) return false;

                for (var i = 0; i < M; i++)
                    for (var j = i + 1; j < M; j++)
                        if (Circle.Intersect(cm[i], cm[j])) return false;

                return true;
            }

            const double eps = 1e-9;
            var (ok, ng) = (0.0, min);
            while (ng - ok > eps)
            {
                var m = (ok + ng) / 2;
                if (Check(m)) ok = m;
                else ng = m;
            }

            Console.WriteLine(ok);
        }

        public class Circle
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double R { get; set; }

            public static bool Intersect(Circle a, Circle b)
            {
                var dx = a.X - b.X;
                var dy = a.Y - b.Y;
                var r = a.R + b.R;
                return r * r > dx * dx + dy * dy;
            }
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
