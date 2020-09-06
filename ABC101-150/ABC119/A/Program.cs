using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var s = Console.ReadLine().Trim().Replace("/", "-");
            var time = DateTime.Parse(s);
            Console.WriteLine(time > DateTime.Parse("2019-04-30") ? "TBD" : "Heisei");
        }
    }
}
