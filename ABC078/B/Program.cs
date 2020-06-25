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
            var XYZ = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var X = XYZ[0];
            var Y = XYZ[1];
            var Z = XYZ[2];

            Console.WriteLine((X - Z) / (Y + Z));
        }
    }
}
