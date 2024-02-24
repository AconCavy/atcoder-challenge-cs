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
        var (N, M) = Scanner.Scan<int, int>();
        var G = new List<Data>[N].Select(x => new List<Data>()).ToArray();
        for (var i = 0; i < M; i++)
        {
            var (l, d, k, c, A, B) = Scanner.Scan<int, int, int, int, int, int>();
            A--; B--;
            G[B].Add(new Data(A, l, d, k, c));
        }

        const long Inf = 1L << 60;
        var dp = new long[N];
        Array.Fill(dp, -Inf);
        var queue = new PriorityQueue<(int U, long C), long>();
        foreach (var (v, l, d, k, c) in G[N - 1])
        {
            var vc = l + (k - 1) * d;
            if (dp[v] < vc)
            {
                dp[v] = vc;
                queue.Enqueue((v, dp[v]), -dp[v]);
            }
        }

        while (queue.TryDequeue(out var top, out _))
        {
            var (u, uc) = top;
            if (dp[u] > uc) continue;
            foreach (var (v, l, d, k, c) in G[u])
            {
                if (dp[u] - c < l) continue;
                var vk = Math.Min(k - 1, (dp[u] - c - l) / d);
                var vc = l + vk * d;
                if (dp[v] >= vc) continue;
                dp[v] = vc;
                queue.Enqueue((v, dp[v]), -dp[v]);
            }
        }

        for (var i = 0; i < N - 1; i++)
        {
            var answer = dp[i] >= 0 ? dp[i].ToString() : "Unreachable";
            Console.WriteLine(answer);
        }
    }


    public readonly record struct Data(int To, long L, long D, long K, long C);

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
