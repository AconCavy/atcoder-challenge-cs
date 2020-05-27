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
            var nk = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var xi = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var n = nk[0];
            var k = nk[1];
            var answer = Math.Abs(xi[n - 1] - xi[0]) * 2;
            for (var i = 0; i < n - k + 1; i++)
            {
                var left = Math.Abs(xi[i]) + Math.Abs(xi[i + k - 1] - xi[i]);
                var right = Math.Abs(xi[i + k - 1]) + Math.Abs(xi[i + k - 1] - xi[i]);
                answer = Math.Min(answer, Math.Min(left, right));
            }
            Console.WriteLine(answer);
        }
    }
}
