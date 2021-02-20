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
            var (N, X) = Scanner.Scan<int, long>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            const long inf = (long)1e18;
            var answer = inf;
            var dp = new long[N + 1][].Select(_ => new long[N]).ToArray();
            for (var k = 1; k <= N; k++)
            {
                for (var i = 0; i <= k; i++) Array.Fill(dp[i], -inf);
                dp[0][0] = 0;
                foreach (var a in A)
                {
                    for (var i = k - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < k; j++)
                        {
                            if (dp[i][j] == -inf) continue;
                            var x = dp[i][j] + a;
                            dp[i + 1][x % k] = Math.Max(dp[i + 1][x % k], x);
                        }
                    }
                }
                if (dp[k][X % k] != -inf) answer = Math.Min(answer, (X - dp[k][X % k]) / k);
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
