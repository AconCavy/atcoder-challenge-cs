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
            var (N, M) = Scanner.Scan<int, int>();
            const long inf = (long)1e18;
            var G = new long[N][].Select(_ => Enumerable.Repeat(inf, N).ToArray()).ToArray();
            for (var i = 0; i < N; i++) G[i][i] = 0;
            for (var i = 0; i < M; i++)
            {
                var (a, b, c) = Scanner.Scan<int, int, int>();
                a--; b--;
                G[a][b] = G[b][a] = c;
            }

            for (var k = 0; k < N; k++)
                for (var i = 0; i < N; i++)
                    for (var j = 0; j < N; j++)
                        G[i][j] = Math.Min(G[i][j], G[i][k] + G[k][j]);

            var K = Scanner.Scan<int>();
            while (K-- > 0)
            {
                var (x, y, z) = Scanner.Scan<int, int, int>();
                x--; y--;
                var answer = 0L;
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        var min = Math.Min(G[i][x] + G[y][j] + z, G[i][y] + G[x][j] + z);
                        G[i][j] = Math.Min(G[i][j], min);
                    }
                }

                for (var i = 0; i < N - 1; i++)
                    for (var j = i + 1; j < N; j++)
                        answer += G[i][j];

                Console.WriteLine(answer);
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
