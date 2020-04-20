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
            var n = int.Parse(Console.ReadLine());
            var vi = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            Array.Sort(vi);
            Console.WriteLine(vi.Aggregate((x, y) => (x + y) / 2.0));
        }
    }
}
