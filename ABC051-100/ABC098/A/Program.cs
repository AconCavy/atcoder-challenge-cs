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
            var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var aab = ab[0] + ab[1];
            var asb = ab[0] - ab[1];
            var amb = ab[0] * ab[1];
            Console.WriteLine(Math.Max(Math.Max(aab, asb), amb));
        }
    }
}
