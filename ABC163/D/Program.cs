using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var nk = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var sum = 1L;
            var p = (long)Math.Pow(10, 9) + 7;
            var all = AggregateSum(nk[0]);
            for (var i = nk[1]; i <= nk[0]; i++)
            {
                var min = AggregateSum(i - 1);
                var max = all - AggregateSum(nk[0] - i);
                sum += (max - min + 1) % p;
            }
            Console.WriteLine(sum % p);
        }

        static long AggregateSum(long x)
        {
            return (long)(x * (x + 1) / 2);
        }
    }
}
