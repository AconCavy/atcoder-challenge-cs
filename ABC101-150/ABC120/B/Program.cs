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
            var abk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var vals = new List<int>();
            var max = GCD(abk[0], abk[1]);
            var count = 0;
            for (var i = max; i >= 1; i--)
            {
                if (max % i == 0) count++;
                if (count == abk[2])
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }

        static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
    }
}
