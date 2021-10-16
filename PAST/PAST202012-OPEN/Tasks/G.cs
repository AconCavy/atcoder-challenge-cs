using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class G
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
            var S = new char[H][];
            var K = 0;
            for (var i = 0; i < H; i++)
            {
                S[i] = Scanner.Scan<string>().ToCharArray();
                foreach (var c in S[i])
                {
                    if (c == '#') K++;
                }
            }

            Console.WriteLine(K);

            var used = new bool[H, W];
            var answer = new (int H, int W)[K];
            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            bool Dfs(int ch, int cw, int d)
            {
                if (d >= K) return true;
                if (d == K - 1)
                {
                    answer[d] = (ch + 1, cw + 1);
                    return true;
                }
                used[ch, cw] = true;

                var ok = false;
                foreach (var (dh, dw) in D4)
                {
                    var (nh, nw) = (ch + dh, cw + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    if (used[nh, nw] || S[nh][nw] == '.') continue;
                    ok |= Dfs(nh, nw, d + 1);
                }

                if (ok) answer[d] = (ch + 1, cw + 1);
                used[ch, cw] = false;
                return ok;
            }

            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (S[i][j] == '.') continue;
                    if (Dfs(i, j, 0))
                    {
                        foreach (var (h, w) in answer)
                        {
                            Console.WriteLine($"{h} {w}");
                        }
                        return;
                    }
                }
            }
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
