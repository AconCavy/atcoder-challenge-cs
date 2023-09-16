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
        var (N, M) = Scanner.Scan<int, int>();
        const string Undecidable = "undecidable";
        var G = new HashSet<(int, Point)>[N].Select(x => new HashSet<(int, Point)>()).ToArray();
        for (var i = 0; i < M; i++)
        {
            var (a, b, x, y) = Scanner.Scan<int, int, long, long>();
            a--; b--;
            G[a].Add((b, new(x, y)));
            G[b].Add((a, new(-x, -y)));
        }

        var P = new HashSet<Point>[N].Select(_ => new HashSet<Point>()).ToArray();
        P[0].Add(new(0, 0));
        var queue = new Queue<int>();
        queue.Enqueue(0);
        while (queue.TryDequeue(out var u))
        {
            var cp = P[u].First();
            foreach (var (v, diff) in G[u])
            {
                var (dx, dy) = diff;
                var np = new Point(cp.X + dx, cp.Y + dy);
                if (P[v].Contains(np)) continue;
                P[v].Add(np);
                queue.Enqueue(v);
            }
        }

        for (var i = 0; i < N; i++)
        {
            if (P[i].Count == 1)
            {
                var p = P[i].First();
                Console.WriteLine($"{p.X} {p.Y}");
            }
            else
            {
                Console.WriteLine(Undecidable);
            }
        }
    }

    public readonly record struct Point(long X, long Y);

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
