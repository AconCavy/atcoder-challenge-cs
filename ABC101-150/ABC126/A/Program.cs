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
            var nk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var s = Console.ReadLine();
            var result = "";
            for (var i = 0; i < s.Length; i++)
            {
                result += (i + 1 == nk[1] ? Char.ToLower(s[i]) : s[i]);
            }
            Console.WriteLine(result);
        }
    }
}
