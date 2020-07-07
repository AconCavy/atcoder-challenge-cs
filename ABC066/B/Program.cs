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
            var S = Console.ReadLine();
            for (var i = S.Length - 1; i > 0; i--)
            {
                if (i % 2 == 1) continue;
                var t = S.Substring(0, i);
                var ok = true;
                for (var j = 0; j < i / 2; j++)
                {
                    if (t[j] != t[i / 2 + j]) ok = false;
                }
                if (ok)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine(0);
        }
    }
}
