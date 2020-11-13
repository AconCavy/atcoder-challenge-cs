using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var P = new (int X, int Y, int H)[N];
            (int X, int Y, int H) p = (0, 0, -1);
            for (var i = 0; i < N; i++)
            {
                var (x, y, h) = Scanner.Scan<int, int, int>();
                P[i] = (x, y, h);
                if (h > p.H) p = (x, y, h);
            }
            for (var cy = 0; cy <= 100; cy++)
            {
                for (var cx = 0; cx <= 100; cx++)
                {
                    var ok = true;
                    var H = p.H + Math.Abs(p.X - cx) + Math.Abs(p.Y - cy);
                    for (var i = 0; i < N && ok; i++)
                        ok &= P[i].H == Math.Max(H - Math.Abs(P[i].X - cx) - Math.Abs(P[i].Y - cy), 0);
                    if (ok) { Console.WriteLine($"{cx} {cy} {H}"); return; }
                }
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
