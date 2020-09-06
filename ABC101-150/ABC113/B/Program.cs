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
            var n = int.Parse(Console.ReadLine());
            var ta = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            var hi = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            var min = 100000.0;
            var answer = 0;
            for (var i = 0; i < hi.Length; i++)
            {
                var tmp = Math.Abs(ta[1] - (ta[0] - hi[i] * 0.006));
                if (tmp < min)
                {
                    min = tmp;
                    answer = i + 1;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
