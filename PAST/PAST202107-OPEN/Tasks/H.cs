using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class H
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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var S = A.Sum();

            const double inf = 1e18;
            var dp = new double[N + 1, S + 1, S + 1];
            for (var i = 0; i <= N; i++)
            {
                for (var j = 0; j <= S; j++)
                {
                    for (var k = 0; k <= S; k++)
                    {
                        dp[i, j, k] = inf;
                    }
                }
            }

            double F(double y1, double y2)
            {
                var dy = y2 - y1;
                return Math.Sqrt(1 + dy * dy);
            }

            dp[1, 0, 0] = 0;
            for (var i = 2; i <= N; i++)
            {
                for (var sum = 0; sum <= S; sum++)
                {
                    for (var last = 0; last <= sum; last++)
                    {
                        for (var j = 0; j <= S; j++)
                        {
                            dp[i, sum, last] = Math.Min(dp[i, sum, last], dp[i - 1, sum - last, j] + F(j, last));
                        }
                    }
                }
            }

            var answer = dp[N, S, 0];
            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
