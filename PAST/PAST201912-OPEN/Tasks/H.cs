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
            var N = Scanner.Scan<int>();
            var C = Scanner.ScanEnumerable<long>().ToArray();
            const long inf = (long)1e18;
            var minOdd = inf;
            var minAll = inf;
            for (var i = 0; i < N; i++)
            {
                if (i % 2 == 0) minOdd = Math.Min(minOdd, C[i]);
                minAll = Math.Min(minAll, C[i]);
            }

            var Q = Scanner.Scan<int>();
            var answer = 0L;
            var odd = 0L;
            var all = 0L;

            while (Q-- > 0)
            {
                var query = Scanner.ScanEnumerable<int>().ToArray();
                if (query[0] == 1)
                {
                    var (x, a) = (query[1] - 1, query[2]);

                    if (x % 2 == 0 && C[x] - odd - all < a) continue;
                    if (x % 2 == 1 && C[x] - all < a) continue;

                    C[x] -= a;
                    answer += a;

                    if (x % 2 == 0)
                    {
                        minOdd = Math.Min(minOdd, C[x] - odd - all);
                        minAll = Math.Min(minAll, C[x] - odd - all);
                    }
                    else
                    {
                        minAll = Math.Min(minAll, C[x] - all);
                    }
                }
                else if (query[0] == 2)
                {
                    var a = query[1];

                    if (minOdd < a) continue;
                    minOdd -= a;
                    minAll = Math.Min(minAll, minOdd);
                    odd += a;
                }
                else if (query[0] == 3)
                {
                    var a = query[1];

                    if (minAll < a) continue;
                    minOdd -= a;
                    minAll -= a;
                    all += a;
                }
            }

            answer += N * all;
            answer += (N + 1) / 2 * odd;

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
