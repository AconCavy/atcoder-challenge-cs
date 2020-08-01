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
            var NX = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, X) = (NX[0], NX[1]);
            Console.WriteLine(Math.Min(X - 1, N - X));
        }
    }
}
