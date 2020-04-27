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
            var abcd = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var all = abcd[1] - abcd[0] + 1;
            var c = (abcd[1] / abcd[2]) - ((abcd[0] - 1) / abcd[2]);
            var d = (abcd[1] / abcd[3]) - ((abcd[0] - 1) / abcd[3]);
            var lcm = LCM(abcd[2], abcd[3]);
            var e = (abcd[1] / lcm) - ((abcd[0] - 1) / lcm);
            Console.WriteLine(all - (c + d - e));
        }

        static long LCM(long a, long b) => a * b / GCD(a, b);
        static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);
    }
}
