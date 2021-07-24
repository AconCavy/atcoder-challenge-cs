using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var K = Scanner.Scan<int>();
            var G = new char[N][];
            for (var i = 0; i < N; i++)
            {
                G[i] = Scanner.Scan<string>().ToCharArray();
            }

            var answer = 0L;
            var used = new HashSet<ulong>();
            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            ulong ToState()
            {
                ulong state = 0;
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (G[i][j] == '@')
                        {
                            state |= 1UL << (i * N + j);
                        }
                    }
                }

                return state;
            }

            void Check(int i, int j, int k)
            {
                G[i][j] = '@';
                Dfs(ToState(), k + 1);
                G[i][j] = '.';
            }

            void Dfs(ulong curr, int k)
            {
                if (used.Contains(curr)) return;
                used.Add(curr);

                if (k == K)
                {
                    answer++;
                    return;
                }

                var next = new List<(int, int)>();

                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (G[i][j] == '#') continue;
                        var ok = false;
                        foreach (var (dh, dw) in D4)
                        {
                            var (nh, nw) = (i + dh, j + dw);
                            if (nh < 0 || N <= nh || nw < 0 || N <= nw) continue;
                            ok |= G[nh][nw] == '@';
                        }

                        if (ok) next.Add((i, j));
                    }
                }

                foreach (var (i, j) in next)
                {
                    Check(i, j, k);
                }
            }

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if (G[i][j] == '#') continue;
                    Check(i, j, 0);
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
