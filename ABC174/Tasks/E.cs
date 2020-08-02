using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
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
            var NK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, K) = (NK[0], NK[1]);
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var l = 0;
            var r = (int)1e9;
            while (r - l > 1)
            {
                var m = (l + r) / 2;
                var sum = A.Sum(x => (x - 1) / m);
                if (sum <= K) r = m;
                else l = m;
            }

            Console.WriteLine(r);
        }
    }
}
