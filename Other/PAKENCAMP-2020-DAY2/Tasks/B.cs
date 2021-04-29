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
            var (H, W) = Scanner.Scan<int, int>();
            var G = new char[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = Scanner.Scan<string>().ToCharArray();
            }

            var memo = new int[H, W];
            const int inf = (int)1e9;
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    memo[i, j] = inf;
                }
            }

            memo[H - 1, W - 1] = G[H - 1][W - 1] == 'E' ? 0 : 1;

            for (var j = W - 1; j >= 0; j--)
            {
                for (var i = H - 1; i >= 0; i--)
                {
                    if (i + 1 < H)
                    {
                        var cost = G[i][j] == 'S' ? 0 : 1;
                        memo[i, j] = Math.Min(memo[i, j], memo[i + 1, j] + cost);
                    }

                    if (j + 1 < W)
                    {
                        var cost = G[i][j] == 'E' ? 0 : 1;
                        memo[i, j] = Math.Min(memo[i, j], memo[i, j + 1] + cost);
                    }
                }
            }

            var answer = memo[0, 0];
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
