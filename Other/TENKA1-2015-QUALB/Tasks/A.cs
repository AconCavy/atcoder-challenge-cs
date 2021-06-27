using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var dp = new long[20];
            dp[0] = dp[1] = 100;
            dp[2] = 200;
            for (var i = 3; i < 20; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }

            var answer = dp[^1];
            Console.WriteLine(answer);
        }
    }
}
