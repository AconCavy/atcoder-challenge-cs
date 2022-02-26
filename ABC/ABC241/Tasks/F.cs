using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
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
            var (H, W, N) = Scanner.Scan<int, int, int>();
            var (sx, sy) = Scanner.Scan<int, int>();
            var (gx, gy) = Scanner.Scan<int, int>();
            var setX = new HashSet<int>();
            var setY = new HashSet<int>();
            setX.Add(sx);
            setY.Add(sy);
            setX.Add(gx);
            setY.Add(gy);
            var P = new (int X, int Y)[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                setX.Add(x);
                setY.Add(y);
                P[i] = (x, y);
            }

            var (mx, rmx) = Compress(setX);
            var (my, rmy) = Compress(setY);

            H = mx.Count;
            W = my.Count;
            var G = new bool[H, W];
            foreach (var (x, y) in P)
            {
                G[mx[x], my[y]] = true;
            }

            var depths = new int[H, W];
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    depths[i, j] = -1;
                }
            }

            depths[mx[sx], my[sy]] = 0;

            var queue = new Queue<(int, int)>();
            queue.Enqueue((mx[sx], my[sy]));


            while (queue.Count > 0)
            {
                var (uh, uw) = queue.Dequeue();
                for (var i = uh; i + 1 < H; i++)
                {
                    if (G[i + 1, uw])
                    {
                        if (depths[i, uw] != -1) continue;
                        depths[i, uw] = depths[uh, uw] + 1;
                        queue.Enqueue((i, uw));
                        break;
                    }
                }

                for (var i = uh; i - 1 >= 0; i--)
                {
                    if (G[i - 1, uw])
                    {
                        if (depths[i, uw] != -1) continue;
                        depths[i, uw] = depths[uh, uw] + 1;
                        queue.Enqueue((i, uw));
                        break;
                    }
                }

                for (var j = uw; j + 1 < W; j++)
                {
                    if (G[uh, j + 1])
                    {
                        if (depths[uh, j] != -1) continue;
                        depths[uh, j] = depths[uh, uw] + 1;
                        queue.Enqueue((uh, j));
                        break;
                    }
                }

                for (var j = uw; j - 1 >= 0; j--)
                {
                    if (G[uh, j - 1])
                    {
                        if (depths[uh, j] != -1) continue;
                        depths[uh, j] = depths[uh, uw] + 1;
                        queue.Enqueue((uh, j));
                        break;
                    }
                }
            }

            // Printer.Print2D(depths, " ");
            // Printer.Print2D(G, " ");

            var answer = depths[mx[gx], my[gy]];
            Console.WriteLine(answer);
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

        public static (Dictionary<T, int> Map, Dictionary<int, T> ReMap) Compress<T>(IEnumerable<T> source)
        {
            var distinct = source.Distinct().ToArray();
            Array.Sort(distinct);
            var map = new Dictionary<T, int>();
            var remap = new Dictionary<int, T>();
            foreach (var (x, i) in distinct.Select((x, i) => (x, i)))
            {
                map[x] = i;
                remap[i] = x;
            }
            return (map, remap);
        }

        public static class Scanner
        {
            public static string ScanLine() => Console.ReadLine()?.Trim() ?? string.Empty;
            public static string[] Scan() => ScanLine().Split(' ');
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
