using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var G = new long[N][];
            for (var i = 0; i < N; i++)
            {
                G[i] = Scanner.ScanEnumerable<long>().ToArray();
            }

            var Q = Scanner.Scan<int>();
            var P = new long[Q];
            for (var i = 0; i < Q; i++)
            {
                P[i] = Scanner.Scan<long>();
            }

            var sum = new long[N + 1][].Select(x => new long[N + 1]).ToArray();
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    sum[i + 1][j + 1] += sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + G[i][j];
                }
            }

            var counts = new long[N * N + 1];

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    for (var ii = i + 1; ii <= N; ii++)
                    {
                        for (var jj = j + 1; jj <= N; jj++)
                        {
                            var count = sum[i][j] + sum[ii][jj] - sum[ii][j] - sum[i][jj];
                            var n = (ii - i) * (jj - j);
                            counts[n] = Math.Max(counts[n], count);
                        }
                    }
                }
            }

            for (var i = 1; i <= N * N; i++)
            {
                counts[i] = Math.Max(counts[i], counts[i - 1]);
            }

            for (var i = 0; i < Q; i++)
            {
                Console.WriteLine(counts[P[i]]);
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
