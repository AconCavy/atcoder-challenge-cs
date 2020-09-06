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
            var nab = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            if (nab[1] == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var tmp = nab[1] + nab[2];
            var mod = nab[0] % tmp;
            if (mod > nab[1]) mod = nab[1];
            var div = nab[0] / tmp;
            Console.WriteLine(nab[1] * div + mod);
        }
    }
}
