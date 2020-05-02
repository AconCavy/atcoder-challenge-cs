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
            var p = 0.0;
            for (var i = 0; i < nk[0]; i++)
            {
                var score = i + 1;
                var tmpP = 1.0 / nk[0];
                while (score < nk[1])
                {
                    score *= 2;
                    tmpP /= 2;
                }
                p += tmpP;
            }
            Console.WriteLine(p);
        }
    }
}
