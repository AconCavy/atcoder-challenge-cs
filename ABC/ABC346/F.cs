using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

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
        var N = Scanner.Scan<long>();
        var S = Scanner.Scan<string>().Select(x => x - 'a').ToArray();
        var T = Scanner.Scan<string>().Select(x => x - 'a').ToArray();
        var count = new int[26];
        var idx = new List<int>[26].Select(_ => new List<int>()).ToArray();
        for (var i = 0; i < S.Length; i++)
        {
            count[S[i]]++;
            idx[S[i]].Add(i);
        }

        foreach (var c in T)
        {
            if (count[c] == 0)
            {
                Console.WriteLine(0);
                return;
            }
        }

        bool F(long x)
        {
            long k = 0;
            var i = 0;
            foreach (var c in T)
            {
                var lb = LowerBound(idx[c], i);
                var y = x - (count[c] - lb);
                var r = y / count[c];
                k += r;
                var m = (int)(y % count[c]);
                i = idx[c][m] + 1;
                if ((m > 0 && k + 1 > N) || (m == 0 && k > N)) return false;
                // Console.WriteLine($"{(char)(c + 'a')} x:{x} y:{y} k:{k} i:{i}");
            }

            return true;
        }

        const long Inf = 1L << 60;
        var answer = BinarySearch(Inf, 0, F);
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

    public static T BinarySearch<T>(T ng, T ok, Func<T, bool> f) where T : INumber<T> => BinarySearch(ng, ok, f, T.One);
    public static T BinarySearch<T>(T ng, T ok, Func<T, bool> f, T eps) where T : INumber<T>
    {
        var one = T.One;
        var two = one + one;
        while (T.Abs(ok - ng) > eps)
        {
            var m = ng + (ok - ng) / two;
            if (f(m)) ok = m;
            else ng = m;
        }
        return ok;
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
