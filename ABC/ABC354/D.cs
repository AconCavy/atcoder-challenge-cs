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
        var (A, B, C, D) = Scanner.Scan<long, long, long, long>();
        var a = A % 4;
        var b = B % 2;
        if (a < 0) a += 4;
        if (b < 0) b += 2;

        (A, B, C, D) = (A - A, B - B, C - A, D - B);
        var c = C % 4;
        var d = D % 2;
        if (c < 0) c += 4;
        if (d < 0) d += 2;

        var xx = C / 4 * 4;
        var yy = D / 2 * 2;
        var s = xx * yy;

        var v = new long[4, 2];
        v[0, 0] = 2;
        v[0, 1] = 1;
        v[1, 0] = 1;
        v[1, 1] = 2;
        v[2, 0] = 2;
        v[2, 1] = 1;
        v[3, 0] = 1;
        v[3, 1] = 2;


        long s1 = 0;
        for (var x = a; x < a + c; x++)
        {
            for (var y = 0; y < 2; y++)
            {
                s1 += v[x % 4, y % 2];
            }
        }

        long s2 = 0;
        for (var x = 0; x < 4; x++)
        {
            for (var y = b; y < b + d; y++)
            {
                s2 += v[x % 4, y % 2];
            }
        }

        long s3 = 0;
        for (var x = a; x < a + c; x++)
        {
            for (var y = b; y < d; y++)
            {
                s3 += v[x % 4, y % 2];
            }
        }

        s += s1 * (yy / 2);
        s += s2 * (xx / 4);
        s += s3;

        Console.WriteLine(s);
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
