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
            var n = double.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            var sum = 0.0;
            for (var i = 0; i < ai.Length; i++)
            {
                sum += 1 / ai[i];
            }
            Console.WriteLine(1 / sum);
        }
    }
}
