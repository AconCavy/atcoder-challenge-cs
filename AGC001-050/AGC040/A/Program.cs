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
            var s = Console.ReadLine();
            var ai = new long[s.Length + 1];

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '<') ai[i + 1] = Math.Max(ai[i + 1], ai[i] + 1);
            }
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '>') ai[i] = Math.Max(ai[i], ai[i + 1] + 1);
            }

            Console.WriteLine(ai.Sum());
        }
    }
}
