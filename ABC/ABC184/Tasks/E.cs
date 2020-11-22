using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security;

namespace Tasks
{
    public class E
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
            var A = new char[H][];
            var (sh, sw) = (0, 0);
            var (gh, gw) = (0, 0);

            var dict = new Dictionary<char, List<(int, int)>>();
            for (var i = 0; i < H; i++)
            {
                A[i] = Scanner.Scan<string>().ToCharArray();
                for (var j = 0; j < W; j++)
                {
                    if (A[i][j] == 'S') (sh, sw) = (i, j);
                    if (A[i][j] == 'G') (gh, gw) = (i, j);
                    if (A[i][j] != '.' && A[i][j] != '#')
                    {
                        if (!dict.ContainsKey(A[i][j])) dict[A[i][j]] = new List<(int, int)>();
                        dict[A[i][j]].Add((i, j));
                    }
                }
            }

            const int inf = (int)1e9;
            var G = new int[H][].Select(_ => Enumerable.Repeat(inf, W).ToArray()).ToArray();
            G[sh][sw] = 0;

            var queue = new Queue<(int, int)>();
            queue.Enqueue((sh, sw));
            var dh = new[] { 1, -1, 0, 0 };
            var dw = new[] { 0, 0, 1, -1 };
            while (queue.Any())
            {
                var (ch, cw) = queue.Dequeue();
                for (var i = 0; i < 4; i++)
                {
                    var (nh, nw) = (ch + dh[i], cw + dw[i]);
                    if (0 <= nh && nh < H && 0 <= nw && nw < W && A[nh][nw] != '#')
                    {
                        if (G[nh][nw] != inf) continue;
                        G[nh][nw] = G[ch][cw] + 1;
                        queue.Enqueue((nh, nw));
                    }
                }
                if (A[ch][cw] == '.' || A[ch][cw] == 'S' || A[ch][cw] == 'G') continue;
                foreach (var (nh, nw) in dict[A[ch][cw]])
                {
                    if (G[nh][nw] != inf) continue;
                    G[nh][nw] = G[ch][cw] + 1;
                    queue.Enqueue((nh, nw));
                }
                dict[A[ch][cw]].Clear();
            }

            // Console.WriteLine(string.Join("\n", G.Select(x => string.Join(" ", x))));

            Console.WriteLine(G[gh][gw] == inf ? -1 : G[gh][gw]);
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
