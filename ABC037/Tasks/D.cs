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
            var (H, W) = Scanner.Scan<int, int>();
            var G = new int[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            }
            var p = (int)1e9 + 7;

            var dp = new long[H][].Select(x => x = new long[W]).ToArray();
            var dx = new[] { -1, 1, 0, 0 };
            var dy = new[] { 0, 0, -1, 1 };

            long Dfs(int h, int w)
            {
                if (dp[h][w] > 0) return dp[h][w];
                var ways = 1L;
                for (var k = 0; k < 4; k++)
                {
                    var y = h + dy[k];
                    var x = w + dx[k];
                    if (y < 0 || y >= H) continue;
                    if (x < 0 || x >= W) continue;
                    if (G[h][w] < G[y][x]) ways += Dfs(y, x) % p;
                }
                return dp[h][w] = ways;
            }

            var answer = 0L;
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    answer += Dfs(i, j);
                    answer %= p;
                }
            }

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
        }
    }
}
