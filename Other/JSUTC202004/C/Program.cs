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
            var a = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var hook = new int[9];
            hook[2] = a[2];
            hook[1] = a[1] + 1;
            hook[0] = a[0] + 2;
            hook[5] = a[2] - 1;
            hook[4] = a[1] - 1 + (a[2] - 1 > 0 ? 1 : 0);
            hook[3] = a[0] - 1 + (a[1] - 1 > 0 ? (a[2] - 1 > 0 ? 2 : 1) : 0);
            hook[8] = a[2] - 2;
            hook[7] = a[1] - 2 + (a[2] - 2 > 0 ? 1 : 0);
            hook[6] = a[0] - 2 + (a[1] - 2 > 0 ? (a[2] - 2 > 0 ? 2 : 1) : 0);
            var pef = 1;
            foreach (var tmp in hook) pef *= Math.Max(tmp, 1);
            var length = a.Sum();
            Console.WriteLine(PermutationCount(length, length) / pef);
        }

        static long PermutationCount(int n, int k)
        {
            if (n < k) throw new ArgumentException();
            long result = n;
            for (var i = 1; i < k; i++)
                result *= (n - i);
            return result;
        }
    }
}
