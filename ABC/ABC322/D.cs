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
        const int N = 4;
        var P = new char[3][,];
        for (var k = 0; k < 3; k++)
        {
            P[k] = new char[N, N];
            for (var i = 0; i < N; i++)
            {
                var p = Scanner.Scan<string>().ToCharArray();
                for (var j = 0; j < N; j++)
                {
                    P[k][i, j] = p[j];
                }
            }
        }

        var G = new char[N, N];
        const int Inf = 1 << 30;
        void Init(char[,] g)
        {
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    g[i, j] = '.';
                }
            }
        }

        char[,] Rotate(char[,] p)
        {
            var tmp = new char[N, N];
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    tmp[i, j] = p[j, N - 1 - i];
                }
            }

            var h = Inf;
            var w = Inf;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if (tmp[i, j] == '#')
                    {
                        h = Math.Min(h, i);
                        w = Math.Min(w, j);
                    }
                }
            }

            var result = new char[N, N];
            if (h == Inf) return result;
            for (var i = 0; h + i < N; i++)
            {
                for (var j = 0; w + j < N; j++)
                {
                    result[i, j] = tmp[h + i, w + j];
                }
            }

            return result;
        }

        bool Fill(char[,] p, int dh, int dw)
        {
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if (p[i, j] == '#')
                    {
                        if (dh + i < N && dw + j < N && G[dh + i, dw + j] != '#')
                        {
                            G[dh + i, dw + j] = '#';
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        IEnumerable<(int dh, int dw)> Delta()
        {
            for (var h = 0; h < N; h++)
            {
                for (var w = 0; w < N; w++)
                {
                    yield return (h, w);
                }
            }
        }

        for (var a = 0; a < 4; a++)
        {
            P[0] = Rotate(P[0]);
            for (var b = 0; b < 4; b++)
            {
                P[1] = Rotate(P[1]);
                for (var c = 0; c < 4; c++)
                {
                    P[2] = Rotate(P[2]);
                    foreach (var (dha, dwa) in Delta())
                    {
                        foreach (var (dhb, dwb) in Delta())
                        {
                            foreach (var (dhc, dwc) in Delta())
                            {
                                var ok = true;
                                Init(G);
                                ok &= Fill(P[0], dha, dwa);
                                ok &= Fill(P[1], dhb, dwb);
                                ok &= Fill(P[2], dhc, dwc);

                                for (var i = 0; i < N && ok; i++)
                                {
                                    for (var j = 0; j < N && ok; j++)
                                    {
                                        ok &= G[i, j] == '#';
                                    }
                                }

                                if (ok)
                                {
                                    Console.WriteLine("Yes");
                                    // Console.WriteLine();
                                    // Printer.Print2D(G);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("No");
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
