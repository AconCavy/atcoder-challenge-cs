using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class BH
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
            var A = Scanner.ScanEnumerable<int>().ToArray();

            const int inf = (int)1e9;
            var dp = new int[N];
            var L = new int[N];
            var R = new int[N];

            var curr = 0;
            Array.Fill(dp, inf);
            for (var i = 0; i < N; i++)
            {
                var lb = LowerBound(dp, A[i]);
                dp[lb] = A[i];
                L[i] = lb + 1;
                if (lb == curr) curr++;
            }

            curr = 0;
            Array.Fill(dp, inf);
            for (var i = N - 1; i >= 0; i--)
            {
                var lb = LowerBound(dp, A[i]);
                dp[lb] = A[i];
                R[i] = lb + 1;
                if (lb == curr) curr++;
            }

            var answer = 0;
            for (var i = 0; i < N; i++)
            {
                answer = Math.Max(answer, L[i] + R[i] - 1);
            }

            Console.WriteLine(answer);
        }

        public static int LowerBound(int[] source, int key)
        {
            var (l, r) = (-1, source.Length - 1);
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
