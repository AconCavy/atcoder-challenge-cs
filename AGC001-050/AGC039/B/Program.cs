using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var n = int.Parse(Console.ReadLine());

            var graph = new List<int>[n].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < graph.Length; i++)
            {
                var s = Console.ReadLine().Trim();
                for (var j = i + 1; j < s.Length; j++)
                {
                    if (s[j] == '1')
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }

            var answer = 0;
            for (var i = 0; i < graph.Length; i++)
            {
                var queue = new Queue<int>();
                queue.Enqueue(i);
                var depths = Enumerable.Repeat(-1, graph.Length).ToArray();
                depths[i] = 0;
                while (queue.Any())
                {
                    var current = queue.Dequeue();
                    foreach (var next in graph[current])
                    {
                        if (depths[next] != -1)
                        {
                            if (depths[current] % 2 != depths[next] % 2) continue;
                            Console.WriteLine(-1);
                            return;
                        }
                        depths[next] = depths[current] + 1;
                        queue.Enqueue(next);
                    }
                }
                answer = Math.Max(answer, depths.Max() + 1);
                if (answer == graph.Length) break;
            }
            Console.WriteLine(answer);
        }
    }
}
