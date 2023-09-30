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
        var (N, K, P) = Scanner.Scan<int, int, int>();
        var Plans = new (long C, int[] A)[N];
        for (var i = 0; i < N; i++)
        {
            var array = Scanner.ScanEnumerable<int>().ToArray();
            Plans[i] = (array[0], array[1..]);
        }

        var dp = new Dictionary<string, long>();
        const long Inf = 1L << 60;
        dp[new string('0', K)] = 0;
        var B = new int[K];

        for (var i = 0; i < N; i++)
        {
            var (C, A) = Plans[i];
            var ndp = new Dictionary<string, long>();
            foreach (var (s, c) in dp)
            {
                for (var j = 0; j < K; j++)
                {
                    B[j] = A[j];
                }

                for (var j = 0; j < K; j++)
                {
                    B[j] += s[j] - '0';
                    B[j] = Math.Min(P, B[j]);
                }

                var ns = string.Join("", B);
                if (!ndp.ContainsKey(s)) ndp[s] = Inf;
                ndp[s] = Math.Min(ndp[s], c);
                if (!ndp.ContainsKey(ns)) ndp[ns] = Inf;
                ndp[ns] = Math.Min(ndp[ns], C + c);
            }
            dp = ndp;
        }

        var g = new string((char)(P + '0'), K);
        var answer = dp.ContainsKey(g) ? dp[g] : -1;
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
