using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var N = long.Parse(Console.ReadLine());
            Func<long, long, long> F = (x, y) => Math.Max(x.ToString().Length, y.ToString().Length);
            var answer = (long)1e18;
            for (var a = 1; a <= (long)Math.Sqrt(N); a++)
            {
                if (N % a != 0) continue;
                var b = N / a;
                answer = Math.Min(answer, F(a, b));
            }

            Console.WriteLine(answer);
        }
    }
}
