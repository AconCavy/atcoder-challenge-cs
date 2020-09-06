using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class A
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
            var ABCD = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var (A, B, C, D) = (ABCD[0], ABCD[1], ABCD[2], ABCD[3]);
            var answer = Math.Max(A * B, C * D);
            Console.WriteLine(answer);
        }
    }
}
