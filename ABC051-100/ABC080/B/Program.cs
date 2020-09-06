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
            var N = Console.ReadLine();
            var n = int.Parse(N);
            var h = N.Sum(x => x - '0');
            Console.WriteLine(n % h == 0 ? "Yes" : "No");
        }
    }
}
