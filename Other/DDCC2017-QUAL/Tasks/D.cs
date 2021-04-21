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
            var (A, B) = Scanner.Scan<long, long>();
            var G = new bool[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = Scanner.Scan<string>().Select(x => x == 'S').ToArray();
            }

            var (nssym, ewsym) = (true, true);
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    nssym &= G[i][j] == G[H - 1 - i][j];
                    ewsym &= G[i][j] == G[i][W - 1 - j];
                }
            }

            var (nsew, ns, ew) = (0, 0, 0);
            for (var i = 0; i < H / 2; i++)
            {
                for (var j = 0; j < W / 2; j++)
                {
                    if (G[i][j] && G[H - 1 - i][j] && G[i][W - 1 - j] && G[H - 1 - i][W - 1 - j])
                    {
                        G[i][j] = G[H - 1 - i][j] = G[i][W - 1 - j] = G[H - 1 - i][W - 1 - j] = false;
                        nsew++;
                    }
                }
            }

            for (var i = 0; i < H / 2; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (G[i][j] && G[H - 1 - i][j]) ns++;
                }
            }

            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W / 2; j++)
                {
                    if (G[i][j] && G[i][W - 1 - j]) ew++;
                }
            }

            var answer = (nsew + 1) * (A + B) + nsew * Math.Max(A, B);
            answer += Math.Max(A * ns, B * ew);
            if (nssym) answer -= A;
            if (ewsym) answer -= B;

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
