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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var graph = new List<int>[nm[0]].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < nm[1]; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }
            var queue = new Queue<int>();
            queue.Enqueue(0);
            var depths = Enumerable.Repeat(-1, nm[0]).ToArray();
            depths[0] = 0;
            var parents = new int[nm[0]];
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var next in graph[current])
                {
                    if (depths[next] != -1) continue;
                    parents[next] = current + 1;
                    depths[next] = depths[current] + 1;
                    queue.Enqueue(next);
                }
            }

            Console.WriteLine("Yes");
            for (var i = 1; i < parents.Length; i++)
            {
                Console.WriteLine(parents[i]);
            }
        }
    }
}
