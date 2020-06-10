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
            var a = 0;
            var b = 0;
            var c = 0;
            for (var i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'a': a++; break;
                    case 'b': b++; break;
                    case 'c': c++; break;
                }
            }
            Console.WriteLine(a == 1 && b == 1 && c == 1 ? "Yes" : "No");
        }
    }
}
