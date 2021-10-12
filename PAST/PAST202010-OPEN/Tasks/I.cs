using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class I
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
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var cum = new long[N * 2 + 1];
            for (var i = 0; i < N * 2; i++)
            {
                cum[i + 1] = cum[i] + A[i % N];
            }

            const long inf = (long)1e18;
            var answer = inf;

            var (l, r) = (0, 1);
            while (l < N)
            {
                while (r < l + N)
                {
                    var x = cum[r] - cum[l];
                    var y = cum[l + N] - cum[r];
                    var v = x - y;
                    answer = Math.Min(answer, Math.Abs(v));
                    if (v <= 0)
                    {
                        r++;
                    }
                    else
                    {
                        break;
                    }
                }

                while (l < r && l < N)
                {
                    var x = cum[r] - cum[l];
                    var y = cum[l + N] - cum[r];
                    var v = x - y;
                    answer = Math.Min(answer, Math.Abs(v));
                    if (v >= 0)
                    {
                        l++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(answer);
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
