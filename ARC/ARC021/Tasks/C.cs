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
            var K = Scanner.Scan<long>();
            var N = Scanner.Scan<int>();
            var B = new (long A, long D)[N];
            for (var i = 0; i < N; i++)
            {
                var (a, d) = Scanner.Scan<long, long>();
                B[i] = (a, d);
            }

            var (l, r) = (0L, (long)1e18);
            while (r - l > 1)
            {
                var m = (l + r) / 2;
                var count = 0L;
                foreach (var (a, d) in B)
                {
                    if (m >= a) count += (m - a) / d + 1;
                }
                if (count >= K) r = m;
                else l = m;
            }

            var answer = 0L;
            var k = 0L;
            foreach (var (a, d) in B)
            {
                if (r < a) continue;
                var n = (r - a) / d + 1;
                k += n;
                answer += n * a + n * (n - 1) / 2 * d;
            }

            answer += (K - k) * r;

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
