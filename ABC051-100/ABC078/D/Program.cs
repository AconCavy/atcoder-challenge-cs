using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var NZW = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NZW[0];
            var Y = NZW[2];
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            if (N == 1) Console.WriteLine(Math.Abs(A[0] - Y));
            else Console.WriteLine(Math.Max(Math.Abs(A[N - 1] - Y), Math.Abs(A[N - 2] - A[N - 1])));
        }
    }
}
