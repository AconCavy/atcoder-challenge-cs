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
            var (H, W, T) = Scanner.Scan<int, int, int>();
            var A = new char[H][];
            var G = new bool[H][];
            var (sh, sw) = (0, 0);
            var (gh, gw) = (0, 0);
            var map = new Dictionary<(int, int), int>();
            var M = 0;
            var snacks = new List<(int H, int W)>();

            for (var i = 0; i < H; i++)
            {
                A[i] = Scanner.Scan<string>().ToCharArray();
                G[i] = new bool[W];
                for (var j = 0; j < W; j++)
                {
                    if (A[i][j] == 'S') (sh, sw) = (i, j);
                    if (A[i][j] == 'G') (gh, gw) = (i, j);
                    if (A[i][j] == 'o')
                    {
                        map[(i, j)] = M++;
                        snacks.Add((i, j));
                    }
                    G[i][j] = A[i][j] != '#';
                }
            }

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
            const int Inf = (int)1e9;

            int[][] GetDistance(int h, int w)
            {
                var result = new int[H][];
                for (var i = 0; i < H; i++)
                {
                    result[i] = new int[W];
                    for (var j = 0; j < W; j++)
                    {
                        result[i][j] = Inf;
                    }
                }

                result[h][w] = 0;
                var queue = new Queue<(int, int)>();
                queue.Enqueue((h, w));
                while (queue.Count > 0)
                {
                    var (ch, cw) = queue.Dequeue();
                    foreach (var (dh, dw) in D4)
                    {
                        var (nh, nw) = (ch + dh, cw + dw);
                        if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                        if (!G[nh][nw] || result[nh][nw] != Inf) continue;
                        result[nh][nw] = result[ch][cw] + 1;
                        queue.Enqueue((nh, nw));
                    }
                }

                return result;
            }

            var startToGoal = GetDistance(sh, sw)[gh][gw];
            if (startToGoal > T)
            {
                Console.WriteLine(-1);
                return;
            }

            var snackDistances = new int[M][][];
            for (var k = 0; k < M; k++)
            {
                var (h, w) = snacks[k];
                snackDistances[k] = GetDistance(h, w);
            }

            var dp = new int[1 << M, M];
            for (var i = 0; i < 1 << M; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    dp[i, j] = Inf;
                }
            }

            for (var u = 0; u < M; u++)
            {
                dp[1 << u, u] = snackDistances[u][sh][sw];
            }

            for (var cs = 0; cs < 1 << M; cs++)
            {
                for (var u = 0; u < M; u++)
                {
                    if ((cs >> u & 1) == 0) continue;
                    for (var v = 0; v < M; v++)
                    {
                        if ((cs >> v & 1) == 1) continue;
                        var (nh, nw) = snacks[v];
                        var nd = dp[cs, u] + snackDistances[u][nh][nw];
                        var ns = cs | (1 << v);
                        dp[ns, v] = Math.Min(dp[ns, v], nd);
                    }
                }
            }

            var answer = 0;
            for (var s = 0; s < 1 << M; s++)
            {
                for (var u = 0; u < M; u++)
                {
                    var gd = dp[s, u] + snackDistances[u][gh][gw];
                    if (gd <= T)
                    {
                        var count = 0;
                        for (var i = 0; i < M; i++)
                        {
                            count += (s >> i) & 1;
                        }

                        answer = Math.Max(answer, count);
                    }
                }
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]), Convert<T6>(buffer[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static string[] Scan()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
