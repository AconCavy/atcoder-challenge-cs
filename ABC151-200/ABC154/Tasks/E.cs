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
            var N = Scanner.Scan<string>();
            var K = Scanner.Scan<int>();
            var digits = N.Length;
            var dp = new long[digits + 1, 2, K + 1];
            dp[0, 0, 0] = 1;
            for (var digit = 0; digit < digits; digit++)
            {
                var value = N[digit] - '0';
                for (var j = 0; j < 2; j++)
                {
                    for (var k = 0; k <= K; k++)
                    {
                        var max = k == K ? 0 : j == 1 ? 9 : value;
                        for (var n = 0; n <= max; n++)
                        {
                            var next = j == 1 || n < value ? 1 : 0;
                            var count = Math.Min(K, n > 0 ? k + 1 : k);
                            dp[digit + 1, next, count] += dp[digit, j, k];
                        }
                    }
                }
            }
            var answer = dp[digits, 0, K] + dp[digits, 1, K];
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
