using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;

namespace Tasks
{
    public class C
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
            var G = new bool[N, N];
            var A = new bool[N, N];

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
            var K = new[] { (0, 0), (1, 2), (2, 1) };

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if ((i * 2 + j) % 5 != 0) continue;
                    A[i, j] = G[i, j] = true;
                    foreach (var (dh, dw) in D4)
                    {
                        var (nh, nw) = (i + dh, j + dw);
                        if (nh < 0 || N <= nh || nw < 0 || N <= nw) continue;
                        G[nh, nw] = true;
                    }
                }
            }

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if (G[i, j]) continue;

                    A[i, j] = G[i, j] = true;
                    foreach (var (dh, dw) in D4)
                    {
                        var (nh, nw) = (i + dh, j + dw);
                        if (nh < 0 || N <= nh || nw < 0 || N <= nw) continue;
                        G[nh, nw] = true;
                    }
                }
            }

            Printer.Print2D(A, x => x ? 'X' : '.');
        }

        public static class Printer
        {
            public static void Print<T>(T source) => Console.WriteLine(source);
            public static void Print1D<T>(IEnumerable<T> source, string separator = "") =>
                Console.WriteLine(string.Join(separator, source));
            public static void Print1D<T, U>(IEnumerable<T> source, Func<T, U> selector, string separator = "") =>
                Console.WriteLine(string.Join(separator, source.Select(selector)));
            public static void Print2D<T>(IEnumerable<IEnumerable<T>> source, string separator = "") =>
                Console.WriteLine(string.Join("\n", source.Select(x => string.Join(separator, x))));
            public static void Print2D<T, U>(IEnumerable<IEnumerable<T>> source, Func<T, U> selector, string separator = "") =>
                Console.WriteLine(string.Join("\n", source.Select(x => string.Join(separator, x.Select(selector)))));
            public static void Print2D<T>(T[,] source, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(source[i, j]);
                        Console.Write(j == w - 1 ? "\n" : separator);
                    }
            }
            public static void Print2D<T, U>(T[,] source, Func<T, U> selector, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(selector(source[i, j]));
                        Console.Write(j == w - 1 ? "\n" : separator);
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
