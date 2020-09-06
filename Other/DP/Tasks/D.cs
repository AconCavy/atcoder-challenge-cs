using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var NW = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, W) = (NW[0], NW[1]);
            var w = new long[N];
            var v = new long[N];
            for (var i = 0; i < N; i++)
            {
                var wv = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                (w[i], v[i]) = (wv[0], wv[1]);
            }
            var dp = (new long[2][]).Select(x => x = new long[W + 1]).ToArray();
            var t = 1;
            for (var i = 0; i < N; i++)
            {
                t ^= 1;
                for (var j = 0; j <= W; j++)
                {
                    if (j < w[i])
                    {
                        dp[t ^ 1][j] = dp[t][j];
                    }
                    else
                    {
                        dp[t ^ 1][j] = Math.Max(dp[t][j], dp[t][j - w[i]] + v[i]);
                    }
                }
            }

            // Console.WriteLine(string.Join("\n", dp.Select(x => string.Join(" ", x))));
            Console.WriteLine(dp[t ^ 1][W]);
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
        }
    }
}
