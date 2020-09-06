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
            var abn = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            Func<long, long> f = x => (long)(Math.Floor((abn[0] * x) / (double)abn[1]) - abn[0] * Math.Floor(x / (double)abn[1]));
            Console.WriteLine(f(Math.Min(abn[1] - 1, abn[2])));
        }
    }
}
