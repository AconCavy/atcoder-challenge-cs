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
            var (A, B) = Scanner.Scan<double, double>();
            if (A > B) (A, B) = (B, A);
            var N = Scanner.Scan<int>();
            for (var i = 0; i < N; i++)
            {
                var (C, D) = Scanner.Scan<double, double>();
                if (C > D) (C, D) = (D, C);
                var ok = A <= C && B <= D;
                var (l, r) = (0.0, Math.PI / 4);
                for (var j = 0; j < 100 && !ok; j++)
                {
                    var m = (l + r) / 2;
                    var (sin, cos) = (Math.Sin(m), Math.Cos(m));
                    var (x, y) = (A * cos + B * sin, B * cos + A * sin);
                    if (x <= C && y <= D)
                    {
                        ok = true;
                        break;
                    }
                    if (x > C) r = m;
                    else l = m;
                }

                Console.WriteLine(ok ? "YES" : "NO");
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
