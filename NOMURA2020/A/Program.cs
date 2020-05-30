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
            var hmhmk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var h1 = hmhmk[0];
            var m1 = hmhmk[1];
            var h2 = hmhmk[2];
            var m2 = hmhmk[3];
            var k = hmhmk[4];
            var h = h2 - h1;
            var m = m2 - m1;
            Console.WriteLine(h * 60 + m - k);
        }
    }
}
