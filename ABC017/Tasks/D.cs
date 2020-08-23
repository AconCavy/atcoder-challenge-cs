using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var (N, M) = Scanner.Scan<int, int>();
            var F = new long[N];
            for (var i = 0; i < N; i++)
            {
                F[i] = Scanner.Scan<int>();
            }
            var p = (int)1e9 + 7;
            var dp = new long[N + 1];
            dp[0] = 1;
            var tmp = 1L;
            var used = new bool[M + 1];
            var l = 0;
            var r = 0;
            while (r < N)
            {
                if (!used[F[r]])
                {
                    used[F[r]] = true;
                    r++;
                    dp[r] += tmp % p;
                    dp[r] %= p;
                    tmp += dp[r];
                    tmp %= p;
                }
                else
                {
                    used[F[l]] = false;
                    tmp -= dp[l];
                    tmp += p;
                    tmp %= p;
                    l++;
                }
            }

            Console.WriteLine(dp[N]);
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
        }
    }
}
