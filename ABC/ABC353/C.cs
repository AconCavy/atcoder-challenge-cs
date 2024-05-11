using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class C
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
        const long M = (long)1e8;
        var N = Scanner.Scan<int>();
        var A = Scanner.ScanEnumerable<long>().ToArray();
        Array.Sort(A);

        var cum = new long[N + 1];
        for (var i = 0; i < N; i++)
        {
            cum[i + 1] = cum[i] + A[i];
        }

        long answer = 0;
        long over = 0;
        for (var i = 0; i + 1 < N; i++)
        {
            var sum = A[i] * (N - 1 - i) + (cum[N] - cum[i + 1]);
            answer += sum;
            var lb = LowerBound(A, M - A[i]);
            over += Math.Max(0, N - Math.Max(i + 1, lb));
        }

        answer -= over * M;
        Console.WriteLine(answer);
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
