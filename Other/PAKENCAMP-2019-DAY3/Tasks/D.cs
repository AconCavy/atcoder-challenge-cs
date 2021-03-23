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
            var N = Scanner.Scan<int>();
            var S = new string[5];
            for (var i = 0; i < 5; i++)
            {
                S[i] = Scanner.Scan<string>();
            }

            var dp = new int[N + 1, 3];
            for (var i = 0; i < N; i++)
            {
                var costs = new[] { 5, 5, 5 };
                for (var j = 0; j < 5; j++)
                {
                    switch (S[j][i])
                    {
                        case 'R': costs[0]--; break;
                        case 'B': costs[1]--; break;
                        case 'W': costs[2]--; break;
                        default: break;
                    }
                }

                for (var j = 0; j < 3; j++)
                {
                    dp[i + 1, j] = Math.Min(dp[i, (j + 1) % 3], dp[i, (j + 2) % 3]) + costs[j];
                }
            }

            const int inf = (int)1e9;
            var answer = inf;
            for (var i = 0; i < 3; i++)
            {
                answer = Math.Min(answer, dp[N, i]);
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
