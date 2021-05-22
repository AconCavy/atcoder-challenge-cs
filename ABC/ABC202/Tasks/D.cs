using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

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
            var (A, B, K) = Scanner.Scan<int, int, long>();

            var dp = new long[A + 1, B + 1];
            dp[0, 0] = 1;
            for (var i = 0; i <= A; i++)
            {
                for (var j = 0; j <= B; j++)
                {
                    if (i > 0) dp[i, j] += dp[i - 1, j];
                    if (j > 0) dp[i, j] += dp[i, j - 1];
                }
            }

            var builder = new StringBuilder();
            void Dfs(int A, int B, long K)
            {
                if (A == 0 && B == 0) return;

                if (A == 0)
                {
                    builder.Append('b');
                    Dfs(A, B - 1, K);
                    return;
                }

                if (B == 0)
                {
                    builder.Append('a');
                    Dfs(A - 1, B, K);
                    return;
                }

                if (K <= dp[A - 1, B])
                {
                    builder.Append('a');
                    Dfs(A - 1, B, K);
                }
                else
                {
                    builder.Append('b');
                    Dfs(A, B - 1, K - dp[A - 1, B]);
                }
            }

            Dfs(A, B, K);

            var answer = builder.ToString();
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
