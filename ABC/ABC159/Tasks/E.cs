using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

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
            var (H, W, K) = Scanner.Scan<int, int, int>();
            var G = new int[H, W];
            for (var i = 0; i < H; i++)
            {
                var S = Scanner.Scan<string>();
                for (var j = 0; j < W; j++)
                {
                    G[i, j] = S[j] - '0';
                }
            }

            const int inf = (int)1e9;
            var answer = inf;

            for (var s = 0; s < 1 << (H - 1); s++)
            {
                var (hc, wc) = (0, 0);
                var map = new int[H];
                for (var i = 0; i < H; i++)
                {
                    map[i] = hc;
                    if ((s >> i & 1) == 1) hc++;
                }

                var prev = new int[hc + 1];
                var ok = true;
                for (var j = 0; j < W; j++)
                {
                    var curr = prev.ToArray();
                    for (var i = 0; i < H; i++)
                    {
                        curr[map[i]] += G[i, j];
                    }

                    if (curr.Any(x => x > K))
                    {
                        if (j == 0)
                        {
                            ok = false;
                            break;
                        }

                        wc++;
                        for (var i = 0; i <= hc; i++)
                        {
                            prev[i] = curr[i] - prev[i];
                        }
                    }
                    else
                    {
                        prev = curr;
                    }
                }

                if (ok) answer = Math.Min(answer, hc + wc);
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
