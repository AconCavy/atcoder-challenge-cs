using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var nk = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var n = nk[0];
            var k = nk[1];
            Console.WriteLine(Math.Ceiling((n - 1) / (k - 1)));
        }
    }
}
