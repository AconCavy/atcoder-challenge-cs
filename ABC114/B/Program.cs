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
            var s = Console.ReadLine();
            var min = 999;
            for (var i = 0; i <= s.Length - 3; i++)
            {
                var tmp = int.Parse(s.Substring(i, 3));
                min = Math.Min(min, Math.Abs(753 - tmp));
            }
            Console.WriteLine(min);
        }
    }
}
