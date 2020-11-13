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
            var n = long.Parse(Console.ReadLine());
            var max = (long)Math.Pow(10, 9);
            var x = (max - n % max) % max;
            var y = (n + x) / max;
            Console.WriteLine($"0 0 {max} 1 {x} {y}");
        }
    }
}
