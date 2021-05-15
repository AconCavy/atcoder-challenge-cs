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
            var G = new char[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = Scanner.Scan<string>().ToCharArray();
            }

            int GetCost(int h, int w) => G[h][w] == '+' ? 1 : -1;

            const int inf = (int)1e9;
            var dp = new int[H, W];
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    dp[i, j] = (i + j) % 2 == 0 ? -inf : inf;
                }
            }

            dp[H - 1, W - 1] = 0;

            for (var i = H - 1; i >= 0; i--)
            {
                for (var j = W - 1; j >= 0; j--)
                {
                    if ((i + j) % 2 == 0)
                    {
                        if (i + 1 < H) dp[i, j] = Math.Max(dp[i, j], dp[i + 1, j] + GetCost(i + 1, j));
                        if (j + 1 < W) dp[i, j] = Math.Max(dp[i, j], dp[i, j + 1] + GetCost(i, j + 1));
                    }
                    else
                    {
                        if (i + 1 < H) dp[i, j] = Math.Min(dp[i, j], dp[i + 1, j] - GetCost(i + 1, j));
                        if (j + 1 < W) dp[i, j] = Math.Min(dp[i, j], dp[i, j + 1] - GetCost(i, j + 1));
                    }
                }
            }

            var answer = "Draw";
            if (dp[0, 0] > 0) answer = "Takahashi";
            if (dp[0, 0] < 0) answer = "Aoki";

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
