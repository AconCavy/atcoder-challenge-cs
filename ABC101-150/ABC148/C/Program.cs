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
            var ab = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            Console.WriteLine(LCM(ab[0], ab[1]));
        }

        static long LCM(long a, long b) => a * b / GCD(a, b);
        static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);
    }
}
