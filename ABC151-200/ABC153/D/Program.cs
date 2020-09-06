using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var h = long.Parse(Console.ReadLine());

            Console.WriteLine(Rec(h));
        }

        static long Rec(long x)
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            return 2 * Rec((long)Math.Floor(x / 2.0)) + 1;
        }
    }
}
