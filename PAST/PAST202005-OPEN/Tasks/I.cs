using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class i
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
            var Q = Scanner.Scan<int>();
            var isInv = false;
            var R = new long[N];
            var C = new long[N];
            for (var i = 0; i < N; i++)
            {
                R[i] = C[i] = i;
            }

            while (Q-- > 0)
            {
                var query = Scanner.ScanEnumerable<int>().ToArray();
                if (query[0] == 3)
                {
                    (R, C) = (C, R);
                    isInv = !isInv;
                }
                else
                {
                    var (a, b) = (query[1] - 1, query[2] - 1);

                    if (query[0] == 1)
                    {
                        (R[a], R[b]) = (R[b], R[a]);
                    }
                    else if (query[0] == 2)
                    {
                        (C[a], C[b]) = (C[b], C[a]);
                    }
                    else
                    {
                        var answer = isInv ? R[a] + C[b] * N : R[a] * N + C[b];
                        Console.WriteLine(answer);
                    }
                }
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
