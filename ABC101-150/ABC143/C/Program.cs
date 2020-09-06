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
            var s = Console.ReadLine();
            var count = 1;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] != s[i - 1])
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
