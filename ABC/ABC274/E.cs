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
            var (N, M) = Scanner.Scan<int, int>();
            var S = N + M + 1;
            var P = new (int X, int Y)[S];
            P[0] = (0, 0);
            for (var i = 1; i < S; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                P[i] = (x, y);
            }

            double Distance(double x1, double y1, double x2, double y2)
            {
                var dx = x1 - x2;
                var dy = y1 - y2;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            var D = new double[S, S];
            for (var i = 0; i < S; i++)
            {
                for (var j = 0; j < S; j++)
                {
                    D[i, j] = Distance(P[i].X, P[i].Y, P[j].X, P[j].Y);
                }
            }

            const double inf = 7e18;

            var p2 = new double[M + 1];
            p2[0] = 1;
            for (var i = 1; i <= M; i++)
            {
                p2[i] = p2[i - 1] / 2.0;
            }

            var dp = new double[1 << S, S];
            for (var s = 0; s < 1 << S; s++)
            {
                for (var u = 0; u < S; u++)
                {
                    dp[s, u] = inf;
                }
            }

            dp[1, 0] = 0;

            int CountM(int s)
            {
                var k = 0;
                for (var i = 0; i < M; i++)
                {
                    k += (s >> (N + 1 + i)) & 1;
                }

                return k;
            }

            for (var s = 0; s < 1 << S; s++)
            {
                var k = CountM(s);
                for (var u = 0; u < S; u++)
                {
                    for (var v = 0; v < S; v++)
                    {
                        var t = s | (1 << v);
                        dp[t, v] = Math.Min(dp[t, v], dp[s, u] + D[u, v] * p2[k]);
                    }
                }
            }

            var answer = inf;
            var mask = 0;
            for (var i = 0; i < N; i++)
            {
                mask |= 1 << (1 + i);
            }

            for (var s = 0; s < 1 << S; s++)
            {
                if ((s & mask) != mask) continue;
                var k = CountM(s);
                for (var u = 0; u < S; u++)
                {
                    answer = Math.Min(answer, dp[s, u] + D[u, 0] * p2[k]);
                }
            }

            // Printer.Print2D(dp, " ");
            Console.WriteLine(answer);
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
