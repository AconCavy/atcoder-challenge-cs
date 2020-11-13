using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
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
            var (N, M, L) = Scanner.Scan<int, int, long>();
            const long inf = (long)1e9 + 1;
            var F = new long[N][].Select(_ => Enumerable.Repeat(inf, N).ToArray()).ToArray();
            var D = new long[N][].Select(_ => Enumerable.Repeat(inf, N).ToArray()).ToArray();
            for (var i = 0; i < N; i++) F[i][i] = D[i][i] = 0;
            for (var i = 0; i < M; i++)
            {
                var (A, B, C) = Scanner.Scan<int, int, long>();
                A--; B--;
                F[A][B] = F[B][A] = C;
            }

            var Q = Scanner.Scan<int>();
            var S = new int[Q];
            var T = new int[Q];
            for (var i = 0; i < Q; i++)
            {
                var (s, t) = Scanner.Scan<int, int>();
                S[i] = s - 1;
                T[i] = t - 1;
            }

            for (var k = 0; k < N; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        F[i][j] = Math.Min(F[i][j], F[i][k] + F[k][j]);
                    }
                }
            }

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if (i == j) continue;
                    if (F[i][j] <= L) D[i][j] = Math.Min(D[i][j], 1);
                }
            }

            for (var k = 0; k < N; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        D[i][j] = Math.Min(D[i][j], D[i][k] + D[k][j]);
                    }
                }
            }

            for (var i = 0; i < Q; i++)
            {
                var answer = D[S[i]][T[i]];
                Console.WriteLine(answer < inf ? answer - 1 : -1);
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
