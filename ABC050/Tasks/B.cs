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
            var N = int.Parse(Console.ReadLine());
            var T = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var M = int.Parse(Console.ReadLine());
            var sum = T.Sum();
            var PX = new (int P, int X)[M];
            for (var i = 0; i < M; i++)
            {
                var px = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                PX[i] = (px[0], px[1]);
            }

            for (var i = 0; i < M; i++)
            {
                var (P, X) = PX[i];
                var answer = sum + X - T[P - 1];
                Console.WriteLine(answer);
            }
        }
    }
}
