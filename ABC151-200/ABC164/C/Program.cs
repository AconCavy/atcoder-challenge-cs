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
            var n = int.Parse(Console.ReadLine());
            var list = new List<string>();
            for (var i = 0; i < n; i++)
            {
                var s = Console.ReadLine();
                list.Add(s);
            }
            Console.WriteLine(list.Distinct().Count());
        }
    }
}
