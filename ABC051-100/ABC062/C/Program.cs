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
            var HW = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var (H, W) = (HW[0], HW[1]);
            var answer = H * W + 1;
            for (var i = 0; i < 2; i++)
            {
                if (i == 1) (H, W) = (W, H);
                for (var h = 1; h < H; h++)
                {
                    var S = new long[3];
                    var y = (H - h);
                    var x = W / 2;
                    S[0] = h * W;
                    S[1] = y * x;
                    S[2] = y * (W - x);
                    var diff = S.Max() - S.Min();
                    answer = Math.Min(answer, diff);

                    x = y / 2;
                    S[1] = x * W;
                    S[2] = (y - x) * W;
                    diff = S.Max() - S.Min();
                    answer = Math.Min(answer, diff);
                }
            }

            Console.WriteLine(answer);
        }
    }
}
