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
            var hi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var count = 1;
            var max = hi[0];
            for (var i = 1; i < hi.Length; i++)
            {
                if (max <= hi[i]) count++;
                max = Math.Max(max, hi[i]);
            }
            Console.WriteLine(count);
        }
    }
}
