using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
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
            var (N, M, K) = Scanner.Scan<int, int, int>();
            var G = new List<(int U, int A)>[N];
            G = new List<(int U, int A)>[N].Select(x => new List<(int U, int A)>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (u, v, a) = Scanner.Scan<int, int, int>();
                u--; v--;
                G[u].Add((v, a));
                G[v].Add((u, a));
            }

            var T = new HashSet<int>();
            if (K > 0)
            {
                var S = Scanner.ScanEnumerable<int>().Select(x => x - 1).ToArray();
                T = new HashSet<int>(S);
            }

            const int inf = (int)1e9;
            var costs = new int[2][].Select(_ => new int[N]).ToArray();
            Array.Fill(costs[0], inf);
            Array.Fill(costs[1], inf);
            costs[0][0] = 0;

            var queue = new Queue<(int T, int U, long Cost)>();
            queue.Enqueue((0, 0, 0));
            while (queue.Count > 0)
            {
                var (ut, u, uc) = queue.Dequeue();
                var vt = ut;

                for (var i = 0; i < 2; i++)
                {
                    foreach (var (v, a) in G[u])
                    {
                        if (a == vt) continue;
                        var c = costs[ut][u] + 1;
                        if (costs[vt][v] <= c) continue;
                        costs[vt][v] = c;
                        queue.Enqueue((vt, v, c));
                    }

                    if (T.Contains(u)) vt = ut ^ 1;
                    else break;
                }
            }

            var answer = Math.Min(costs[0][N - 1], costs[1][N - 1]);
            if (answer == inf) answer = -1;
            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            public static string ScanLine() => Console.ReadLine()?.Trim() ?? string.Empty;
            public static string[] Scan() => ScanLine().Split(' ');
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
