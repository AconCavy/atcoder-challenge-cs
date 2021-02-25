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
            var used = new bool[H][];
            var queue = new Queue<(int, int, int)>();
            for (var i = 0; i < H; i++)
            {
                used[i] = Scanner.Scan<string>().Select(x => x == '#').ToArray();
                for (var j = 0; j < W; j++)
                {
                    if (used[i][j]) queue.Enqueue((i, j, 0));
                }
            }

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
            var G = new int[H][].Select(_ => new int[W]).ToArray();
            while (queue.Any())
            {
                var (ch, cw, cc) = queue.Dequeue();
                foreach (var (dh, dw) in D4)
                {
                    var (nh, nw) = (ch + dh, cw + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    if (used[nh][nw]) continue;
                    used[nh][nw] = true;
                    G[nh][nw] = cc + 1;
                    queue.Enqueue((nh, nw, cc + 1));
                }
            }

            var answer = G.Max(x => x.Max());
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
