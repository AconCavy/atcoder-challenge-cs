using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var (H, W) = Scanner.Scan<int, int>();
            var (CH, CW) = Scanner.Scan<int, int>();
            CH--; CW--;
            var (DH, DW) = Scanner.Scan<int, int>();
            DH--; DW--;
            var S = new string[H];
            for (var i = 0; i < H; i++)
            {
                S[i] = Console.ReadLine();
            }

            var inf = (long)1e18;

            var G = new long[H][].Select(x => Enumerable.Repeat(inf, W).ToArray()).ToArray();
            G[CH][CW] = 0;
            var Q = new Queue<(int h, int w)>();
            Q.Enqueue((CH, CW));
            var dy = new[] { 0, 1, 0, -1 };
            var dx = new[] { -1, 0, 1, 0 };

            while (Q.Any())
            {
                var c = Q.Dequeue();
                var ch = c.h;
                var cw = c.w;
                var count = G[ch][cw];

                var wQ = new Queue<(int h, int w)>();
                wQ.Enqueue(c);
                while (wQ.Any())
                {
                    var wc = wQ.Dequeue();
                    var wh = wc.h;
                    var ww = wc.w;
                    for (var i = 0; i < 4; i++)
                    {
                        var nh = wh + dy[i];
                        var nw = ww + dx[i];
                        if (nh < 0 || nh >= H) continue;
                        if (nw < 0 || nw >= W) continue;
                        if (S[nh][nw] == '#') continue;
                        if (G[nh][nw] <= count) continue;

                        G[nh][nw] = count;
                        Q.Enqueue((nh, nw));
                        wQ.Enqueue((nh, nw));
                    }
                }

                count++;
                for (var dh = -2; dh <= 2; dh++)
                {
                    for (var dw = -2; dw <= 2; dw++)
                    {
                        if (dh == 0 && dw == 0) continue;
                        var nh = ch + dh;
                        var nw = cw + dw;
                        if (nh < 0 || nh >= H) continue;
                        if (nw < 0 || nw >= W) continue;
                        if (S[nh][nw] == '#') continue;
                        if (G[nh][nw] <= count) continue;

                        G[nh][nw] = count;
                        Q.Enqueue((nh, nw));
                    }
                }
            }

            if (G[DH][DW] == inf) G[DH][DW] = -1;

            // Console.WriteLine(string.Join("\n", G.Select(x => string.Join(" ", x))));

            Console.WriteLine(G[DH][DW]);

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
