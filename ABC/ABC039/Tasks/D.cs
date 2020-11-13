using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var (H, W) = (HW[0], HW[1]);
            var G = new bool[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = Console.ReadLine().Select(x => x == '#').ToArray();
            }

            void Change(bool[][] grid, int h, int w, bool to)
            {
                var dx = new[] { -1, 0, 1 };
                var dy = new[] { -1, 0, 1 };
                for (var i = 0; i < dy.Length; i++)
                {
                    for (var j = 0; j < dx.Length; j++)
                    {
                        if (h + dy[i] < 0 || h + dy[i] >= H) continue;
                        if (w + dx[j] < 0 || w + dx[j] >= W) continue;
                        grid[h + dy[i]][w + dx[j]] = to;
                    }
                }
            }

            var answer = new bool[H][].Select(x => x = Enumerable.Repeat(true, W).ToArray()).ToArray();
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (!G[i][j])
                    {
                        Change(answer, i, j, false);
                    }
                }
            }

            var after = new bool[H][].Select(x => x = new bool[W]).ToArray();
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (answer[i][j])
                    {
                        Change(after, i, j, true);
                    }
                }
            }

            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (G[i][j] != after[i][j])
                    {
                        Console.WriteLine("impossible");
                        return;
                    }
                }
            }

            Console.WriteLine("possible");
            Console.WriteLine(string.Join("\n", answer.Select(x => new string(x.Select(x => x ? '#' : '.').ToArray()))));
        }
    }
}
