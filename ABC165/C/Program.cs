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
            var nmq = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var a = new long[nmq[0]];
            var sum = 0L;

            var q = new long[nmq[2]][];
            for (var i = 0; i < nmq[2]; i++)
            {
                q[i] = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            }
        }
    }
}
