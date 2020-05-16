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
            var nm = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            for (var i = nm[1] / nm[0]; i >= 1; i--)
            {
                if (nm[1] % i == 0)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }

        static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);
    }
}
