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
            var (N, M, K, Q) = Scanner.Scan<int, int, int, int>();
            var P0 = new List<long>();
            var P1 = new List<long>();
            for (var i = 0; i < N; i++)
            {
                var (P, T) = Scanner.Scan<long, int>();
                (T == 0 ? P0 : P1).Add(P);
            }

            P0.Sort();
            P1.Sort();

            var cum0 = new long[P0.Count + 1];
            var cum1 = new long[P1.Count + 1];
            for (var i = 0; i < P0.Count; i++)
            {
                cum0[i + 1] = cum0[i] + P0[i];
            }

            for (var i = 0; i < P1.Count; i++)
            {
                cum1[i + 1] = cum1[i] + P1[i];
                if (i % K == 0) cum1[i + 1] += Q;
            }

            const long inf = (long)1e18;
            var answer = inf;
            for (var i = 0; i < cum0.Length; i++)
            {
                var j = M - i;
                if (0 <= j && j < cum1.Length) answer = Math.Min(answer, cum0[i] + cum1[j]);
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
