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
            var x = long.Parse(Console.ReadLine());
            var year = 0;
            var money = 100L;
            while (money < x)
            {
                year++;
                money = (long)(money * 1.01);
            }
            Console.WriteLine(year);
        }
    }
}
