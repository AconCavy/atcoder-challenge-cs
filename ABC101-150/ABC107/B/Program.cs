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
            var hw = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var h = hw[0];
            var w = hw[1];
            var grid = new string[h];
            var skipH = new Dictionary<int, int>();
            var skipW = new Dictionary<int, int>();
            for (var i = 0; i < h; i++)
            {
                grid[i] = Console.ReadLine();
            }
            for (var i = 0; i < h; i++)
            {
                if (grid[i].Count(x => x == '#') == 0) skipH[i] = 1;
            }
            for (var i = 0; i < w; i++)
            {
                if (grid.Count(x => x[i] == '#') == 0) skipW[i] = 1;
            }
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (!skipH.ContainsKey(i) && !skipW.ContainsKey(j)) Console.Write(grid[i][j]);
                }
                Console.Write("\n");
            }
        }
    }
}
