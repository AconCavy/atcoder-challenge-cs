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
            var nt = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var min = 1001;
            for (var i = 0; i < nt[0]; i++)
            {
                var ct = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                if (ct[1] <= nt[1]) min = Math.Min(ct[0], min);
            }
            Console.WriteLine(min == 1001 ? "TLE" : min.ToString());
        }
    }
}
