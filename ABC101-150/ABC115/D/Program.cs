using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var nx = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var n = (int)nx[0];
            var pi = new long[n];
            pi[0] = 1;
            var ai = new long[n];
            ai[0] = 1;
            for (var i = 1; i < nx[0]; i++)
            {
                pi[i] = pi[i - 1] * 2 + 1;
                ai[i] = ai[i - 1] * 2 + 3;
            }
            Console.WriteLine(F(ai, pi, n, nx[1]));
        }

        static long F(long[] all, long[] patties, int n, long x)
        {
            if (n == 0) return x <= 0 ? 0 : 1;
            else if (x <= 1 + all[n - 1]) return F(all, patties, n - 1, x - 1);
            else return patties[n - 1] + 1 + F(all, patties, n - 1, x - 2 - all[n - 1]);
        }
    }
}
