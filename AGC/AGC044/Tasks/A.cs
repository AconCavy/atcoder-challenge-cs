using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
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
            var T = Scanner.Scan<int>();
            const long inf = (long)1e18;
            while (T-- > 0)
            {
                var (N, A, B, C, D) = Scanner.Scan<long, long, long, long, long>();

                var pair = new[] { (2L, A), (3L, B), (5L, C) };
                var dict = new Dictionary<long, long>();
                dict[0] = 0;
                dict[1] = D;

                long Dfs(long x)
                {
                    if (dict.ContainsKey(x)) return dict[x];
                    var min = inf;
                    if (x < min / D) min = x * D;
                    foreach (var (p, k) in pair)
                    {
                        var (l, r) = (x / p * p, (x + p - 1) / p * p);
                        min = Math.Min(min, Math.Abs(l - x) * D + k + Dfs(l / p));
                        min = Math.Min(min, Math.Abs(r - x) * D + k + Dfs(r / p));
                    }

                    return dict[x] = min;
                }

                Console.WriteLine(Dfs(N));
            }
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
