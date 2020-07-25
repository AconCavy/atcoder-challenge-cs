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
            var NX = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, X) = (NX[0], NX[1]);
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var answer = 0L;
            for (var i = 1; i < A.Length; i++)
            {
                var tmp = Math.Max(0, A[i] + A[i - 1] - X);
                answer += tmp;
                A[i] = Math.Max(0, A[i] - tmp);
            }

            Console.WriteLine(answer);
        }
    }
}
