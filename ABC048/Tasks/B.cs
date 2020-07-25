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
            var ABX = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var (A, B, X) = (ABX[0], ABX[1], ABX[2]);
            var answer = B / X - Math.Max(0, (A - 1)) / X;
            if (A == 0) answer++;
            Console.WriteLine(answer);
        }
    }
}
