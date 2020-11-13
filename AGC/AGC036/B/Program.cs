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
            var nk = Console.ReadLine().Trim().Split(' ').ToArray();
            var n = int.Parse(nk[0]);
            var k = long.Parse(nk[1]);
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
        }
    }
}
