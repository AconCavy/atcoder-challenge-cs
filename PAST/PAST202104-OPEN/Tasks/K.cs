using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class K
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
            var PU = new List<(long P, long U)>();
            var (Q, T) = (0L, 0L);
            for (var i = 0; i < N; i++)
            {
                var (p, u) = Scanner.Scan<long, long>();
                if (p <= u)
                {
                    Q += p;
                    T += u;
                }
                else
                {
                    PU.Add((p, u));
                }
            }

            var dp = new Dictionary<long, long>();
            dp[T - Q] = Q;
            foreach (var (p, u) in PU)
            {
                var tmp = new Dictionary<long, long>();
                foreach (var (tq, t) in dp)
                {
                    if (!tmp.ContainsKey(tq)) tmp[tq] = t;
                    var v = tq + u - p;
                    if (!tmp.ContainsKey(v)) tmp[v] = 0;
                    tmp[v] = Math.Max(t, dp[tq] + p);
                }

                dp = tmp;
            }

            var answer = 0L;
            foreach (var (tq, q) in dp)
            {
                var r = q / 100 * 20;
                answer = Math.Max(answer, tq + r);
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
