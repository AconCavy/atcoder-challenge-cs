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
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            var dp = Enumerable.Repeat((int)1e9, N).ToArray();
            dp[0] = 0;
            dp[1] = Math.Abs(A[1] - A[0]);
            for (var i = 2; i < N; i++)
            {
                dp[i] = Math.Min(dp[i], dp[i - 1] + Math.Abs(A[i - 1] - A[i]));
                dp[i] = Math.Min(dp[i], dp[i - 2] + Math.Abs(A[i - 2] - A[i]));
            }
            Console.WriteLine(dp[N - 1]);
        }
    }
}
