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
            var HW = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var H = HW[0];
            var W = HW[1];
            var counts = new int[H][];
            var grid = new string[H];
            for (var i = 0; i < H; i++)
            {
                counts[i] = new int[W];
                grid[i] = Console.ReadLine();
            }
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (grid[i][j] == '#')
                    {
                        counts[i][j] = -1;
                        continue;
                    }
                    if (i - 1 >= 0)
                    {
                        if (j - 1 >= 0 && grid[i - 1][j - 1] == '#') counts[i][j]++;
                        if (grid[i - 1][j] == '#') counts[i][j]++;
                        if (j + 1 < W && grid[i - 1][j + 1] == '#') counts[i][j]++;
                    }
                    if (i + 1 < H)
                    {
                        if (j - 1 >= 0 && grid[i + 1][j - 1] == '#') counts[i][j]++;
                        if (grid[i + 1][j] == '#') counts[i][j]++;
                        if (j + 1 < W && grid[i + 1][j + 1] == '#') counts[i][j]++;
                    }
                    if (j - 1 >= 0 && grid[i][j - 1] == '#') counts[i][j]++;
                    if (j + 1 < W && grid[i][j + 1] == '#') counts[i][j]++;
                }
            }
            Console.WriteLine(string.Join("\n", counts.Select(x => string.Join("", x).Replace("-1", "#"))));
        }
    }
}
