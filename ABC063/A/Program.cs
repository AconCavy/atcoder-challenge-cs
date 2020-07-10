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
            var AB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var sum = AB.Sum();
            Console.WriteLine(sum >= 10 ? "error" : sum.ToString());
        }
    }
}
