using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
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
            var G = new bool[H][];
            var (sh, sw) = (0, 0);
            var (gh, gw) = (0, 0);

            for (var i = 0; i < H; i++)
            {
                var s = Scanner.Scan<string>();
                G[i] = s.Select(x => x != '#').ToArray();
                for (var j = 0; j < W; j++)
                {
                    if (s[j] == 's') (sh, sw) = (i, j);
                    if (s[j] == 'g') (gh, gw) = (i, j);
                }
            }

            var costs = new int[H, W];
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    costs[i, j] = -1;
                }
            }

            costs[sh, sw] = 0;
            var queue = new Queue<(int, int)>();
            queue.Enqueue((sh, sw));

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            while (queue.Any())
            {
                var (ch, cw) = queue.Dequeue();

                foreach (var (dh, dw) in D4)
                {
                    var (nh, nw) = (ch + dh, cw + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    if (costs[nh, nw] != -1) continue;
                    if (!G[nh][nw]) continue;
                    costs[nh, nw] = costs[ch, cw] + 1;
                    queue.Enqueue((nh, nw));
                }
            }

            var answer = costs[gh, gw] >= 0 ? "Yes" : "No";
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
