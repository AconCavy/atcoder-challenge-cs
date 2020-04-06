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
            var nk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var hi = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            if (nk[0] <= nk[1])
            {
                Console.WriteLine(0);
                return;
            }

            Array.Sort(hi);
            for (var i = 0; i < nk[1]; i++)
            {
                hi[hi.Length - i - 1] = 0;
            }
            Console.WriteLine(hi.Sum());
        }
    }
}
