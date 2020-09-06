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
            var abc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var tmp1 = Math.Max(abc[0], abc[1]) * 10 + Math.Min(abc[0], abc[1]) + abc[2];
            var tmp2 = Math.Max(abc[1], abc[2]) * 10 + Math.Min(abc[1], abc[2]) + abc[0];
            Console.WriteLine(Math.Max(tmp1, tmp2));
        }
    }
}
