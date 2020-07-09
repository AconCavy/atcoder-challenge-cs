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
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var min = 1001;
            var max = 0;
            for (var i = 0; i < A.Length; i++)
            {
                max = Math.Max(max, A[i]);
                min = Math.Min(min, A[i]);
            }
            Console.WriteLine(max - min);
        }
    }
}
