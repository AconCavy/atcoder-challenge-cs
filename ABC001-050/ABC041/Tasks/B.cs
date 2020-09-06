using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var ABC = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var p = (long)1e9 + 7;
            Console.WriteLine(ABC.Aggregate(1L, (x, y) => (x * y) % p));
        }
    }
}
