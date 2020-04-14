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
            var isCalculatable = false;
            for (var i = 1; i < 10; i++)
            {
                if (n % i != 0) continue;
                var div = n / i;
                if (div < 10)
                {
                    isCalculatable = true;
                    break;
                }
            }
            Console.WriteLine(isCalculatable ? "Yes" : "No");
        }
    }
}
