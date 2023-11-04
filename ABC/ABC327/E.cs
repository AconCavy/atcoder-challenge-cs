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
        var N = Scanner.Scan<int>();
        var P = Scanner.ScanEnumerable<int>().ToArray();
        const double Inf = 1e18;
        var sqrt = new double[N + 1];
        var w = new double[N + 2];
        var cumw = new double[N + 2];
        cumw[1] = w[1] = 1;
        for (var i = 1; i <= N; i++)
        {
            sqrt[i] = Math.Sqrt(i);
            w[i + 1] = w[i] * 0.9;
            cumw[i + 1] = cumw[i] + w[i + 1];
        }

        var dp = new double[N + 1, N + 1];
        for (var i = 0; i <= N; i++)
        {
            for (var j = 0; j <= N; j++)
            {
                dp[i, j] = -Inf;
            }
        }

        Array.Reverse(P);
        dp[1, 0] = 0;
        dp[1, 1] = w[1] * P[0];
        for (var i = 1; i < N; i++)
        {
            for (var j = 0; j <= i; j++)
            {
                dp[i + 1, j] = Math.Max(dp[i + 1, j], dp[i, j]);
                dp[i + 1, j + 1] = Math.Max(dp[i + 1, j + 1], dp[i, j] + w[j + 1] * P[i]);
            }
        }

        var answer = -Inf;
        for (var i = 1; i <= N; i++)
        {
            for (var j = 1; j <= i; j++)
            {
                var score = dp[i, j] / cumw[j] - 1200 / sqrt[j];
                answer = Math.Max(answer, score);
            }
        }

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
