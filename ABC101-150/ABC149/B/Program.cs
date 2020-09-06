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
            var abk = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var diff = abk[0] - abk[2];
            var a = diff <= 0 ? 0 : diff;
            var b = abk[1] + (diff >= 0 ? 0 : diff);
            b = (b < 0 ? 0 : b);
            Console.WriteLine($"{a} {b}");
        }
    }
}
