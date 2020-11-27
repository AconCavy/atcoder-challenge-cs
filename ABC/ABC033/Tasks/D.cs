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
            var N = Scanner.Scan<int>();
            var P = new (int X, int Y)[N];
            for (var i = 0; i < N; i++) P[i] = Scanner.Scan<int, int>();

            const double eps = 1e-12;
            var (a, b, c) = ((long)N * (N - 1) * (N - 2) / 6, 0L, 0L);

            for (var i = 0; i < N; i++)
            {
                var rad = new List<double>();
                for (var j = 0; j < N; j++)
                {
                    if (i == j) continue;
                    rad.Add(Math.Atan2(P[j].Y - P[i].Y, P[j].X - P[i].X));
                }

                rad.Sort();
                for (var j = 0; j < N - 1; j++) rad.Add(rad[j] + Math.PI * 2);
                var (u90, o90) = (0, 0);
                for (var j = 0; j < N - 1; j++)
                {
                    while (rad[u90] - rad[j] < Math.PI / 2 - eps) u90++;
                    while (rad[o90] - rad[j] < Math.PI - eps) o90++;
                    c += o90 - u90;
                    if (Math.Abs(rad[u90] - rad[j] - Math.PI / 2) < eps) { b++; c--; }
                }
            }

            a -= b + c;
            Console.WriteLine($"{a} {b} {c}");
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
        }
    }
}
