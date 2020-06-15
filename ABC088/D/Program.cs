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
            var HW = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var H = HW[0];
            var W = HW[1];
            var answer = H * W;
            var grid = new bool[H][];
            for (var i = 0; i < H; i++)
            {
                grid[i] = new bool[W];
                var s = Console.ReadLine();
                for (var j = 0; j < s.Length; j++)
                {
                    grid[i][j] = s[j] == '.';
                    if (!grid[i][j]) answer--;
                }
            }

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 0));
            var depths = new int[H][].Select(x => x = Enumerable.Repeat(-1, W).ToArray()).ToArray();
            depths[0][0] = 0;
            while (queue.Any())
            {
                var current = queue.Dequeue();
                var x = current.Item1;
                var y = current.Item2;
                var nextDir = new List<Tuple<int, int>>();
                if (x > 0 && grid[y][x - 1]) nextDir.Add(new Tuple<int, int>(x - 1, y));
                if (x < W - 1 && grid[y][x + 1]) nextDir.Add(new Tuple<int, int>(x + 1, y));
                if (y > 0 && grid[y - 1][x]) nextDir.Add(new Tuple<int, int>(x, y - 1));
                if (y < H - 1 && grid[y + 1][x]) nextDir.Add(new Tuple<int, int>(x, y + 1));

                foreach (var next in nextDir)
                {

                    var nx = next.Item1;
                    var ny = next.Item2;

                    if (depths[ny][nx] != -1) continue;
                    depths[ny][nx] = depths[y][x] + 1;
                    queue.Enqueue(next);
                }
            }
            if (depths[H - 1][W - 1] == -1)
            {
                Console.WriteLine(-1);
                return;
            }
            answer -= depths[H - 1][W - 1] + 1;
            Console.WriteLine(answer);
        }
    }
}