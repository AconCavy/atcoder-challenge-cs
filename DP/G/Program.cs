using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        static bool[] used;
        static List<int> nodes;
        static List<int>[] graph;

        public static void Solve()
        {
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, M) = (NM[0], NM[1]);

            graph = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a].Add(b);
            }

            used = new bool[N];
            nodes = new List<int>();

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

        private static void Dfs(int u)
        {
            if (used[u]) return;
            used[u] = true;
            foreach (var v in graph[u])
            {
                Dfs(v);
            }
            nodes.Add(u);
        }
    }
}
