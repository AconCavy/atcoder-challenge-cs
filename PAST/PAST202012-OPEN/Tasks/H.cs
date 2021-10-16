using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class H
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
            var (H, W) = Scanner.Scan<int, int>();
            var (r, c) = Scanner.Scan<int, int>();
            r--; c--;
            var S = new char[H][];
            for (var i = 0; i < H; i++)
            {
                S[i] = Scanner.Scan<string>().ToCharArray();
            }

            var G = new char[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = new char[W];
                for (var j = 0; j < W; j++)
                {
                    if (S[i][j] == '#') G[i][j] = '#';
                    else G[i][j] = 'x';
                }
            }

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            (int H, int W) Delta(char c)
            {
                return c switch
                {
                    '<' => (0, -1),
                    '>' => (0, 1),
                    '^' => (-1, 0),
                    'v' => (1, 0),
                    _ => (0, 0)
                };
            }

            var used = new bool[H, W];

            var queue = new Queue<(int H, int W)>();
            queue.Enqueue((r, c));
            G[r][c] = 'o';
            used[r, c] = true;
            while (queue.Count > 0)
            {
                var (ch, cw) = queue.Dequeue();

                foreach (var (dh, dw) in D4)
                {
                    var (nh, nw) = (ch + dh, cw + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    if (used[nh, nw] || S[nh][nw] == '#') continue;
                    var ok = S[nh][nw] == '.';
                    var (ddh, ddw) = Delta(S[nh][nw]);
                    ok |= (dh + ddh, dw + ddw) == (0, 0);
                    if (ok)
                    {
                        used[nh, nw] = true;
                        G[nh][nw] = 'o';
                        queue.Enqueue((nh, nw));
                    }
                }
            }

            Printer.Print2D(G);
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
