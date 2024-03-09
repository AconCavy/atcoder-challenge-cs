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
        var A = Scanner.ScanEnumerable<int>().ToArray();
        var prev = new Dictionary<int, int>();
        var next = new Dictionary<int, int>();
        next[A[^1]] = -1;
        prev[-1] = A[^1];
        prev[A[0]] = -2;
        next[-2] = A[0];
        for (var i = 0; i + 1 < N; i++)
        {
            var u = A[i];
            var v = A[i + 1];
            next[u] = v;
            prev[v] = u;
        }

        var Q = Scanner.Scan<int>();
        for (var q = 1; q <= Q; q++)
        {
            var query = Scanner.ScanEnumerable<int>().ToArray();
            if (query[0] == 1)
            {
                var (x, y) = (query[1], query[2]);
                var a = x;
                var b = y;
                var c = next[x];
                next[a] = b;
                next[b] = c;
                prev[b] = a;
                prev[c] = b;
            }
            else
            {
                var x = query[1];
                var a = prev[x];
                var b = x;
                var c = next[x];
                next[a] = c;
                prev[c] = a;
            }
        }

        var curr = next[-2];
        var answer = new List<int>();
        while (curr >= 0)
        {
            answer.Add(curr);
            curr = next[curr];
        }

        Console.WriteLine(string.Join(" ", answer));
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
