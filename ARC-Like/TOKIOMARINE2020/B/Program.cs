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
            var AV = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var BW = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var T = long.Parse(Console.ReadLine());
            var A = AV[0];
            var V = AV[1];
            var B = BW[0];
            var W = BW[1];
            if (B < A)
            {
                var a = A + V * (-T);
                var b = B + W * (-T);
                Console.WriteLine(a <= b ? "YES" : "NO");
            }
            else
            {
                var a = A + V * T;
                var b = B + W * T;
                Console.WriteLine(a >= b ? "YES" : "NO");
            }
        }
    }
}
