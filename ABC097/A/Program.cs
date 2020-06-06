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
            var abcd = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var ab = Math.Abs(abcd[0] - abcd[1]) <= abcd[3];
            var bc = Math.Abs(abcd[1] - abcd[2]) <= abcd[3];
            var ac = Math.Abs(abcd[0] - abcd[2]) <= abcd[3];
            Console.WriteLine(ac || ab && bc ? "Yes" : "No");
        }
    }
}
