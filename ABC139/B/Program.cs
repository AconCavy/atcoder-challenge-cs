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
            var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var count = 0;
            if (ab[0] == 2) count = ab[1] - 1;
            else count = ab[1] / (ab[0] - 1) + (ab[1] % (ab[0] - 1) > 1 ? 1 : 0);
            Console.WriteLine(count);
        }
    }
}
