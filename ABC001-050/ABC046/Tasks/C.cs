using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var N = int.Parse(Console.ReadLine());
            var a = 1L;
            var b = 1L;
            for (var i = 0; i < N; i++)
            {
                var XY = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                var (X, Y) = (XY[0], XY[1]);
                var max = (long)Math.Max((a - 1) / X + 1, (b - 1) / Y + 1);
                a = max * X;
                b = max * Y;
            }

            Console.WriteLine(a + b);
        }
    }
}
