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
            var (N, L) = Scanner.Scan<int, int>();
            var X = Scanner.ScanEnumerable<int>().ToArray();
            var (T1, T2, T3) = Scanner.Scan<int, int, int>();
            var H = new bool[L + 1];
            foreach (var x in X) H[x] = true;
            const long inf = (long)1e18;
            var dp = new long[L + 1];
            Array.Fill(dp, inf);
            dp[0] = H[0] ? T3 : 0;
            for (var i = 0; i < L; i++)
            {
                dp[i + 1] = Math.Min(dp[i + 1], dp[i] + T1 + (H[i + 1] ? T3 : 0));
                if (i + 2 <= L) dp[i + 2] = Math.Min(dp[i + 2], dp[i] + T1 + T2 + (H[i + 2] ? T3 : 0));
                if (i + 4 <= L) dp[i + 4] = Math.Min(dp[i + 4], dp[i] + T1 + T2 * 3 + (H[i + 4] ? T3 : 0));
            }

            dp[L] = Math.Min(dp[L], dp[L - 1] + (T1 + T2) / 2);
            if (L - 2 >= 0) dp[L] = Math.Min(dp[L], dp[L - 2] + (T1 + T2) / 2 + T2);
            if (L - 3 >= 0) dp[L] = Math.Min(dp[L], dp[L - 3] + (T1 + T2) / 2 + T2 * 2);

            var answer = dp[L];
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
