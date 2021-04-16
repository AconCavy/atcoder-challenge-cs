using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var (A, B) = Scanner.Scan<int, int>();
            var (H, W) = Scanner.Scan<int, int>();
            var G = new bool[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = Scanner.Scan<string>().Select(x => x == '.').ToArray();
            }

            var (sh, sw) = (1, 1);
            var (gh, gw) = (H - 2, W - 2);
            var answer = false;

            (int dh, int dw) GetDelta(int d)
            {
                return d switch
                {
                    0 => (1, 0),
                    1 => (0, -1),
                    2 => (-1, 0),
                    3 => (0, 1),
                    _ => default
                };
            }

            bool Check(int h, int w)
            {
                if (h < 0 || H <= h || w < 0 || W <= w) return false;
                return G[h][w];
            }

            var used = new bool[H, W, 4, A + 1, B + 1];
            var next = new[] { (-1, -1, 0), (0, 0, 0), (1, 0, -1) };

            void Dfs(int ch, int cw, int cd, int cl, int cr)
            {
                used[ch, cw, cd, cl, cr] = true;

                if ((ch, cw, cl, cr) == (gh, gw, 0, 0))
                {
                    answer = true;
                    return;
                }

                foreach (var (dd, dl, dr) in next)
                {
                    var nd = (cd + dd + 4) % 4;
                    var (dh, dw) = GetDelta(nd);
                    var (nh, nw) = (ch + dh, cw + dw);
                    var (nl, nr) = (cl + dl, cr + dr);
                    if (nl < 0 || nr < 0) continue;
                    if (!Check(nh, nw)) continue;
                    if (used[nh, nw, nd, nl, nr]) continue;
                    Dfs(nh, nw, nd, nl, nr);
                }
            }

            Dfs(sh, sw, 0, A, B);
            Console.WriteLine(answer ? "Yes" : "No");
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
