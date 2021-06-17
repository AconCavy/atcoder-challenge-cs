using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            var (K, N, M) = Scanner.Scan<int, long, long>();
            var A = Scanner.ScanEnumerable<long>().ToArray();

            static long Ceiling(long a, long b) => (a + b - 1) / b;
            static long Floor(long a, long b) => a / b;

            bool Check(long x)
            {
                var (sl, sr) = (0L, 0L);
                foreach (var a in A)
                {
                    var ma = M * a;
                    sl += Ceiling(ma - x, N);
                    sr += Floor(ma + x, N);
                }

                return sl <= M && M <= sr;
            }

            const long inf = (long)1e18;
            var (l, r) = (0L, inf);
            while (r - l > 1)
            {
                var m = (l + r) / 2;
                if (Check(m)) r = m;
                else l = m;
            }

            var x = r;
            var L = new long[K];
            var R = new long[K];
            for (var i = 0; i < K; i++)
            {
                var ma = M * A[i];
                L[i] = Math.Max(0L, Ceiling(ma - x, N));
                R[i] = Floor(ma + x, N);
            }

            var s = L.Sum();
            var answer = new long[K];
            for (var i = 0; i < K; i++)
            {
                var min = Math.Min(M - s, R[i] - L[i]);
                answer[i] = L[i] + min;
                s += min;
            }

            Console.WriteLine(string.Join(" ", answer));
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
