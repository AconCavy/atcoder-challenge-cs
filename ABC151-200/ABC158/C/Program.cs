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
            var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var res = -1;
            var a = ab[0] * 125;
            var mod = a % 100;
            var tmp = ((a / 100) + 1) * 10;
            if (ab[1] * 100 + mod == a) res = (int)Math.Ceiling(a / 10.0);
            else if (ab[1] * 10 == tmp) res = tmp;
            Console.WriteLine(res);
        }
    }
}
