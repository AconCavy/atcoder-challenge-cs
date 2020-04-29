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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var p = (long)Math.Pow(10, 9) + 7;
            var ng = new bool[nm[0] + 1];
            for (var i = 0; i < nm[1]; i++)
            {
                var a = int.Parse(Console.ReadLine());
                ng[a] = true;
            }

            var dp = new long[nm[0] + 1];
            dp[0] = 1;
            for (var i = 0; i < nm[0]; i++)
            {
                for (var j = i + 1; j <= Math.Min(nm[0], i + 2); j++)
                {
                    if (!ng[j])
                    {
                        dp[j] += dp[i];
                        dp[j] %= p;
                    }
                }
            }
            Console.WriteLine(dp[dp.Length - 1]);
        }
    }
}
