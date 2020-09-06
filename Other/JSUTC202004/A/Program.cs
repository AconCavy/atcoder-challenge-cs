using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var slr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            if (slr[0] < slr[1])
            {
                Console.WriteLine(slr[1]);
            }
            else if (slr[2] < slr[0])
            {
                Console.WriteLine(slr[2]);
            }
            else
            {
                Console.WriteLine(slr[0]);
            }
        }
    }
}
