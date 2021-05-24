using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class H
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
            var G = new char[H][];
            var list = new List<(int H, int W)>[11].Select(_ => new List<(int H, int W)>()).ToArray();
            for (var i = 0; i < H; i++)
            {
                G[i] = Scanner.Scan<string>().ToCharArray();
                for (var j = 0; j < W; j++)
                {
                    if (G[i][j] == 'S') list[0].Add((i, j));
                    else if (G[i][j] == 'G') list[10].Add((i, j));
                    else list[G[i][j] - '0'].Add((i, j));
                }
            }

            var (sh, sw) = list[0][0];
            var (gh, gw) = list[10][0];

            const long inf = (long)1e18;
            var C = new long[H, W];
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    C[i, j] = inf;
                }
            }

            C[sh, sw] = 0;

            for (var i = 0; i < 10; i++)
            {
                foreach (var (ch, cw) in list[i])
                {
                    if (C[ch, cw] == inf) continue;
                    foreach (var (nh, nw) in list[i + 1])
                    {
                        var c = C[ch, cw] + Math.Abs(nh - ch) + Math.Abs(nw - cw);
                        C[nh, nw] = Math.Min(C[nh, nw], c);
                    }
                }
            }

            var answer = C[gh, gw];
            if (answer == inf) answer = -1;
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
