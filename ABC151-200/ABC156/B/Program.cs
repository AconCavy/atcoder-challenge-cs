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
            var nk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var n = nk[0];
            var num = 0;

            while (true)
            {
                n /= nk[1];
                num++;
                if (n == 0) break;
            }

            Console.WriteLine(num);
        }
    }
}
