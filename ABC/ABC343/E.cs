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
        var L = 7;
        var V = Scanner.ScanEnumerable<int>().ToArray();

        IEnumerable<Point> Iter()
        {
            for (var x = 0; x <= L; x++)
            {
                for (var y = 0; y <= L; y++)
                {
                    for (var z = 0; z <= L; z++)
                    {
                        yield return new Point(x, y, z);
                    }
                }
            }
        }

        int F(ReadOnlySpan<Point> p)
        {
            var xl = 0;
            var yl = 0;
            var zl = 0;
            var xr = 100;
            var yr = 100;
            var zr = 100;
            for (var i = 0; i < p.Length; i++)
            {
                xl = Math.Max(xl, p[i].A);
                yl = Math.Max(yl, p[i].B);
                zl = Math.Max(zl, p[i].C);
                xr = Math.Min(xr, p[i].A + L);
                yr = Math.Min(yr, p[i].B + L);
                zr = Math.Min(zr, p[i].C + L);
            }

            return Math.Max(0, xr - xl) * Math.Max(0, yr - yl) * Math.Max(0, zr - zl);
        }

        var P = new Point[3];
        var buffer = new Point[2];
        var all = 7 * 7 * 7 * 3;
        foreach (var p1 in Iter())
        {
            foreach (var p2 in Iter())
            {
                P[1] = p1;
                P[2] = p2;
                var v3 = F(P);
                buffer[0] = P[0];
                buffer[1] = P[2];
                var v2 = F(P[..1]) + F(P[1..]) + F(buffer) - v3 * 3;
                var v1 = all - v2 * 2 - v3 * 3;
                if (v1 == V[0] && v2 == V[1] && v3 == V[2])
                {
                    Console.WriteLine($"{P[0].A} {P[0].B} {P[0].C} {P[1].A} {P[1].B} {P[1].C} {P[2].A} {P[2].B} {P[2].C}");
                    return;
                }
            }
        }

        Console.WriteLine("No");
    }

    public readonly record struct Point(int A, int B, int C);

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
