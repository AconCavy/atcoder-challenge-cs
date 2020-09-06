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
            var abck = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            if (abck[3] <= abck[0])
            {
                Console.WriteLine(abck[3]);
                return;
            }
            if (abck[3] <= abck[0] + abck[1])
            {
                Console.WriteLine(abck[0]);
                return;
            }
            Console.WriteLine(abck[0] - Math.Min(abck[2], (Math.Max(0, abck[3] - (abck[0] + abck[1])))));

        }
    }
}
