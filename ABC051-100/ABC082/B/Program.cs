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
            var t = Console.ReadLine();
            s = string.Join("", s.OrderBy(x => x));
            t = string.Join("", t.OrderByDescending(x => x));
            if (s == t)
            {
                Console.WriteLine("No");
                return;
            }
            var tmp = new string[] { s, t };
            Array.Sort(tmp);
            Console.WriteLine(tmp[0] == s ? "Yes" : "No");
        }
    }
}
