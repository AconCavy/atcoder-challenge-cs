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
            var hw = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var h = hw[0];
            var w = hw[1];
            var grid = new int[h][];
            for (var i = 0; i < grid.Length; i++)
            {
                grid[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            }
            var answer = new Queue<string>();
            for (var y = 0; y < h; y++)
            {
                for (var x = 0; x < w; x++)
                {
                    if (grid[y][x] % 2 == 1)
                    {
                        if (x + 1 < w)
                        {
                            grid[y][x]--;
                            grid[y][x + 1]++;
                            answer.Enqueue($"{y + 1} {x + 1} {y + 1} {x + 2}");
                        }
                        else if (y + 1 < h)
                        {
                            grid[y][x]--;
                            grid[y + 1][x]++;
                            answer.Enqueue($"{y + 1} {x + 1} {y + 2} {x + 1}");
                        }
                    }
                }
            }

            Console.WriteLine(answer.Count());
            while (answer.Any())
            {
                Console.WriteLine(answer.Dequeue());
            }
        }
    }
}
