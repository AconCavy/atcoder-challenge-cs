using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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

        public static void Solve()
        {
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NM[0];
            var M = NM[1];

            var graph = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }
            var queue = new Queue<int>();
            queue.Enqueue(0);
            var depths = Enumerable.Repeat(N + 1, N).ToArray();
            depths[0] = 0;
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var next in graph[current])
                {
                    if (depths[next] != N + 1) continue;
                    depths[next] = depths[current] + 1;
                    queue.Enqueue(next);
                }
            }
            Console.WriteLine(depths[N - 1] <= 2 ? "POSSIBLE" : "IMPOSSIBLE");
        }
    }
}
