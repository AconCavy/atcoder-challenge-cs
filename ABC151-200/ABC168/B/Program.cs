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
            var k = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            var answer = s.Length <= k ? s : s.Substring(0, k) + "...";
            Console.WriteLine(answer);
        }
    }
}
