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
            var ab = Console.ReadLine().Trim().Split(' ').ToArray();
            var a = long.Parse(ab[0]);
            var b = long.Parse(ab[1].Replace(".", ""));
            Console.WriteLine(a * b / 100);
        }
    }
}
