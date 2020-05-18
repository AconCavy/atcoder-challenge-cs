using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var hw = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var all = hw[0] * hw[1];
            var grid = new int[all];
            var graph = new List<int>[all].Select(x => new List<int>()).ToArray();
            for (var y = 0; y < hw[0]; y++)
            {
                var s = Console.ReadLine();
                for (var x = 0; x < s.Length; x++)
                {
                    var current = hw[1] * y + x;
                    grid[current] = s[x] == '.' ? 0 : 1;
                    var right = current + 1;
                    var down = current + hw[1];
                    if (right % hw[1] != 0) graph[current].Add(right);
                    if (down < all) graph[current].Add(down);
                }
            }
            var queue = new Queue<int>();
            queue.Enqueue(0);
            var depths = Enumerable.Repeat(-1, all).ToArray();
            depths[0] = 0;
            var costs = Enumerable.Repeat(all, all).ToArray();
            costs[0] = grid[0];
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var next in graph[current])
                {
                    depths[next] = depths[current] + 1;
                    if (costs[next] == all)
                        queue.Enqueue(next);
                    var tmp = grid[next] == 1 && grid[current] == 0 ? 1 : 0;
                    costs[next] = Math.Min(costs[next], costs[current] + tmp);
                }
            }
            Console.WriteLine(costs[costs.Length - 1]);
        }
    }
}
