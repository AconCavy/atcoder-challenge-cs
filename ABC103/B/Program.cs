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
            var answer = false;
            for (var i = 0; i < s.Length; i++)
            {
                var left = s.Substring(i, s.Length - i);
                var right = s.Substring(0, i);
                if (left + right == t) answer = true;
            }
            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
