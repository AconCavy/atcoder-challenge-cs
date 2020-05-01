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
            var rdx = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var x = rdx[2];
            for (var i = 0; i < 10; i++)
            {
                x = rdx[0] * x - rdx[1];
                Console.WriteLine(x);
            }
        }
    }
}
