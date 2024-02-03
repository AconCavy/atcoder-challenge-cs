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
        var N = Scanner.Scan<int>();
        var S = new char[N][];
        var p = new List<(int H, int W)>();
        for (var i = 0; i < N; i++)
        {
            S[i] = Scanner.Scan<string>().ToCharArray();
            for (var j = 0; j < N; j++)
            {
                if (S[i][j] == 'P')
                {
                    p.Add((i, j));
                }
            }
        }

        const int Inf = 1 << 30;

        var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
        var queue = new Queue<Data>();
        var first = new Data(p[0].H, p[0].W, p[1].H, p[1].W);
        queue.Enqueue(first);
        var dp = new int[N, N, N, N];
        for (var h1 = 0; h1 < N; h1++)
        {
            for (var w1 = 0; w1 < N; w1++)
            {
                for (var h2 = 0; h2 < N; h2++)
                {
                    for (var w2 = 0; w2 < N; w2++)
                    {
                        dp[h1, w1, h2, w2] = Inf;
                    }
                }
            }
        }
        dp[p[0].H, p[0].W, p[1].H, p[1].W] = 0;

        bool CanMove(int ch, int cw, int nh, int nw)
        {
            return 0 <= nh && nh < N && 0 <= nw && nw < N && S[nh][nw] != '#';
        }

        var answer = Inf;
        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            var (ch1, cw1, ch2, cw2) = curr;
            foreach (var (dh, dw) in D4)
            {
                var (nh1, nw1) = (ch1 + dh, cw1 + dw);
                var (nh2, nw2) = (ch2 + dh, cw2 + dw);
                if (!CanMove(ch1, cw1, nh1, nw1)) (nh1, nw1) = (ch1, cw1);
                if (!CanMove(ch2, cw2, nh2, nw2)) (nh2, nw2) = (ch2, cw2);
                var next = new Data(nh1, nw1, nh2, nw2);
                if (dp[ch1, cw1, ch2, cw2] + 1 < dp[nh1, nw1, nh2, nw2])
                {
                    dp[nh1, nw1, nh2, nw2] = dp[ch1, cw1, ch2, cw2] + 1;
                    if (nh1 == nh2 && nw1 == nw2)
                    {
                        answer = Math.Min(answer, dp[nh1, nw1, nh2, nw2]);
                    }
                    else
                    {
                        queue.Enqueue(next);
                    }
                }
            }
        }

        if (answer == Inf) answer = -1;
        Console.WriteLine(answer);
    }

    public readonly record struct Data(int H1, int W1, int H2, int W2);

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
