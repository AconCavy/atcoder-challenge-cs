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
            var nk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var hi = new long[nk[0]];
            for (var i = 0; i < hi.Length; i++)
            {
                hi[i] = long.Parse(Console.ReadLine());
            }
            Array.Sort(hi);
            var answer = hi[hi.Length - 1];
            for (var i = hi.Length - 1; i >= nk[1] - 1; i--)
            {
                answer = Math.Min(answer, hi[i] - hi[i - nk[1] + 1]);
                if (answer == 0) break;
            }
            Console.WriteLine(answer);
        }
    }
}
