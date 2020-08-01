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
            var N = int.Parse(Console.ReadLine());
            var answer = (int)1e6 + 1;
            for (var h = 1; h <= Math.Sqrt(N); h++)
            {
                var w = N / h;
                answer = Math.Min(answer, Math.Abs(h - w) + N - h * w);
            }

            Console.WriteLine(answer);
        }
    }
}
