using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var WHN = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (W, H, N) = (WHN[0], WHN[1], WHN[2]);
            var xMin = 0;
            var xMax = W;
            var yMin = 0;
            var yMax = H;
            for (var i = 0; i < N; i++)
            {
                var ABC = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var (A, B, C) = (ABC[0], ABC[1], ABC[2]);
                switch (C)
                {
                    case 1:
                        xMin = Math.Max(xMin, A);
                        break;
                    case 2:
                        xMax = Math.Min(xMax, A);
                        break;
                    case 3:
                        yMin = Math.Max(yMin, B);
                        break;
                    case 4:
                        yMax = Math.Min(yMax, B);
                        break;
                    default:
                        break;
                }
            }
            var answer = Math.Max(0, (xMax - xMin)) * Math.Max(0, (yMax - yMin));
            Console.WriteLine(answer);
        }
    }
}
