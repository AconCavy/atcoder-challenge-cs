using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class G
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
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, M) = (NM[0], NM[1]);

            var graph = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a].Add(b);
            }

            var used = new bool[N];
            var nodes = new List<int>();

            void Dfs(int u)
            {
                if (used[u]) return;
                used[u] = true;
                foreach (var v in graph[u])
                {
                    Dfs(v);
                }
                nodes.Add(u);
            }

            for (var i = 0; i < N; i++)
            {
                Dfs(i);
            }

            var answer = 0;
            var dp = new int[N];
            foreach (var u in nodes)
            {
                foreach (var v in graph[u])
                {
                    dp[u] = Math.Max(dp[u], dp[v] + 1);
                }
                answer = Math.Max(answer, dp[u]);
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
