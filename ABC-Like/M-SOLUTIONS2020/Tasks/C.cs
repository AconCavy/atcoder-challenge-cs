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
            var NK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, K) = (NK[0], NK[1]);
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            for (var i = K; i < N; i++)
            {
                Console.WriteLine(A[i - K] < A[i] ? "Yes" : "No");
            }
        }
    }
}
