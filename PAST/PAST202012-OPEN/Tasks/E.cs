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
            var N = 30;
            var S = new bool[N, N];
            var empty = 0;
            for (var i = 0; i < H; i++)
            {
                var s = Scanner.Scan<string>();
                for (var j = 0; j < W; j++)
                {
                    if (s[j] == '.')
                    {
                        S[10 + i, 10 + j] = true;
                        empty++;
                    }
                }
            }

            var T = new List<(int H, int W)>();
            for (var i = 0; i < H; i++)
            {
                var t = Scanner.Scan<string>();
                for (var j = 0; j < W; j++)
                {
                    if (t[j] == '#') T.Add((i, j));
                }
            }

            if (T.Count > empty)
            {
                Console.WriteLine("No");
                return;
            }

            (int H, int W) Transpose(int h, int w)
            {
                return (w, W - 1 - h);
            }

            for (var t = 0; t < 4; t++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        var ok = true;
                        foreach (var (h, w) in T)
                        {
                            var (ch, cw) = (i + h, j + w);
                            if (0 <= ch && ch < N && 0 <= cw && cw < N && S[ch, cw]) continue;
                            ok = false;
                            break;
                        }

                        if (ok)
                        {
                            Console.WriteLine("Yes");
                            return;
                        }
                    }
                }

                T = T.Select(x => Transpose(x.H, x.W)).ToList();
            }

            Console.WriteLine("No");
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
