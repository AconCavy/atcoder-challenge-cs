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
            var num = int.Parse(Console.ReadLine());
            var nn = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(nn.Distinct().Count() == num ? "YES" : "NO");
        }
    }
}
