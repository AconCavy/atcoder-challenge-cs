using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class G
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
        var (N, C) = Scanner.Scan<int, long>();
        var M = Scanner.Scan<int>();
        var D = new Data[M + 1];
        D[0] = new Data(0, 0);
        for (var i = 1; i <= M; i++)
        {
            var (t, p) = Scanner.Scan<int, long>();
            t--;
            D[i] = new Data(t, p);
        }

        var dp = new Dictionary<int, long>();
        dp[D[^1].T] = D[^1].P;
        for (var i = M; i >= 0; i--)
        {
            var (t, p) = D[i];
            var ndp = new Dictionary<int, long>();
            foreach (var (pt, pp) in dp)
            {
                var d = Math.Abs(t - pt);
                var cp = pp + p - C * d;

                if (cp >= 0)
                {
                    if (!ndp.ContainsKey(t)) ndp[t] = 0;
                    ndp[t] = Math.Max(ndp[t], cp);
                }

                if (cp <= 0)
                {
                    if (!ndp.ContainsKey(pt)) ndp[pt] = 0;
                    ndp[pt] = Math.Max(ndp[pt], pp);
                }

            }

            dp = ndp;
        }

        var answer = Math.Max(0, dp[0]);
        Console.WriteLine(answer);
    }

    public readonly record struct Data(int T, long P);


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
