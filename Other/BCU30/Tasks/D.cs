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
            var (N, Q) = Scanner.Scan<int, int>();
            var X = Scanner.ScanEnumerable<long>().ToArray();
            var cumL = new long[N + 1];
            var cumR = new long[N + 1];
            for (var i = 0; i < N; i++) cumL[i + 1] = cumL[i] + X[i];
            for (var i = N; i > 0; i--) cumR[i - 1] = cumR[i] + X[i - 1];

            while (Q-- > 0)
            {
                var T = Scanner.Scan<long>();
                var neg = LowerBound(X, T);
                var pos = N - neg;
                var answer = (neg * T - cumL[neg]) + (cumR[neg] - pos * T);
                Console.WriteLine(answer);
            }
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
