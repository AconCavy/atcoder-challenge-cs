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
            var dn = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var d = dn[0];
            var n = dn[1];
            Console.WriteLine((long)Math.Pow(100, d) * (n < 100 ? n : 101));
        }
    }
}
