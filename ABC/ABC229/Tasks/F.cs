using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
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
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var B = Scanner.ScanEnumerable<long>().ToArray();
            var dp = new long[N + 1, 2, 2];
            const long inf = (long)1e18;
            for (var i = 0; i <= N; i++)
            {
                dp[i, 0, 0] = dp[i, 0, 1] = dp[i, 1, 0] = dp[i, 1, 1] = inf;
            }

            dp[1, 0, 0] = A[0];
            dp[1, 1, 1] = 0;

            for (var i = 2; i <= N; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    for (var k = 0; k < 2; k++)
                    {
                        for (var p = 0; p < 2; p++)
                        {
                            var c = dp[i - 1, p, k];
                            if (j == 0) c += A[i - 1];
                            if (j == p) c += B[i - 2];
                            dp[i, j, k] = Math.Min(dp[i, j, k], c);
                        }
                    }
                }
            }

            var answer = inf;
            for (var j = 0; j < 2; j++)
            {
                for (var k = 0; k < 2; k++)
                {
                    var c = dp[N, j, k];
                    if (j == k) c += B[N - 1];
                    answer = Math.Min(answer, c);
                }
            }

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
