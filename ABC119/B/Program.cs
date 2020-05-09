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
            var sum = 0.0;
            for (var i = 0; i < n; i++)
            {
                var xv = Console.ReadLine().Trim().Split(' ').ToArray();
                sum += (xv[1] == "JPY" ? double.Parse(xv[0]) : double.Parse(xv[0]) * 380000.0);
            }
            Console.WriteLine(sum);
        }
    }
}
