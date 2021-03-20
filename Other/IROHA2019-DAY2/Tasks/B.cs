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
            var (X, Y) = Scanner.Scan<int, int>();
            var (A, B) = Scanner.Scan<int, int>();
            var (Sx, Sy) = Scanner.Scan<int, int>();
            var (Tx, Ty) = Scanner.Scan<int, int>();

            var answer = Intersect(0, A, X, B, Sx, Sy, Tx, Ty);
            Console.WriteLine(answer ? "Yes" : "No");
        }

        public static bool Intersect(double x1, double y1, double x2, double y2, double x3, double y3, double x4,
                    double y4)
        {
            var t1 = (x3 - x4) * (y1 - y3) + (y3 - y4) * (x3 - x1);
            var t2 = (x3 - x4) * (y2 - y3) + (y3 - y4) * (x3 - x2);
            var t3 = (x1 - x2) * (y3 - y1) + (y1 - y2) * (x1 - x3);
            var t4 = (x1 - x2) * (y4 - y1) + (y1 - y2) * (x1 - x4);
            return t1 * t2 < 0 && t3 * t4 < 0;
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
