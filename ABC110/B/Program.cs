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
            var nmxy = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var n = nmxy[0];
            var m = nmxy[1];
            var x = nmxy[2];
            var y = nmxy[3];
            var xi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var yi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            if (x >= y)
            {
                Console.WriteLine("War");
                return;
            }
            var xMax = xi.Max();
            var yMin = yi.Min();
            Console.WriteLine(xMax < yMin && x < xMax + 1 && xMax + 1 <= y ? "No War" : "War");
        }
    }
}
