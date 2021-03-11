using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var K = Scanner.Scan<int>();
            var R = new int[1 << K].Select(_ => Scanner.Scan<int>()).ToArray();

            double Calc(int q, int p) => 1d / (1d + Math.Pow(10, (p - q) / 400d));

            var dp = new double[K + 1, 1 << K];
            for (var i = 0; i < 1 << K; i++) dp[0, i] = 1;

            for (var k = 0; k < K; k++)
            {
                for (var i = 0; i < 1 << K; i++)
                {
                    var l = (i ^ (1 << k)) >> k << k;
                    var r = l + (1 << k);
                    var p = 0d;
                    for (var j = l; j < r; j++) p += dp[k, j] * Calc(R[i], R[j]);

                    dp[k + 1, i] = dp[k, i] * p;
                }
            }

            for (var i = 0; i < 1 << K; i++) Console.WriteLine(dp[K, i]);
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
