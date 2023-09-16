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
        var (N, H) = Scanner.Scan<int, int>();
        var X = Scanner.ScanEnumerable<int>().ToArray();
        var S = new Dictionary<int, (int, int, long)>();
        var Y = new List<int> { 0 };

        const long Inf = (long)1e18;
        for (var i = 0; i < N - 1; i++)
        {
            var (p, f) = Scanner.Scan<int, long>();
            S[X[i]] = (i, p, f);
            S[X[^1] * 2 - X[i]] = (i, p, f);
            Y.Add(X[i]);
            Y.Add(X[^1] * 2 - X[i]);
        }

        Y.Add(X[^1]);
        Y.Sort();

        var M = Y.Count;
        var dp = new long[M, H + 1, N - 1, 2];
        for (var i = 0; i < M; i++)
        {
            for (var j = 0; j <= H; j++)
            {
                for (var k = 0; k < N - 1; k++)
                {
                    dp[i, j, k, 0] = Inf;
                    dp[i, j, k, 1] = Inf;
                }
            }
        }

        for (var k = 0; k < N - 1; k++)
        {
            dp[0, H, k, 0] = 0;
        }

        for (var m = 1; m < M; m++)
        {
            var cy = Y[m];
            var py = Y[m - 1];
            var d = py - cy;
            for (var ch = H - d; ch >= 0; ch--)
            {
                var ph = ch + d;
                var (i, p, f) = S[cy];
                for (var k = 0; k < N - 1; k++)
                {
                    dp[m, ch, k, 0] = dp[m - 1, ph, k, 0];
                    dp[m, ch, k, 1] = dp[m - 1, ph, k, 1];
                }

                var nh = Math.Min(H, ch + f);
                dp[m, nh, i, 1] = Math.Min(dp[m, nh, i, 1], dp[m - 1, ph, i, 0] + p);
                dp[m, nh, i, 0] = Math.Min(dp[m, nh, i, 0], dp[m - 1, ph, i, 1]);
            }
        }

        var answer = Inf;
        for (var h = H; h >= 0; h--)
        {
            for (var k = 0; k < N - 1; k++)
            {
                answer = Math.Min(answer, dp[M - 1, h, k, 0]);
                answer = Math.Min(answer, dp[M - 1, h, k, 1]);
            }
        }

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
