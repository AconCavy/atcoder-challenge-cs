using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var (N, D) = Scanner.Scan<int, long>();

            var divisors = new[] { 2, 3, 5 };
            var counts = new int[3];
            for (var i = 0; i < 3; i++)
            {
                while (D % divisors[i] == 0)
                {
                    D /= divisors[i];
                    counts[i]++;
                }
            }

            if (D != 1) { Console.WriteLine(0); return; }

            var (c2, c3, c5) = (counts[0], counts[1], counts[2]);

            var dp = new double[N + 1, c2 + 1, c3 + 1, c5 + 1];
            dp[0, 0, 0, 0] = 1;
            for (var i = 0; i < N; i++)
            {
                for (var p2 = 0; p2 <= c2; p2++)
                {
                    for (var p3 = 0; p3 <= c3; p3++)
                    {
                        for (var p5 = 0; p5 <= c5; p5++)
                        {
                            var p = dp[i, p2, p3, p5] / 6;
                            var q2 = Math.Min(p2 + 1, c2);
                            var q3 = Math.Min(p3 + 1, c3);
                            dp[i + 1, p2, p3, p5] += p; // 1
                            dp[i + 1, q2, p3, p5] += p; // 2
                            dp[i + 1, p2, q3, p5] += p; // 3
                            dp[i + 1, Math.Min(p2 + 2, c2), p3, p5] += p; // 4
                            dp[i + 1, p2, p3, Math.Min(p5 + 1, c5)] += p; // 5
                            dp[i + 1, q2, q3, p5] += p; // 6
                        }
                    }
                }
            }

            var answer = dp[N, c2, c3, c5];
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
