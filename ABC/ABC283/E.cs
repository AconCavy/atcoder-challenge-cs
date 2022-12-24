using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var A = new int[H][];
            for (var i = 0; i < H; i++)
            {
                A[i] = Scanner.ScanEnumerable<int>().ToArray();
            }

            var dp = new int[H, 2, 2, 2];
            const int inf = (int)1e9;
            for (var i = 0; i < H; i++)
            {
                for (var curr = 0; curr < 2; curr++)
                {
                    for (var next = 0; next < 2; next++)
                    {
                        for (var prev = 0; prev < 2; prev++)
                        {
                            dp[i, curr, next, prev] = inf;
                        }
                    }
                }
            }

            for (var i = 0; i < H; i++)
            {
                for (var curr = 0; curr < 2; curr++)
                {
                    for (var next = 0; next < 2; next++)
                    {
                        for (var prev = 0; prev < 2; prev++)
                        {
                            var okW = true;
                            for (var j = 0; j < W; j++)
                            {
                                var ok = false;
                                if (i - 1 >= 0) ok |= (A[i][j] ^ curr) == (A[i - 1][j] ^ prev);
                                if (i + 1 < H) ok |= (A[i][j] ^ curr) == (A[i + 1][j] ^ next);
                                if (j - 1 >= 0) ok |= (A[i][j] ^ curr) == (A[i][j - 1] ^ curr);
                                if (j + 1 < W) ok |= (A[i][j] ^ curr) == (A[i][j + 1] ^ curr);
                                okW &= ok;
                            }

                            if (!okW) continue;
                            var cost = curr;
                            if (i == 0)
                            {
                                dp[i, curr, next, prev] = Math.Min(dp[i, curr, next, prev], cost);
                            }
                            else
                            {
                                dp[i, curr, next, prev] = Math.Min(dp[i, curr, next, prev], dp[i - 1, prev, curr, 0] + cost);
                                dp[i, curr, next, prev] = Math.Min(dp[i, curr, next, prev], dp[i - 1, prev, curr, 1] + cost);
                            }
                        }
                    }
                }
            }

            var answer = inf;
            for (var curr = 0; curr < 2; curr++)
            {
                for (var next = 0; next < 2; next++)
                {
                    for (var prev = 0; prev < 2; prev++)
                    {
                        answer = Math.Min(answer, dp[H - 1, curr, next, prev]);
                    }
                }
            }

            if (answer == inf)
            {
                Console.WriteLine(-1);
            }
            else
            {
                answer = Math.Min(answer, H - answer);
                Console.WriteLine(answer);
            }
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
