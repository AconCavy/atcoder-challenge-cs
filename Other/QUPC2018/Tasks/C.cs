using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var (H, W, X) = Scanner.Scan<int, int, int>();
            var b = new Queue<(int, int)>();
            var G = new bool[H, W];
            var (sh, sw) = (0, 0);
            var (gh, gw) = (0, 0);
            const int inf = (int)1e9;
            var D = new int[H, W];
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    D[i, j] = inf;
                }
            }

            for (var i = 0; i < H; i++)
            {
                var s = Scanner.Scan<string>();
                for (var j = 0; j < W; j++)
                {
                    switch (s[j])
                    {
                        case 'S': (sh, sw) = (i, j); G[i, j] = true; break;
                        case 'G': (gh, gw) = (i, j); G[i, j] = true; break;
                        case '@': b.Enqueue((i, j)); D[i, j] = 0; break;
                        case '.': G[i, j] = true; break;
                        default: break;
                    }
                }
            }

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            while (b.Any())
            {
                var (ch, cw) = b.Dequeue();
                foreach (var (dh, dw) in D4)
                {
                    var (nh, nw) = (ch + dh, cw + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    if (!G[nh, nw]) continue;
                    if (D[ch, cw] + 1 >= D[nh, nw]) continue;
                    D[nh, nw] = D[ch, cw] + 1;
                    b.Enqueue((nh, nw));
                }
            }

            var queue = new Queue<(int, int)>();
            queue.Enqueue((sh, sw));
            var depths = new int[H, W];
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    depths[i, j] = -1;
                }
            }

            depths[sh, sw] = 0;
            while (queue.Any())
            {
                var (ch, cw) = queue.Dequeue();

                foreach (var (dh, dw) in D4)
                {
                    var (nh, nw) = (ch + dh, cw + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    if (depths[nh, nw] != -1) continue;
                    if (!G[nh, nw] || D[nh, nw] <= X) continue;
                    depths[nh, nw] = depths[ch, cw] + 1;
                    queue.Enqueue((nh, nw));
                }
            }

            Console.WriteLine(depths[gh, gw]);
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
