using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class A
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
            var N = int.Parse(Console.ReadLine());
            var K = int.Parse(Console.ReadLine());
            var X = int.Parse(Console.ReadLine());
            var Y = int.Parse(Console.ReadLine());
            var answer = X * Math.Min(K, N) + Y * Math.Max(0, N - K);
            Console.WriteLine(answer);
        }
    }
}
