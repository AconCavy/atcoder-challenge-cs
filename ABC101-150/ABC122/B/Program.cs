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
            var max = 0;
            var current = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A' || s[i] == 'C' || s[i] == 'G' || s[i] == 'T') current++;
                else current = 0;

                max = Math.Max(max, current);
            }
            Console.WriteLine(max);
        }
    }
}
