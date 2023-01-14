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
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (H, W) = Scanner.Scan<int, int>();
            var A = new char[H][];
            for (var i = 0; i < H; i++)
            {
                A[i] = Scanner.Scan<string>().ToCharArray();
            }

            var Q = Scanner.Scan<int>();
            var Hi = Enumerable.Range(0, H).ToArray();
            var Wi = Enumerable.Range(0, W).ToArray();
            var qa = new List<int>(Q);
            var qb = new List<int>(Q);
            var pa = -1;
            var pb = -1;
            var ac = 0;
            var bc = 0;
            for (var i = 0; i < Q; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                if (pa != a)
                {
                    if (ac % 2 == 1) qa.Add(pa);
                    pa = a;
                    ac = 1;
                }
                else
                {
                    ac++;
                }

                if (pb != b)
                {
                    if (bc % 2 == 1) qb.Add(pb);
                    pb = b;
                    bc = 1;
                }
                else
                {
                    bc++;
                }
            }

            if (ac % 2 == 1) qa.Add(pa);
            if (bc % 2 == 1) qb.Add(pb);

            foreach (var a in qa)
            {
                for (var i = 0; i * 2 < a; i++)
                {
                    (Hi[i], Hi[a - 1 - i]) = (Hi[a - 1 - i], Hi[i]);
                }

                for (var i = 0; i * 2 < H - a; i++)
                {
                    (Hi[a + i], Hi[H - 1 - i]) = (Hi[H - 1 - i], Hi[a + i]);
                }
            }

            foreach (var b in qb)
            {
                for (var i = 0; i * 2 < b; i++)
                {
                    (Wi[i], Wi[b - 1 - i]) = (Wi[b - 1 - i], Wi[i]);
                }

                for (var i = 0; i * 2 < W - b; i++)
                {
                    (Wi[b + i], Wi[W - 1 - i]) = (Wi[W - 1 - i], Wi[b + i]);
                }
            }

            var B = new char[H][];

            for (var i = 0; i < H; i++)
            {
                B[i] = new char[W];
                for (var j = 0; j < W; j++)
                {
                    B[i][j] = A[Hi[i]][Wi[j]];
                }
            }

            Printer.Print2D(B);
        }

        public static class Printer
        {
            public static void Print<T>(T source) => Console.WriteLine(source);
            public static void Print1D<T>(IEnumerable<T> source, string separator = "") => Console.WriteLine(string.Join(separator, source));
            public static void Print1D<T, U>(IEnumerable<T> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(separator, source.Select(selector)));
            public static void Print2D<T>(IEnumerable<IEnumerable<T>> source, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x))));
            public static void Print2D<T, U>(IEnumerable<IEnumerable<T>> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x.Select(selector)))));
            public static void Print2D<T>(T[,] source, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                {
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(source[i, j]);
                        Console.Write(j == w - 1 ? Environment.NewLine : separator);
                    }
                }
            }
            public static void Print2D<T, U>(T[,] source, Func<T, U> selector, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                {
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(selector(source[i, j]));
                        Console.Write(j == w - 1 ? Environment.NewLine : separator);
                    }
                }
            }
        }

        public static class Scanner
        {
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]), Convert<T6>(buffer[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static string[] Scan()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
