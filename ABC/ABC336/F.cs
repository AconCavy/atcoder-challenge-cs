using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Tasks;

public class F
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
        var G = new int[H][];
        for (var i = 0; i < H; i++)
        {
            G[i] = Scanner.ScanEnumerable<int>().ToArray();
        }

        string ToString(int[][] g)
        {
            var buffer = new int[H * W];
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    buffer[i * W + j] = g[i][j];
                }
            }

            return string.Join(" ", buffer);
        }

        void Rotate(int[][] g, int x, int y)
        {
            for (var i = x; i < H - (1 - x); i++)
            {
                var a = H - 1 - (1 - x) - i + x;
                if (i > a) break;
                for (var j = y; j < W - (1 - y); j++)
                {
                    var b = W - 1 - (1 - y) - j + y;
                    if (i == a && j >= b) break;
                    (g[i][j], g[a][b]) = (g[a][b], g[i][j]);
                }

            }
        }

        var E = new int[H][];
        for (var i = 0; i < H; i++)
        {
            E[i] = new int[W];
            for (var j = 0; j < W; j++)
            {
                E[i][j] = i * W + j + 1;
            }
        }

        const int Inf = 1 << 30;

        void Dfs(int[][] g, string s, int c, Dictionary<string, int> dp)
        {
            if (c >= 10) return;
            var u = ToString(g);
            if (dp[u] > dp[s]) return;

            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    for (var k = 0; k < 2; k++)
                    {
                        var v = ToString(g);
                        if (!dp.ContainsKey(v)) dp[v] = Inf;
                        if (dp[u] + 1 < dp[v])
                        {
                            dp[v] = dp[u] + 1;
                            Dfs(g, s, c + k, dp);
                        }

                        Rotate(g, i, j);
                    }
                }
            }
        }

        var dp1 = new Dictionary<string, int>();
        var dp2 = new Dictionary<string, int>();

        var S = ToString(G);
        var T = ToString(E);
        dp1[T] = Inf;
        dp1[S] = 0;
        Dfs(G, T, 0, dp1);

        dp2[S] = Inf;
        dp2[T] = 0;
        Dfs(E, S, 0, dp2);

        var answer = dp1[T];
        foreach (var k in dp1.Keys)
        {
            if (dp2.ContainsKey(k))
            {
                answer = Math.Min(answer, dp1[k] + dp2[k]);
            }
        }

        if (answer > 20) answer = -1;
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
        public static T Scan<T>() where T : IConvertible => Convert<T>(ScanStringArray()[0]);
        public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]));
        }
        public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]));
        }
        public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]));
        }
        public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]));
        }
        public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]), Convert<T6>(input[5]));
        }
        public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanStringArray().Select(Convert<T>);
        private static string[] ScanStringArray()
        {
            var line = Console.ReadLine()?.Trim() ?? string.Empty;
            return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
        }
        private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
    }
}
