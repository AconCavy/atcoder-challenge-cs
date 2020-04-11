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
            var count = 0;
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                if (s[i] != s[j]) count++;
            }
            Console.WriteLine(count);
        }
    }
}
