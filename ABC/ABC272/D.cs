using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var (N, M) = Scanner.Scan<int, int>();

            var root = new Dictionary<int, int>();
            for (var i = 0; i * i <= M; i++)
            {
                root[i * i] = i;
            }

            var delta = new HashSet<(int, int)>();
            void Add(int dh, int dw)
            {
                if (dh * dh + dw * dw == M && !delta.Contains((dh, dw)))
                {
                    delta.Add((dh, dw));
                }
            }

            foreach (var t in new[] { -1, 1 })
            {
                for (var d = 0; d < N; d++)
                {
                    var k = d * t;
                    var dh = k;
                    var dw2 = M - (dh * dh);
                    if (dw2 < 0) break;
                    if (root.ContainsKey(dw2))
                    {
                        var dw = root[dw2];
                        Add(k, dw);
                        Add(k, -dw);
                        Add(dw, k);
                        Add(-dw, k);
                    }
                }
            }

            var dp = new long[N, N];
            const long inf = (long)1e18;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    dp[i, j] = inf;
                }
            }

            dp[0, 0] = 0;
            var queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));
            while (queue.Count > 0)
            {
                var (i, j) = queue.Dequeue();
                foreach (var (dh, dw) in delta)
                {
                    var (k, l) = (i + dh, j + dw);
                    if (0 <= k && k < N && 0 <= l && l < N && dp[k, l] == inf)
                    {
                        dp[k, l] = dp[i, j] + 1;
                        queue.Enqueue((k, l));
                    }
                }
            }

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if (dp[i, j] == inf) dp[i, j] = -1;
                }
            }

            Printer.Print2D(dp, " ");
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
