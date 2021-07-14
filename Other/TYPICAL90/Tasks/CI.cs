using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class CI
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
            var (N, P, K) = Scanner.Scan<int, int, int>();
            const long inf = (long)1e18;
            var A = new long[N][];
            for (var i = 0; i < N; i++)
            {
                A[i] = Scanner.ScanEnumerable<long>().ToArray();
            }

            int GetCount(long x)
            {
                var G = new long[N, N];
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        G[i, j] = A[i][j] == -1 ? x : A[i][j];
                    }
                }

                for (var k = 0; k < N; k++)
                {
                    for (var i = 0; i < N; i++)
                    {
                        for (var j = 0; j < N; j++)
                        {
                            G[i, j] = Math.Min(G[i, j], G[i, k] + G[k, j]);
                        }
                    }
                }

                var count = 0;
                for (var i = 0; i < N; i++)
                {
                    for (var j = i + 1; j < N; j++)
                    {
                        if (G[i, j] <= P) count++;
                    }
                }

                return count;
            }

            bool Check1(long x) => GetCount(x) < K;
            bool Check2(long x) => GetCount(x) <= K;

            var answer = BinarySearch(0, inf, Check1) - BinarySearch(0, inf, Check2);
            if (answer > inf / 2) Console.WriteLine("Infinity");
            else Console.WriteLine(answer);
        }

        public static long BinarySearch(long ng, long ok, Func<long, bool> func)
        {
            while (Math.Abs(ok - ng) > 1)
            {
                var m = (ok + ng) / 2;
                if (func(m)) ok = m;
                else ng = m;
            }
            return ok;
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
