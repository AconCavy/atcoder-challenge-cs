using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var (N, M) = Scanner.Scan<int, int>();
            var E = new List<(int U, int V)>();
            for (var i = 0; i < M; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                E.Add((a, b));
            }

            E.Sort((x, y) =>
            {
                var ret = x.U.CompareTo(y.U);
                return ret == 0 ? y.V.CompareTo(x.V) : ret;
            });

            var B = E.Select(x => (long)x.V).ToArray();
            var answer = LongestIncreasingSubsequence(B).Length;

            Console.WriteLine(answer);
        }

        public static long[] LongestIncreasingSubsequence(long[] source)
        {
            var dp = new long[source.Length];
            Array.Fill(dp, long.MaxValue);
            var idx = new int[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                var lb = LowerBound(dp, source[i]);
                dp[lb] = source[i];
                idx[i] = lb;
            }
            var lis = new long[LowerBound(dp, long.MaxValue)];
            for (var i = source.Length - 1; i >= 0; i--)
            {
                lis[idx[i]] = source[i];
            }
            return lis;
        }
        public static int LowerBound(long[] source, long key)
        {
            var (l, r) = (-1, source.Length);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (source[m] >= key) r = m;
                else l = m;
            }
            return r;
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
