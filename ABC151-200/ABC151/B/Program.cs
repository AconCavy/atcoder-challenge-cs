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
            var nkm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var score = nkm[0] * nkm[2] - ai.Sum();
            Console.WriteLine(score <= nkm[1] ? Math.Max(score, 0) : -1);
        }
    }
}
