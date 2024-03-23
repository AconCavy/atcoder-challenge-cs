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
        var (H, W, M) = Scanner.Scan<int, int, int>();
        var dict = new Dictionary<int, long>();
        var query = new (int T, int A, int X)[M];
        for (var i = 0; i < M; i++)
        {
            query[i] = Scanner.Scan<int, int, int>();
        }

        Array.Reverse(query);
        var row = new int[H];
        var col = new int[W];
        Array.Fill(row, -1);
        Array.Fill(col, -1);
        var remH = H;
        var remW = W;
        for (var i = 0; i < M; i++)
        {
            var (t, a, x) = query[i];
            a--;
            if (t == 1)
            {
                if (row[a] != -1) continue;
                row[a] = x;
                if (!dict.ContainsKey(x)) dict[x] = 0;
                dict[x] += remW;
                remH--;
            }
            else
            {
                if (col[a] != -1) continue;
                col[a] = x;
                if (!dict.ContainsKey(x)) dict[x] = 0;
                dict[x] += remH;
                remW--;
            }
        }

        var sum = dict.Values.Sum();
        var zero = (long)H * W - sum;
        if (!dict.ContainsKey(0)) dict[0] = 0;
        dict[0] += zero;

        Console.WriteLine(dict.Where(x => x.Value > 0).Count());
        foreach (var (k, v) in dict.Where(x => x.Value > 0).OrderBy(x => x.Key))
        {
            Console.WriteLine($"{k} {v}");
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
