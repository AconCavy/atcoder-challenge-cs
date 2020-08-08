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
            var (N, W) = Scanner.Scan<int, int>();
            var Vi = new int[N];
            var Wi = new int[N];
            var vMax = 0;
            var wMax = 0;
            for (var i = 0; i < N; i++)
            {
                var (v, w) = Scanner.Scan<int, int>();
                Vi[i] = v;
                Wi[i] = w;
                vMax = Math.Max(vMax, v);
                wMax = Math.Max(wMax, w);
            }

            var answer = 0L;
            if (wMax <= 1000)
            {
                var wSum = Wi.Sum(x => (long)x);
                var max = Convert.ToInt32(Math.Min(W, wSum));
                var dp = new long[2][].Select(x => x = new long[max + 1]).ToArray();
                var t = 1;
                for (var i = 0; i < N; i++)
                {
                    t ^= 1;
                    for (var j = 0; j <= max; j++)
                    {
                        if (j < Wi[i]) dp[t ^ 1][j] = dp[t][j];
                        else dp[t ^ 1][j] = Math.Max(dp[t][j], dp[t][j - Wi[i]] + Vi[i]);
                    }
                }
                t ^= 1;
                answer = dp[t][max];
            }
            else if (vMax <= 1000)
            {
                var vSum = Vi.Sum();
                var dp = new long[2][].Select(x => x = Enumerable.Repeat((long)1e18, vSum + 1).ToArray()).ToArray();
                dp[0][0] = 0;
                var t = 1;
                for (var i = 0; i < N; i++)
                {
                    t ^= 1;
                    for (var j = 0; j <= vSum; j++)
                    {
                        if (j - Vi[i] < 0) dp[t ^ 1][j] = dp[t][j];
                        else dp[t ^ 1][j] = Math.Min(dp[t][j], dp[t][j - Vi[i]] + Wi[i]);
                    }
                }
                t ^= 1;
                for (var j = 0; j <= vSum; j++)
                {
                    if (dp[t][j] <= W) answer = j;
                }
            }
            else
            {
                // void Dfs(int index, long v, long w)
                // {
                //     if (index >= N)
                //     {
                //         answer = Math.Max(answer, v);
                //         return;
                //     }
                //     if (w + Wi[index] <= W) Dfs(index + 1, v + Vi[index], w + Wi[index]);
                //     Dfs(index + 1, v, w);
                // }

                // Dfs(0, 0, 0);

                var m = N / 2;
                var first = new Dictionary<long, long>();
                for (var i = 0; i < 1 << m; i++)
                {
                    var (v, w) = (0L, 0L);
                    for (var j = 0; j < m; j++)
                    {
                        if ((i >> j & 1) == 1)
                        {
                            v += Vi[j];
                            w += Wi[j];
                        }
                    }
                    if (w > W) continue;
                    if (!first.ContainsKey(w)) first[w] = 0;
                    first[w] = Math.Max(first[w], v);
                }

                var n = N - m;
                var second = new Dictionary<long, long>();
                for (var i = 0; i < 1 << n; i++)
                {
                    var (v, w) = (0L, 0L);
                    for (var j = 0; j < n; j++)
                    {
                        if ((i >> j & 1) == 1)
                        {
                            v += Vi[m + j];
                            w += Wi[m + j];
                        }
                    }
                    if (w > W) continue;
                    if (!second.ContainsKey(w)) second[w] = 0;
                    second[w] = Math.Max(second[w], v);
                }

                var tmp = second.OrderBy(x => x.Key);
                var sW = tmp.Select(x => x.Key).ToArray();
                var sV = tmp.Select(x => x.Value).ToArray();

                foreach (var f in first)
                {
                    var (v, w) = (f.Value, f.Key);
                    var sv = 0L;
                    var sw = W - w;
                    foreach (var s in second)
                    {
                        if (s.Key <= sw) sv = Math.Max(sv, s.Value);
                    }
                    answer = Math.Max(answer, v + sv);
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
