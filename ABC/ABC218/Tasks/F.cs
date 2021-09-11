using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
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
            var G = new HashSet<int>[N].Select(x => new HashSet<int>()).ToArray();
            var E = new (int U, int V)[M];
            var dict = new Dictionary<(int, int), int>();
            for (var i = 0; i < M; i++)
            {
                var (s, t) = Scanner.Scan<int, int>();
                s--; t--;
                G[s].Add(t);
                E[i] = (s, t);
                dict[(s, t)] = i;
            }

            var queue = new Queue<int>();
            queue.Enqueue(0);
            var dp = new int[N];
            Array.Fill(dp, -1);
            dp[0] = 0;
            var prev = new int[N];
            Array.Fill(prev, -1);

            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                foreach (var v in G[u])
                {
                    if (dp[v] != -1) continue;
                    dp[v] = dp[u] + 1;
                    prev[v] = u;
                    queue.Enqueue(v);
                }
            }

            var route = new List<int>();
            var curr = N - 1;
            while (curr >= 0)
            {
                route.Add(curr);
                curr = prev[curr];
            }

            if (route.Last() != 0)
            {
                for (var i = 0; i < M; i++)
                {
                    Console.WriteLine(-1);
                }

                return;
            }

            var answer = new int[M];
            Array.Fill(answer, route.Count - 1);
            for (var i = 0; i + 1 < route.Count; i++)
            {
                var (t, s) = (route[i], route[i + 1]);
                var e = dict[(s, t)];

                queue.Enqueue(0);
                var depths = Enumerable.Repeat(-1, N).ToArray();
                depths[0] = 0;
                while (queue.Count > 0)
                {
                    var u = queue.Dequeue();
                    foreach (var v in G[u])
                    {
                        if (u == s && v == t) continue;
                        if (depths[v] != -1) continue;
                        depths[v] = depths[u] + 1;
                        queue.Enqueue(v);
                    }
                }

                answer[e] = depths[N - 1];
            }

            Console.WriteLine(string.Join("\n", answer));
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
