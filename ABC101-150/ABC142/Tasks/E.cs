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
            var (N, M) = Scanner.Scan<int, int>();
            var A = new int[M];
            var B = new int[M];
            var C = new int[M];
            for (var i = 0; i < M; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                var c = Scanner.ScanEnumerable<int>().ToArray();
                A[i] = a;
                var s = 0;
                for (var j = 0; j < b; j++) s |= 1 << (c[j] - 1);
                C[i] = s;
            }

            const int inf = (int)1e9;
            var dp = Enumerable.Repeat(inf, 1 << N).ToArray();
            dp[0] = 0;
            for (var i = 0; i < M; i++)
            {
                var s = C[i];
                for (var b = 0; b < 1 << N; b++)
                {
                    dp[b | s] = Math.Min(dp[b | s], dp[b] + A[i]);
                }
            }
            var answer = dp[^1];
            Console.WriteLine(answer == inf ? -1 : answer);
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
