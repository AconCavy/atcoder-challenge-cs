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
            var ABCD = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = Math.Min(ABCD[1], ABCD[3]) - Math.Max(ABCD[0], ABCD[2]);
            Console.WriteLine(Math.Max(0, answer));
        }
    }
}
