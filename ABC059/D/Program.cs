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
            var XY = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var (X, Y) = (XY[0], XY[1]);
            Console.WriteLine(Math.Abs(X - Y) > 1 ? "Alice" : "Brown");
        }
    }
}
