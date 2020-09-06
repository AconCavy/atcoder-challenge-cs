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
            var count = 0;
            var num = 1;
            while (num <= n)
            {
                if (num % 10 == 0 && num.ToString().Length % 2 == 0)
                {
                    num *= 10;
                    continue;
                }
                count++;
                num++;
            }
            Console.WriteLine(count);
        }
    }
}
