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
            var nm = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var hi = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var bad = new bool[hi.Length];
            for (var i = 0; i < nm[1]; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                var ha = hi[a];
                var hb = hi[b];
                if (ha > hb)
                {
                    bad[b] = true;
                }
                else if (ha < hb)
                {
                    bad[a] = true;
                }
                else
                {
                    bad[a] = true;
                    bad[b] = true;
                }

            }
            Console.WriteLine(bad.Where(x => !x).Count());
        }
    }
}
