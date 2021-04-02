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
            var (H, W) = Scanner.Scan<int, int>();
            var G = new bool[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = Scanner.Scan<string>().Select(x => x == '.').ToArray();
            }

            var r1 = new bool[H][].Select(_ => new bool[W]).ToArray();
            var D2 = new[] { (1, 0), (0, 1) };

            var queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));
            while (queue.Any())
            {
                var (ch, cw) = queue.Dequeue();
                if (r1[ch][cw]) continue;
                r1[ch][cw] = true;
                foreach (var (dh, dw) in D2)
                {
                    var (nh, nw) = (ch + dh, cw + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    if (G[nh][nw]) queue.Enqueue((nh, nw));
                }
            }

            for (var i = 0; i < H; i++)
            {
                var ok = true;
                for (var j = 0; j < W && ok; j++) ok &= G[i][j];
                if (!ok) continue;

                ok = false;
                for (var j = 0; j < W; j++) ok |= r1[i][j];
                if (!ok) continue;

                var r2 = new bool[H][].Select(_ => new bool[W]).ToArray();

                queue.Enqueue((i, 0));
                while (queue.Any())
                {
                    var (ch, cw) = queue.Dequeue();
                    if (r2[ch][cw]) continue;
                    r2[ch][cw] = true;
                    foreach (var (dh, dw) in D2)
                    {
                        var (nh, nw) = (ch + dh, cw + dw);
                        if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                        if (G[nh][nw]) queue.Enqueue((nh, nw));
                    }
                }

                ok = r2[^1][^1];

                if (ok)
                {
                    Console.WriteLine("Yay!");
                    return;
                }
            }

            Console.WriteLine(":(");
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
