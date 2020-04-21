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
            var kx = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var result = new List<int>();
            for (var i = kx[1] - (kx[0] - 1); i < kx[1] + kx[0]; i++)
            {
                result.Add(i);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
