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
            var t = Console.ReadLine();
            var answer = true;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != t[t.Length - 1 - i]) answer = false;
            }
            Console.WriteLine(answer ? "YES" : "NO");
        }
    }
}
