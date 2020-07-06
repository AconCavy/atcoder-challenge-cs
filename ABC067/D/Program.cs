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
            var graph = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < N - 1; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 1));
            queue.Enqueue(new Tuple<int, int>(N - 1, 2));
            var depths = Enumerable.Repeat(-1, N).ToArray();
            depths[0] = 0;
            depths[N - 1] = 0;
            var colors = new int[N];
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var next in graph[current.Item1])
                {
                    if (colors[next] != 0) continue;
                    depths[next] = depths[current.Item1] + 1;
                    colors[next] = current.Item2;
                    queue.Enqueue(new Tuple<int, int>(next, colors[next]));
                }
            }
            var fennec = colors.Count(x => x == 1);
            var snuke = N - fennec;

            Console.WriteLine(fennec > snuke ? "Fennec" : "Snuke");
        }
    }
}
