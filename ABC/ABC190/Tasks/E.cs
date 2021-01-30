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
            var (N, M) = Scanner.Scan<int, int>();
            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--; b--;
                G[a].Add(b);
                G[b].Add(a);
            }

            var K = Scanner.Scan<int>();
            var C = Scanner.ScanEnumerable<int>().Select(x => x - 1).ToArray();

            const int inf = (int)1e9;
            IEnumerable<int> Bfs(int s)
            {
                var costs = new int[N];
                Array.Fill(costs, inf);
                costs[s] = 0;

                var queue = new Queue<int>();
                queue.Enqueue(s);
                while (queue.Any())
                {
                    var u = queue.Dequeue();
                    foreach (var v in G[u])
                    {
                        if (costs[u] + 1 >= costs[v]) continue;
                        costs[v] = costs[u] + 1;
                        queue.Enqueue(v);
                    }
                }

                for (var i = 0; i < K; i++) yield return costs[C[i]];
            }

            var costs = new int[K][];
            for (var i = 0; i < K; i++) costs[i] = Bfs(C[i]).ToArray();

            var dp = new int[1 << K][];
            for (var i = 0; i < 1 << K; i++)
            {
                dp[i] = new int[K];
                Array.Fill(dp[i], inf);
            }

            for (var i = 0; i < K; i++) dp[1 << i][i] = 1;

            for (var b1 = 0; b1 < 1 << K; b1++)
            {
                for (var i = 0; i < K; i++)
                {
                    if ((b1 >> i & 1) == 0) continue;
                    var b2 = b1 ^ 1 << i;
                    for (var j = 0; j < K; j++)
                    {
                        if ((b2 >> j & 1) == 0) continue;
                        dp[b1][i] = Math.Min(dp[b1][i], dp[b2][j] + costs[i][j]);
                    }
                }
            }

            var answer = dp[^1].Min();

            Console.WriteLine(answer == inf ? -1 : answer);
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
