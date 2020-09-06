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
            var whxy = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            var max = whxy[0] * whxy[1] / 2.0;
            Console.WriteLine($"{max.ToString()} {(whxy[0] / 2.0 == whxy[2] && whxy[1] / 2.0 == whxy[3] ? 1 : 0)}");
        }
    }
}
