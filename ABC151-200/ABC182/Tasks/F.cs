using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class F
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
            var (N, X) = Scanner.Scan<int, long>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var x = new long[N];
            var t = new long[N];
            const long linf = (long)1e18;
            Array.Fill(t, linf);
            for (var i = N - 1; i >= 0; i--)
            {
                x[i] = X / A[i];
                X %= A[i];
                if (i > 0) t[i - 1] = A[i] / A[i - 1];
            }
            var dp = new long[2];
            dp[0] = 1;
            for (var i = 0; i < N; i++)
            {
                var prev = new long[2];
                (dp, prev) = (prev, dp);

                for (var j = 0; j < 2; j++)
                {
                    var y = x[i] + j;
                    if (y == t[i]) dp[1] += prev[j];
                    else if (y == 0) dp[0] += prev[j];
                    else
                    {
                        dp[0] += prev[j];
                        dp[1] += prev[j];
                    }
                }
            }

            Console.WriteLine(dp[0]);
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
