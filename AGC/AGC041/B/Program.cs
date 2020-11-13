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
            var nmvp = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            Array.Sort(ai);
            var n = nmvp[0];
            var m = nmvp[1];
            var v = nmvp[2];
            var p = nmvp[3];
            var l = -1;
            var r = ai.Length;
            var problem = ai.Length - p;
            while (r - l > 1)
            {
                var x = (l + r) / 2;
                if (x >= problem)
                {
                    r = x;
                    continue;
                }

                var tmp = (v - p) * m;
                var max = ai[x] + m;
                if (max < ai[problem])
                {
                    l = x;
                    continue;
                }

                var sum = 0L;
                for (var i = 0; i <= problem; i++)
                {
                    if (i != x) sum += Math.Min(m, max - ai[i]);
                }

                if (tmp <= sum) r = x;
                else l = x;
            }
            Console.WriteLine(ai.Length - r);
        }
    }
}
