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
            var ABK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var A = ABK[0];
            var B = ABK[1];
            var K = ABK[2];
            for (var i = A; i <= Math.Min(A + K - 1, B); i++)
            {
                Console.WriteLine(i);
            }
            for (var i = Math.Max(B - K + 1, A + K); i <= B; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
