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
            var nx = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var xi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(xi);
            var answer = Math.Abs(xi[0] - nx[1]);
            for (var i = 1; i < xi.Length; i++)
            {
                answer = GCD(answer, xi[i] - xi[i - 1]);
            }
            Console.WriteLine(answer);
        }
        static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
    }
}
