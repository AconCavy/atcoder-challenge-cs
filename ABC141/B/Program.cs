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
            var easy = true;
            for (var i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (s[i] == 'L') easy = false;
                }
                else
                {
                    if (s[i] == 'R') easy = false;
                }
                if (!easy) break;
            }
            Console.WriteLine(easy ? "Yes" : "No");
        }
    }
}
