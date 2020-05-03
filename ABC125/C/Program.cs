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
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var left = new long[ai.Length + 1];
            var right = new long[ai.Length + 1];
            for (int i = 0, j = ai.Length - 1; i < ai.Length && j >= 0; i++, j--)
            {
                left[i + 1] = GCD(left[i], ai[i]);
                right[j] = GCD(right[j + 1], ai[j]);
            }
            var gcds = new long[ai.Length];
            for (var i = 0; i < gcds.Length; i++)
            {
                gcds[i] = GCD(left[i], right[i + 1]);
            }

            Console.WriteLine(gcds.Max());
        }

        static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);
    }
}
