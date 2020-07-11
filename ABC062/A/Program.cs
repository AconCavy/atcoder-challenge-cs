using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var XY = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var group = new int[12] { 0, 2, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0 };
            var x = group[XY[0] - 1];
            var y = group[XY[1] - 1];
            Console.WriteLine(x == y ? "Yes" : "No");
        }
    }
}
