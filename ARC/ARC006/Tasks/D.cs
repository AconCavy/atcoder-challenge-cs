using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var G = new string[H].Select(_ => Scanner.Scan<string>()).ToArray();
            var (a, b, c) = (0, 0, 0);
            const int ca = 12;
            const int cb = 16;
            const int cc = 11;
            var used = new bool[H, W];

            bool IsSquared(int n)
            {
                var sqrt = (int)Math.Sqrt(n);
                return sqrt * sqrt == n;
            }

            var D8 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1) };
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (G[i][j] == '.') continue;
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue((i, j));
                    var count = 1;
                    used[i, j] = true;
                    while (queue.Any())
                    {
                        var (ch, cw) = queue.Dequeue();
                        foreach (var (dh, dw) in D8)
                        {
                            var (nh, nw) = (ch + dh, cw + dw);
                            if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                            if (used[nh, nw] || G[nh][nw] == '.') continue;
                            used[nh, nw] = true;
                            count++;
                            queue.Enqueue((nh, nw));
                        }
                    }

                    if (count % ca == 0 && IsSquared(count / ca)) a++;
                    else if (count % cb == 0 && IsSquared(count / cb)) b++;
                    else if (count % cc == 0 && IsSquared(count / cc)) c++;
                }
            }

            Console.WriteLine($"{a} {b} {c}");
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
