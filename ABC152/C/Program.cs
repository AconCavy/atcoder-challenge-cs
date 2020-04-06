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
            var pi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var count = 0;
            var min = n;
            for (var i = 0; i < n; i++)
            {
                var val = pi[i];
                if (val <= min)
                {
                    count++;
                    min = val;
                }
            }
            Console.WriteLine(count);
        }
    }
}
