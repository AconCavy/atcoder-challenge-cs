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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var l = 1;
            var r = nm[0];
            for (var i = 0; i < nm[1]; i++)
            {
                var lr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                l = Math.Max(lr[0], l);
                r = Math.Min(lr[1], r);
            }
            Console.WriteLine(Math.Max(r - l + 1, 0));
        }
    }
}
