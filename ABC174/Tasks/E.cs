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
            // var NK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            // var (N, K) = (NK[0], NK[1]);
            // var A = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            // Array.Sort(A);
            // for (var i = 0; i < K; i++)
            // {
            //     A[N - 1] /= 2.0;
            //     Array.Sort(A);
            // }

            // Console.WriteLine(Math.Ceiling(A[N - 1]));
        }
    }
}
