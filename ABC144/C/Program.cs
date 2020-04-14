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
            var n = long.Parse(Console.ReadLine());
            var res = n;
            for (long i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i != 0) continue;
                var j = n / i;
                res = Math.Min(n, i + j - 2);
            }
            Console.WriteLine(res);
        }
    }
}
