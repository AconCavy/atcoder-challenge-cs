using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var NMX = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var left = NMX[1] - A.Count(x => x <= NMX[2]);
            var right = NMX[1] - left;
            Console.WriteLine(Math.Min(left, right));
        }
    }
}
