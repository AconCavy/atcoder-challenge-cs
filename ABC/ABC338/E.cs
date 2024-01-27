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
        var M = N * 3;
        var G = new List<int>[M].Select(x => new List<int>()).ToArray();
        for (var i = 0; i < N; i++)
        {
            var (a, b) = Scanner.Scan<int, int>();
            a--; b--;
            if (a > b) (a, b) = (b, a);
            if (b - a > N) (a, b) = (b, a + M);
            if (a + 1 != b) G[a].Add(b);
        }

        var stack = new Stack<int>();
        for (var a = 0; a < M; a++)
        {
            foreach (var b in G[a])
            {
                if (stack.Count > 0)
                {
                    var top = stack.Peek();
                    if (a < top && top < b)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
            }

            while (stack.Count > 0 && stack.Peek() < a)
            {
                stack.Pop();
            }

            foreach (var v in G[a])
            {
                stack.Push(v);
            }
        }

        Console.WriteLine("No");
    }

    public static int LowerBound<T>(List<T> source, T key, IComparer<T>? comparer = null)
        => LowerBound(System.Runtime.InteropServices.CollectionsMarshal.AsSpan(source), key, comparer);

    public static int LowerBound<T>(ReadOnlySpan<T> source, T key, IComparer<T>? comparer = null)
    {
        comparer ??= Comparer<T>.Default;
        var (lo, hi) = (-1, source.Length);
        while (hi - lo > 1)
        {
            var mi = lo + ((hi - lo) >> 1);
            if (comparer.Compare(source[mi], key) >= 0) hi = mi;
            else lo = mi;
        }

        return hi;
    }

    public static int UpperBound<T>(List<T> source, T key, IComparer<T>? comparer = null)
        => UpperBound(System.Runtime.InteropServices.CollectionsMarshal.AsSpan(source), key, comparer);

    public static int UpperBound<T>(ReadOnlySpan<T> source, T key, IComparer<T>? comparer = null)
    {
        comparer ??= Comparer<T>.Default;
        var (lo, hi) = (-1, source.Length);
        while (hi - lo > 1)
        {
            var mi = lo + ((hi - lo) >> 1);
            if (comparer.Compare(source[mi], key) > 0) hi = mi;
            else lo = mi;
        }

        return hi;
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
