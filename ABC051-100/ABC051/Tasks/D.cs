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
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, M) = (NM[0], NM[1]);
            var infinity = (int)1e9;
            var nodes = new (int A, int B, int C)[M];
            var graph = new int[N][].Select(x => x = Enumerable.Repeat(infinity, N).ToArray()).ToArray();
            for (var i = 0; i < N; i++)
            {
                graph[i][i] = 0;
            }
            for (var i = 0; i < M; i++)
            {
                var abc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = abc[0] - 1;
                var b = abc[1] - 1;
                var c = abc[2];
                graph[a][b] = Math.Min(graph[a][b], c);
                graph[b][a] = Math.Min(graph[b][a], c);
                nodes[i] = (a, b, c);
            }

            for (var k = 0; k < N; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        graph[i][j] = Math.Min(graph[i][j], graph[i][k] + graph[k][j]);
                    }
                }
            }

            var answer = M;
            for (var i = 0; i < M; i++)
            {
                var ok = false;
                for (var j = 0; j < N; j++)
                {
                    if (graph[j][nodes[i].A] + nodes[i].C == graph[j][nodes[i].B]) ok = true;
                }
                if (ok) answer--;
            }
            Console.WriteLine(answer);
        }
    }
}
