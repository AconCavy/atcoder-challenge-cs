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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var p = ai.Distinct().Aggregate(1, (x, y) => LCM(x, y));
            Console.WriteLine(p % 2 == 0 ? (nm[1] / p + (nm[1] % p) / (p / 2)) : 0);
        }

        static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
        static int LCM(int a, int b) => a * b / GCD(a, b);
    }
}
