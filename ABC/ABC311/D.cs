using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
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
            var G = new bool[N][];
            for (var i = 0; i < N; i++)
            {
                G[i] = Scanner.Scan<string>().Select(x => x == '.').ToArray();
            }

            var dp = new bool[N, M, 4];
            var queue = new Queue<(int H, int W, int D)>();
            for (var i = 0; i < 4; i++)
            {
                dp[1, 1, i] = true;
                queue.Enqueue((1, 1, i));
            }

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            while (queue.Count > 0)
            {
                var (ch, cw, d) = queue.Dequeue();

                var (dh1, dw1) = D4[d];
                var (nh1, nw1) = (ch + dh1, cw + dw1);

                if (nh1 < 0 || N <= nh1 || nw1 < 0 || M <= nw1) continue;
                if (dp[nh1, nw1, d]) continue;
                if (G[nh1][nw1])
                {
                    dp[nh1, nw1, d] = true;
                    queue.Enqueue((nh1, nw1, d));
                }
                else
                {
                    for (var i = 0; i < 4; i++)
                    {
                        var (dh2, dw2) = D4[i];
                        var (nh2, nw2) = (ch + dh2, cw + dw2);
                        if (nh2 < 0 || N <= nh2 || nw2 < 0 || M <= nw2) continue;
                        if (dp[nh2, nw2, i] || !G[nh2][nw2]) continue;
                        dp[nh2, nw2, i] = true;
                        queue.Enqueue((nh2, nw2, i));
                    }
                }
            }

            var answer = 0;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    var ok = false;
                    for (var k = 0; k < 4; k++)
                    {
                        ok |= dp[i, j, k];
                    }

                    if (ok) answer++;
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
}
