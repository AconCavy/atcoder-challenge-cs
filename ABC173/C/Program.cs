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
            var HWK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var H = HWK[0];
            var W = HWK[1];
            var K = HWK[2];
            var grid = new bool[H][];
            var all = 0;
            for (var i = 0; i < H; i++)
            {
                var s = Console.ReadLine();
                grid[i] = s.Select(x => x == '#').ToArray();
                all += grid[i].Count(x => x);
            }
            if (all < K)
            {
                Console.WriteLine(0);
                return;
            }

            var answer = 0;

            for (var hb = 0; hb < (1 << H); hb++)
            {
                for (var wb = 0; wb < (1 << W); wb++)
                {
                    var count = 0;
                    for (var i = 0; i < H; i++)
                    {
                        if (((hb >> i) & 1) == 0) continue;
                        for (var j = 0; j < W; j++)
                        {
                            if (((wb >> j) & 1) == 0) continue;
                            if (grid[i][j]) count++;
                        }
                    }
                    if (count == K) answer++;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
