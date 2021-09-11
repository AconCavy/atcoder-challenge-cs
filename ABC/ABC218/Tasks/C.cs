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
            var N = Scanner.Scan<int>();
            var S = new char[N, N];
            var T = new char[N * 3, N * 3];
            var PS = new List<(int, int)>();
            var PT = new List<(int, int)>();
            for (var i = 0; i < N; i++)
            {
                var s = Scanner.Scan<string>();
                for (var j = 0; j < N; j++)
                {
                    S[i, j] = s[j];
                    if (s[j] == '#') PS.Add((i, j));
                }
            }

            for (var i = 0; i < N * 3; i++)
            {
                for (var j = 0; j < N * 3; j++)
                {
                    T[i, j] = '.';
                }
            }

            for (var i = 0; i < N; i++)
            {
                var s = Scanner.Scan<string>();
                for (var j = 0; j < N; j++)
                {
                    T[i + N, j + N] = s[j];
                    if (s[j] == '#') PT.Add((i, j));
                }
            }

            if (PS.Count != PT.Count)
            {
                Console.WriteLine("No");
                return;
            }

            for (var k = 0; k < 4; k++)
            {
                for (var dh = 0; dh < N * 2; dh++)
                {
                    for (var dw = 0; dw < N * 2; dw++)
                    {
                        var ok = true;
                        foreach (var (i, j) in PS)
                        {
                            ok &= S[i, j] == T[dh + i, dw + j];
                            if (!ok) break;
                        }

                        if (ok)
                        {
                            Console.WriteLine("Yes");
                            return;
                        }
                    }
                }

                S = Transpose(S);
                var tmp = new List<(int, int)>();
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (S[i, j] == '#') tmp.Add((i, j));
                    }
                }

                PS = tmp;
            }

            Console.WriteLine("No");
        }

        public static T[,] Transpose<T>(T[,] matrix)
        {
            var (n, m) = (matrix.GetLength(0), matrix.GetLength(1));
            var result = new T[m, n];
            for (var i = 0; i < m; i++)
                for (var j = 0; j < n; j++)
                    result[i, j] = matrix[j, m - 1 - i];
            return result;
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
