using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var n = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var bi = ai.Select((x, i) => x - (i + 1)).ToArray();
            Array.Sort(bi);
            var b = n % 2 == 0 ? bi[n / 2 - 1] : bi[n / 2];
            var answer = ai.Select((x, i) => Math.Abs(x - (b + i + 1))).Sum();
            Console.WriteLine(answer);
        }
    }
}
