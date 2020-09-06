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
            var s = Console.ReadLine();
            var count0 = 0;
            var count1 = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0 && s[i] == '1') count0++;
                else if (i % 2 != 0 && s[i] == '0') count0++;
            }
            for (var i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0 && s[i] == '0') count1++;
                else if (i % 2 != 0 && s[i] == '1') count1++;
            }
            Console.WriteLine(Math.Min(count0, count1));
        }
    }
}
