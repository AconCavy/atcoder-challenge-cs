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
        var N = Scanner.Scan<int>();
        var P = new long[N][];
        for (var i = 0; i < N; i++)
        {
            P[i] = Scanner.ScanEnumerable<long>().ToArray();
        }

        var R = new long[N][].Select(_ => new long[N]).ToArray();
        for (var i = 0; i < N; i++)
        {
            var X = Scanner.ScanEnumerable<long>().ToArray();
            for (var j = 0; j < N - 1; j++)
            {
                R[i][j] = X[j];
            }
        }

        var D = new long[N][].Select(_ => new long[N]).ToArray();
        for (var i = 0; i < N - 1; i++)
        {
            var X = Scanner.ScanEnumerable<long>().ToArray();
            for (var j = 0; j < N; j++)
            {
                D[i][j] = X[j];
            }
        }

        const long Inf = 1L << 60;
        var need = new long[N][];
        var rem = new long[N][];
        for (var i = 0; i < N; i++)
        {
            need[i] = new long[N];
            Array.Fill(need[i], Inf);
            rem[i] = new long[N];
            Array.Fill(rem[i], Inf);
        }

        need[0][0] = 0;
        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < N; j++)
            {
                if (i + 1 < N) need[i + 1][j] = Math.Min(need[i + 1][j], need[i][j] + D[i][j]);
                if (j + 1 < N) need[i][j + 1] = Math.Min(need[i][j + 1], need[i][j] + R[i][j]);
            }
        }

        rem[N - 1][N - 1] = 0;
        for (var i = N - 1; i >= 0; i--)
        {
            for (var j = N - 1; j >= 0; j--)
            {
                if (i - 1 >= 0) rem[i - 1][j] = Math.Min(rem[i - 1][j], rem[i][j] + D[i - 1][j]);
                if (j - 1 >= 0) rem[i][j - 1] = Math.Min(rem[i][j - 1], rem[i][j] + R[i][j - 1]);
            }
        }

        var dp = new long[N, N, 2];
        var mo = new long[N, N, 2];
        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < N; j++)
            {
                dp[i, j, 0] = dp[i, j, 1] = Inf;
            }
        }

        dp[N - 1, N - 1, 0] = dp[N - 1, N - 1, 1] = 0;
        mo[N - 1, N - 1, 0] = mo[N - 1, N - 1, 1] = 0;
        for (var i = N - 1; i >= 0; i--)
        {
            for (var j = N - 1; j >= 0; j--)
            {
                for (var k = 0; k < 2; k++)
                {
                    if (i - 1 >= 0)
                    {
                        var one = dp[i, j, k] + (rem[i - 1][j] - rem[i][j] - mo[i, j, k] + P[i - 1][j] - 1) / P[i - 1][j];
                        if (one <= dp[i - 1, j, 0])
                        {
                            var x = one * P[i - 1][j] - (rem[i - 1][j] - rem[i][j]);
                            if (one < dp[i - 1, j, 1] || x < mo[i - 1, j, 1]) mo[i - 1, j, 1] = x;
                            dp[i - 1, j, 0] = one;
                        }
                        var all = dp[i, j, k] + (rem[i - 1][j] - mo[i, j, k] + P[i - 1][j] - 1) / P[i - 1][j];
                        if (all <= dp[i - 1, j, 1])
                        {
                            var x = all * P[i - 1][j] - rem[i - 1][j];
                            if (all < dp[i - 1, j, 1] || x < mo[i - 1, j, 1]) mo[i - 1, j, 1] = x;
                            dp[i - 1, j, 1] = all;
                        }
                    }
                    if (j - 1 >= 0)
                    {
                        var one = dp[i, j, k] + (rem[i][j - 1] - rem[i][j] - mo[i, j, k] + P[i][j - 1] - 1) / P[i][j - 1];
                        if (one <= dp[i, j - 1, 0])
                        {
                            var x = one * P[i][j - 1] - (rem[i][j - 1] - rem[i][j]);
                            if (one < dp[i, j - 1, 0] || x < mo[i, j - 1, 0]) mo[i, j - 1, 0] = x;
                            dp[i, j - 1, 0] = one;
                        }
                        var all = dp[i, j, k] + (rem[i][j - 1] - mo[i, j, k] + P[i][j - 1] - 1) / P[i][j - 1];
                        if (all <= dp[i, j - 1, 1])
                        {
                            var x = all * P[i][j - 1] - rem[i][j - 1];
                            if (all < dp[i, j - 1, 1] || x < mo[i, j - 1, 1]) mo[i, j - 1, 1] = x;
                            dp[i, j - 1, 1] = all;
                        }
                    }
                }
            }
        }

        var answer = Math.Min(dp[0, 0, 0], dp[0, 0, 1]) + (N - 1) * 2;
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
