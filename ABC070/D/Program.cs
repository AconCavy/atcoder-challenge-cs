using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var N = int.Parse(Console.ReadLine());
            var graph = new List<Tuple<int, long>>[N].Select(x => new List<Tuple<int, long>>()).ToArray();
            for (var i = 0; i < N - 1; i++)
            {
                var abc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = abc[0] - 1;
                var b = abc[1] - 1;
                long c = abc[2];
                graph[a].Add(new Tuple<int, long>(b, c));
                graph[b].Add(new Tuple<int, long>(a, c));
            }

            var QK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var Q = QK[0];
            var K = QK[1] - 1;

            var queue = new Queue<int>();
            queue.Enqueue(K);
            var costs = Enumerable.Repeat((long)1e18 + 1, N).ToArray();
            costs[K] = 0;
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var next in graph[current])
                {
                    if (costs[next.Item1] <= costs[current] + next.Item2) continue;
                    costs[next.Item1] = costs[current] + next.Item2;
                    queue.Enqueue(next.Item1);
                }
            }


            var query = new Tuple<int, int>[Q];
            for (var i = 0; i < Q; i++)
            {
                var xy = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                query[i] = new Tuple<int, int>(xy[0] - 1, xy[1] - 1);
            }

            for (var i = 0; i < Q; i++)
            {
                var x = query[i].Item1;
                var y = query[i].Item2;
                Console.WriteLine(costs[x] + costs[y]);
            }
        }
    }
}
