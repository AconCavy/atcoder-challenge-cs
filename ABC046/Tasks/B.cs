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
            var NK = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var (N, K) = (NK[0], NK[1]);
            var answer = K;
            for (var i = 1; i < N; i++)
            {
                answer *= (K - 1);
            }

            Console.WriteLine(answer);
        }
    }
}
