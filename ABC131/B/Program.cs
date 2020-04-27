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
            var nl = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var apples = Enumerable.Range(nl[1], nl[0]).ToArray();
            var minIndex = 0;
            for (var i = 0; i < apples.Length; i++)
            {
                if (Math.Abs(apples[minIndex]) > Math.Abs(apples[i])) minIndex = i;
            }
            apples[minIndex] = 0;
            Console.WriteLine(apples.Sum());
        }
    }
}
