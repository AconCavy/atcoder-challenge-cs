using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (H, W, T) = Scanner.Scan<int, int, int>();
            var G = new bool[H][];
            var (sh, sw, gh, gw) = (0, 0, 0, 0);
            for (var i = 0; i < H; i++)
            {
                G[i] = new bool[W];
                var S = Console.ReadLine();
                for (var j = 0; j < S.Length; j++)
                {
                    switch (S[j])
                    {
                        case '.': break;
                        case 'S': (sh, sw) = (i, j); break;
                        case 'G': (gh, gw) = (i, j); break;
                        case '#': G[i][j] = true; break;
                        default: break;
                    }
                }
            }

            var dh = new[] { 0, 1, 0, -1 };
            var dw = new[] { -1, 0, 1, 0 };
            long GetTime(int time)
            {
                var q = new Queue<(int, int)>();
                q.Enqueue((sh, sw));
                var times = new long[H][].Select(x => x = Enumerable.Repeat((long)1e9 + 1, W).ToArray()).ToArray();
                times[sh][sw] = 0;
                while (q.Any())
                {
                    var (ch, cw) = q.Dequeue();
                    for (var i = 0; i < 4; i++)
                    {
                        var nh = ch + dh[i];
                        var nw = cw + dw[i];
                        if (nh < 0 || nh >= H) continue;
                        if (nw < 0 || nw >= W) continue;
                        var t = times[ch][cw] + (G[nh][nw] ? time : 1);
                        if (times[nh][nw] <= t) continue;
                        times[nh][nw] = t;
                        q.Enqueue((nh, nw));
                    }
                }

                return times[gh][gw];
            }

            var l = 0;
            var r = (int)1e9;
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (GetTime(m) <= T) l = m;
                else r = m;
            }

            Console.WriteLine(l);
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
        }
    }
}
