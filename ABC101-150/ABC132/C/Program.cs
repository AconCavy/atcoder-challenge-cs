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
            var n = int.Parse(Console.ReadLine());
            var di = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            if (n % 2 == 1)
            {
                Console.WriteLine(0);
                return;
            }
            Array.Sort(di);
            Console.WriteLine(di[(n / 2)] - di[(n / 2) - 1]);
        }
    }
}
