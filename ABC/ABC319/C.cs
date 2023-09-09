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
        var C = new int[3][];
        for (var i = 0; i < 3; i++)
        {
            C[i] = Scanner.ScanEnumerable<int>().ToArray();
        }

        (int, int) F(int x) => (x / 3, x % 3);

        var all = 9 * 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1;
        var p = all;
        var tate = new List<int>[3].Select(_ => new List<int>(3)).ToArray();
        var yoko = new List<int>[3].Select(_ => new List<int>(3)).ToArray();
        var naname1 = new List<int>();
        var naname2 = new List<int>();
        foreach (var items in Enumerable.Range(0, 9).Permute())
        {
            for (var i = 0; i < 3; i++)
            {
                tate[i].Clear();
                yoko[i].Clear();
                naname1.Clear();
                naname2.Clear();
            }

            var ng = false;
            for (var i = 0; i < 9 && !ng; i++)
            {
                var (h, w) = F(items[i]);
                var v = C[h][w];
                tate[h].Add(v);
                yoko[w].Add(v);
                if (h - w == 0) naname1.Add(v);
                if (h + w == 2) naname2.Add(v);

                ng |= tate[h].Count == 3 && tate[h][0] == tate[h][1] && tate[h][0] != tate[h][2];
                ng |= yoko[w].Count == 3 && yoko[w][0] == yoko[w][1] && yoko[w][0] != yoko[w][2];
                ng |= naname1.Count == 3 && naname1[0] == naname1[1] && naname1[0] != naname1[2];
                ng |= naname2.Count == 3 && naname2[0] == naname2[1] && naname2[0] != naname2[2];
            }

            if (ng) p--;
        }

        var answer = (double)p / all;
        Console.WriteLine(answer);
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

public static partial class EnumerableExtension
{
    public static IEnumerable<T[]> Permute<T>(this IEnumerable<T> source)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        IEnumerable<T[]> Inner()
        {
            var items = source.ToArray();
            var n = items.Length;
            var indices = new int[n];
            for (var i = 0; i < indices.Length; i++)
            {
                indices[i] = i;
            }
            T[] Result()
            {
                var result = new T[n];
                for (var i = 0; i < n; i++)
                {
                    result[i] = items[indices[i]];
                }
                return result;
            }
            yield return Result();
            while (true)
            {
                var (i, j) = (n - 2, n - 1);
                while (i >= 0)
                {
                    if (indices[i] < indices[i + 1]) break;
                    i--;
                }
                if (i == -1) yield break;
                while (true)
                {
                    if (indices[j] > indices[i]) break;
                    j--;
                }
                (indices[i], indices[j]) = (indices[j], indices[i]);
                Array.Reverse(indices, i + 1, n - 1 - i);
                yield return Result();
            }
        }
        return Inner();
    }
}
