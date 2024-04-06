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
        var (H, W) = Scanner.Scan<int, int>();
        var A = new char[H][];
        var (sh, sw) = (-1, -1);
        var (th, tw) = (-1, -1);
        for (var i = 0; i < H; i++)
        {
            A[i] = Scanner.Scan<string>().ToCharArray();
            for (var j = 0; j < W; j++)
            {
                if (A[i][j] == 'S')
                {
                    (sh, sw) = (i, j);
                }
                if (A[i][j] == 'T')
                {
                    (th, tw) = (i, j);
                }
            }
        }

        var N = Scanner.Scan<int>();
        var E = new Dictionary<(int, int), int>();
        for (var i = 0; i < N; i++)
        {
            var (r, c, e) = Scanner.Scan<int, int, int>();
            E[(r - 1, c - 1)] = e;
        }

        const int Inf = 1 << 30;
        var dp = new int[H][];
        for (var i = 0; i < H; i++)
        {
            dp[i] = new int[W];
            Array.Fill(dp[i], -Inf);
        }

        dp[sh][sw] = 0;
        var queue = new PriorityQueue<(int H, int W, int E), long>();
        queue.Enqueue((sh, sw, 0), 0);
        var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
        while (queue.TryDequeue(out var top, out _))
        {
            var (ch, cw, ce) = top;
            if (dp[ch][cw] > ce) continue;
            if (E.ContainsKey((ch, cw)))
            {
                ce = Math.Max(ce, E[(ch, cw)]);
            }

            if (ce == 0) continue;
            foreach (var (dh, dw) in D4)
            {
                var (nh, nw) = (ch + dh, cw + dw);
                if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                if (A[nh][nw] == '#') continue;
                var ne = ce - 1;
                if (dp[nh][nw] >= ne) continue;
                dp[nh][nw] = ne;
                queue.Enqueue((nh, nw, ne), -ne);
            }
        }

        var answer = dp[th][tw] >= 0;
        Console.WriteLine(answer ? "Yes" : "No");
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
