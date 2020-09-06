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
            var hi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var count = 0;
            var max = 0;
            for (var i = 0; i < hi.Length - 1; i++)
            {
                if (hi[i] >= hi[i + 1])
                {
                    count++;
                }
                else
                {
                    max = Math.Max(max, count);
                    count = 0;
                }
            }
            max = Math.Max(max, count);
            Console.WriteLine(max);
        }
    }
}
