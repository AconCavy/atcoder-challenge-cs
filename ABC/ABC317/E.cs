using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

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
        var G = new char[H][];
        var (sh, sw) = (-1, -1);
        var (gh, gw) = (-1, -1);
        for (var i = 0; i < H; i++)
        {
            G[i] = Scanner.Scan<string>().ToCharArray();
            for (var j = 0; j < W; j++)
            {
                if (G[i][j] == 'S') (sh, sw) = (i, j);
                if (G[i][j] == 'G') (gh, gw) = (i, j);
            }
        }

        bool IsPossible(int h, int w)
        {
            return 0 <= h && h < H && 0 <= w && w < W && (G[h][w] == '.' || G[h][w] == 'S' || G[h][w] == 'G');
        }

        var X = new bool[H, W];
        X[sh, sw] = X[gh, gw] = true;
        for (var i = 0; i < H; i++)
        {
            for (var j = 0; j < W; j++)
            {
                if (IsPossible(i, j)) X[i, j] = true;
            }
        }

        void F(char c)
        {
            var (dh, dw) = (0, 0);
            if (c == '>') dw = 1;
            if (c == 'v') dh = 1;
            if (c == '<') dw = -1;
            if (c == '^') dh = -1;

            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (G[i][j] == c)
                    {
                        var k = 1;
                        while (IsPossible(i + dh * k, j + dw * k))
                        {
                            var ni = i + dh * k;
                            var nj = j + dw * k;
                            X[ni, nj] = false;
                            k++;
                        }
                    }
                }
            }
        }

        F('>');
        F('v');
        F('<');
        F('^');

        var dp = new int[H, W];
        const int Inf = (int)1e9;
        for (var i = 0; i < H; i++)
        {
            for (var j = 0; j < W; j++)
            {
                dp[i, j] = Inf;
            }
        }

        dp[sh, sw] = 0;

        var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var queue = new Queue<(int, int, int)>();
        queue.Enqueue((sh, sw, 0));
        while (queue.TryDequeue(out var top))
        {
            var (ch, cw, cc) = top;
            foreach (var (dh, dw) in D4)
            {
                var (nh, nw) = (ch + dh, cw + dw);
                if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                if (!X[nh, nw] || dp[nh, nw] <= cc + 1) continue;
                dp[nh, nw] = cc + 1;
                queue.Enqueue((nh, nw, cc + 1));
            }
        }

        var answer = dp[gh, gw];
        if (answer == Inf) answer = -1;
        Console.WriteLine(answer);

        // Printer.Print2D(X, " ");
        // Printer.Print2D(dp, " ");
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
