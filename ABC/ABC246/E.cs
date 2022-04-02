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
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var (Ah, Aw) = Scanner.Scan<int, int>();
            Ah--; Aw--;
            var (Bh, Bw) = Scanner.Scan<int, int>();
            Bh--; Bw--;
            var S = new string[N];
            for (var i = 0; i < N; i++)
            {
                S[i] = Scanner.Scan<string>();
            }

            var H = N;
            var W = N;
            var G = new int[H, W];
            const int inf = (int)1e9;
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    G[i, j] = inf;
                }
            }

            var used = new bool[H, W];

            G[Ah, Aw] = 0;
            var D4 = new[] { (1, 1), (-1, -1), (1, -1), (-1, 1) };

            var queue = new Queue<(int, int)>();
            queue.Enqueue((Ah, Aw));

            while (queue.Count > 0)
            {
                var (ch, cw) = queue.Dequeue();
                if (used[ch, cw]) continue;
                used[ch, cw] = true;
                var cc = G[ch, cw];

                foreach (var (dh, dw) in D4)
                {
                    for (var d = 1; d < N; d++)
                    {
                        var (nh, nw) = (ch + dh * d, cw + dw * d);
                        if (nh < 0 || H <= nh || nw < 0 || W <= nw) break;
                        if (S[nh][nw] == '#') break;
                        var nc = cc + 1;
                        if (G[nh, nw] < nc) break;
                        G[nh, nw] = nc;
                        queue.Enqueue((nh, nw));
                    }
                }
            }

            var answer = G[Bh, Bw] == inf ? -1 : G[Bh, Bw];
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
