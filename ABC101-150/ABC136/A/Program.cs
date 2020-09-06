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
            Console.WriteLine(Math.Max(abc[2] - (abc[0] - abc[1]), 0));
        }
    }
}
