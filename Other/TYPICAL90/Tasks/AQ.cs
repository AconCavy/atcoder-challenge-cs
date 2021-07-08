using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class AQ
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (H, W) = Scanner.Scan<int, int>();
            var (sh, sw) = Scanner.Scan<int, int>();
            var (gh, gw) = Scanner.Scan<int, int>();
            sh--; sw--; gh--; gw--;

            var G = new string[H];
            for (var i = 0; i < H; i++)
            {
                G[i] = Console.ReadLine();
            }

            var D4 = new[] { (0, 1), (1, 0), (0, -1), (-1, 0) };

            const int inf = (int)1e9;
            var dp = new int[H, W, 4];
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    for (var d = 0; d < 4; d++)
                    {
                        dp[i, j, d] = inf;
                    }
                }
            }

            var queue = new Queue<(int, int, int)>();
            for (var d = 0; d < 4; d++)
            {
                dp[sh, sw, d] = 0;
                queue.Enqueue((sh, sw, d));
            }

            while (queue.Count > 0)
            {
                var (ch, cw, cd) = queue.Dequeue();
                for (var nd = 0; nd < 4; nd++)
                {
                    var (dh, dw) = D4[nd];
                    var (nh, nw) = (ch + dh, cw + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    if (G[nh][nw] == '#') continue;

                    var cost = dp[ch, cw, cd];
                    if (nd != cd) cost++;
                    if (dp[nh, nw, nd] <= cost) continue;
                    dp[nh, nw, nd] = cost;
                    queue.Enqueue((nh, nw, nd));
                }
            }

            var answer = inf;
            for (var d = 0; d < 4; d++)
            {
                answer = Math.Min(answer, dp[gh, gw, d]);
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
