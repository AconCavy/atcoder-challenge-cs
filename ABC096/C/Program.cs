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
            var hw = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var h = hw[0];
            var w = hw[1];
            var grid = new string[h];
            for (var i = 0; i < grid.Length; i++)
            {
                grid[i] = Console.ReadLine();
            }

            var answer = true;
            for (var y = 0; y < h - 1; y++)
            {
                for (var x = 0; x < w - 1; x++)
                {
                    if (grid[y][x] == '#')
                    {
                        var left = false;
                        var right = false;
                        var top = false;
                        var bottom = false;
                        if (x - 1 >= 0 && grid[y][x - 1] == '#') left = true;
                        if (x + 1 < w && grid[y][x + 1] == '#') right = true;
                        if (y - 1 >= 0 && grid[y - 1][x] == '#') top = true;
                        if (y + 1 < h && grid[y + 1][x] == '#') bottom = true;

                        if (!(left || right || top || bottom))
                        {
                            answer = false;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
