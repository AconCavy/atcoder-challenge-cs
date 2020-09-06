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
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var all = 0;
            var prev = 0;
            for (var i = 0; i < A.Length; i++)
            {
                all += Math.Abs(A[i] - prev);
                prev = A[i];
            }
            all += Math.Abs(prev);

            var tmp = new int[N + 2];
            for (var i = 0; i < A.Length; i++)
            {
                tmp[i + 1] = A[i];
            }
            for (var i = 1; i < tmp.Length - 1; i++)
            {
                var sub = Math.Abs(tmp[i] - tmp[i - 1]) + Math.Abs(tmp[i + 1] - tmp[i]);
                var add = Math.Abs(tmp[i + 1] - tmp[i - 1]);
                Console.WriteLine(all - sub + add);
            }
        }
    }
}
