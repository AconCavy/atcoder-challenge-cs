using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        static int N;
        static int M;
        static bool[][] graph;

        public static void Solve()
        {
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            (N, M) = (NM[0], NM[1]);
            graph = new bool[N][].Select(x => x = new bool[N]).ToArray();
            for (var i = 0; i < M; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a][b] = graph[b][a] = true;
            }
            var visit = new bool[N];
            visit[0] = true;
            Console.WriteLine(Dfs(0, visit));
        }

        public static int Dfs(int current, bool[] visit)
        {
            if (visit.All(x => x)) return 1;
            var count = 0;
            for (var i = 0; i < N; i++)
            {
                if (!graph[current][i]) continue;
                if (visit[i]) continue;
                visit[i] = true;
                count += Dfs(i, visit);
                visit[i] = false;
            }

            return count;
        }
    }
}
