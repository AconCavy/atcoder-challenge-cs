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
            var HWN = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (H, W, N) = (HWN[0], HWN[1], HWN[2]);
            var grid = new HashSet<(int, int)>();
            var AB = new (int A, int B)[N];
            for (var i = 0; i < N; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                AB[i] = (ab[0], ab[1]);
                grid.Add((ab[0], ab[1]));
            }
            var answer = new long[10];
            answer[0] = (long)(H - 2) * (W - 2);

            int GetCount(int h, int w)
            {
                var ret = 0;
                for (var y = -1; y <= 1; y++)
                {
                    for (var x = -1; x <= 1; x++)
                    {
                        if (grid.Contains((h + y, w + x))) ret++;
                    }
                }
                return ret;
            }

            var hash = new HashSet<(int, int)>();
            for (var k = 0; k < N; k++)
            {
                var (h, w) = AB[k];
                for (var i = -1; i <= 1; i++)
                {
                    if (h + i <= 1 || h + i >= H) continue;
                    for (var j = -1; j <= 1; j++)
                    {
                        if (w + j <= 1 || w + j >= W) continue;
                        if (hash.Contains((h + i, w + j))) continue;
                        hash.Add((h + i, w + j));
                        var count = GetCount(h + i, w + j);
                        answer[count]++;
                        answer[0]--;
                    }
                }
            }

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(answer[i]);
            }
        }
    }
}
