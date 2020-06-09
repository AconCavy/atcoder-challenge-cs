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
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(A);
            var n = A[N - 1];
            var r = 0;
            var abs = n;
            for (var i = 0; i < N - 1; i++)
            {
                var tmp = Math.Abs(A[i] - n / 2);
                if (tmp <= abs)
                {
                    r = A[i];
                    abs = tmp;
                }
            }
            Console.WriteLine($"{n} {r}");
        }
    }
}
