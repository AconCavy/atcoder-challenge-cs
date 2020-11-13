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
            var (N, M, R) = Scanner.Scan<int, int, int>();
            var r = Scanner.ScanEnumerable<int>().Select(x => x - 1).ToArray();
            var inf = (int)1e9;
            var path = new int[N][].Select(x => Enumerable.Repeat(inf, N).ToArray()).ToArray();
            for (var i = 0; i < N; i++)
            {
                path[i][i] = 0;
            }
            for (var i = 0; i < M; i++)
            {
                var (A, B, C) = Scanner.Scan<int, int, int>();
                A--;
                B--;
                path[A][B] = path[B][A] = Math.Min(path[A][B], C);
            }

            for (var k = 0; k < N; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        path[i][j] = Math.Min(path[i][j], path[i][k] + path[k][j]);
                    }
                }
            }

            var checker = new bool[8];
            var answer = inf;
            void Dfs(int step, int current, int sum)
            {
                if (step == R)
                {
                    answer = Math.Min(answer, sum);
                    return;
                }
                for (var next = 0; next < R; next++)
                {
                    if (checker[next]) continue;
                    checker[next] = true;
                    if (current == -1) Dfs(step + 1, next, 0);
                    else Dfs(step + 1, next, sum + path[r[current]][r[next]]);
                    checker[next] = false;
                }
            }

            Dfs(0, -1, 0);
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
