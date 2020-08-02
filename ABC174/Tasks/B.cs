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
            var ND = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var (N, D) = (ND[0], ND[1]);
            var answer = 0;

            for (var i = 0; i < N; i++)
            {
                var XY = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
                var (X, Y) = (XY[0], XY[1]);
                if (D * D >= X * X + Y * Y) answer++;
            }
            Console.WriteLine(answer);
        }
    }
}
