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
        var (N, A, B, C) = Scanner.Scan<int, long, long, long>();
        var D = new long[N][];
        for (var i = 0; i < N; i++)
        {
            D[i] = Scanner.ScanEnumerable<long>().ToArray();
        }

        var G = new List<(int, long)>[N * 2].Select(x => new List<(int, long)>()).ToArray();
        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < N; j++)
            {
                G[i].Add((j, D[i][j] * A));
                G[j].Add((i, D[j][i] * A));

                G[i].Add((N + j, D[i][j] * B + C));
                G[j].Add((N + i, D[j][i] * B + C));

                G[N + i].Add((N + j, D[i][j] * B + C));
                G[N + j].Add((N + i, D[j][i] * B + C));
            }
        }

        var costs = new long[N * 2];
        Array.Fill(costs, 1L << 60);
        costs[0] = 0;
        costs[N] = 0;
        var queue = new PriorityQueue<(int U, long C), long>();
        queue.Enqueue((0, 0), 0);
        queue.Enqueue((N, 0), 0);
        while (queue.TryDequeue(out var top, out _))
        {
            var (u, uc) = top;
            if (costs[u] < uc) continue;
            foreach (var (v, vc) in G[u])
            {
                var nc = costs[u] + vc;
                if (costs[v] <= nc) continue;
                costs[v] = nc;
                queue.Enqueue((v, nc), nc);
            }
        }

        var answer = Math.Min(costs[N - 1], costs[N + N - 1]);
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
