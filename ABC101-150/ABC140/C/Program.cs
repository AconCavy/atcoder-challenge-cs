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
            var bi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var ai = new int[n];
            ai[0] = bi[0];
            ai[n - 1] = bi[bi.Length - 1];
            for (var i = 1; i < ai.Length - 1; i++)
            {
                ai[i] = Math.Min(bi[i - 1], bi[i]);
            }
            Console.WriteLine(ai.Sum());
        }
    }
}
