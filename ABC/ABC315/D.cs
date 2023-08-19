using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

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
        var (H, W) = Scanner.Scan<int, int>();
        var S = new char[H][];
        for (var i = 0; i < H; i++)
        {
            S[i] = Scanner.Scan<string>().ToCharArray();
        }

        var chars = new List<int>();
        var used = new HashSet<int>();
        var answer = 0;
        for (var i = 0; i < H; i++)
        {
            for (var j = 0; j < W; j++)
            {
                if (char.IsLetter(S[i][j]) && char.IsLower(S[i][j]))
                {
                    answer++;
                    if (!used.Contains(S[i][j]))
                    {
                        used.Add(S[i][j]);
                        chars.Add(S[i][j]);
                    }
                }
            }
        }

        foreach (var c in chars)
        {
            var TH = new bool[H, W];
            var TW = new bool[H, W];

            for (var i = 0; i < H; i++)
            {
                var ok = true;
                var count = 0;
                for (var j = 0; j < W && ok; j++)
                {
                    ok &= S[i][j] == c || S[i][j] == '.';
                    if (S[i][j] == c) count++;
                }

                ok &= count >= 2;
                if (!ok) continue;
                for (var j = 0; j < W; j++)
                {
                    if (S[i][j] == c)
                    {
                        TH[i, j] = true;
                    }
                }
            }

            for (var j = 0; j < W; j++)
            {
                var ok = true;
                var count = 0;
                for (var i = 0; i < H && ok; i++)
                {
                    ok &= S[i][j] == c || S[i][j] == '.';
                    if (S[i][j] == c) count++;
                }

                ok &= count >= 2;
                if (!ok) continue;
                for (var i = 0; i < H; i++)
                {
                    if (S[i][j] == c)
                    {
                        TW[i, j] = true;
                    }
                }
            }

            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (TH[i, j] || TW[i, j])
                    {
                        S[i][j] = '.';
                        answer--;
                    }
                }
            }
            // Printer.Print2D(S);
            // Console.WriteLine();
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
