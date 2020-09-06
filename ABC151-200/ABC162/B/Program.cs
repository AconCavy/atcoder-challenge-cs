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
            var n = long.Parse(Console.ReadLine());
            var sum = 0L;
            for (var i = 1; i <= n; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
