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
            var G = new bool[4][][];
            for (var i = 0; i < 4; i++) G[i] = new bool[i % 2 == 0 ? N : M][];

            for (var i = 0; i < N; i++)
            {
                G[0][i] = Scanner.Scan<string>().Select(x => x == '.').ToArray();
            }

            for (var i = 0; i < M; i++)
            {
                G[1][i] = new bool[N];
                for (var j = 0; j < N; j++)
                {
                    G[1][i][j] = G[0][j][M - 1 - i];
                }
            }

            for (var k = 2; k < 4; k++)
            {
                for (var i = 0; i < G[k - 2].Length; i++)
                {
                    G[k][i] = G[k - 2][^(i + 1)].ToArray();
                    Array.Reverse(G[k][i]);
                }
            }

            var cum = new int[4][][];
            for (var k = 0; k < 4; k++)
            {
                cum[k] = new int[G[k].Length + 1][];
                cum[k][^1] = new int[G[k][^1].Length + 1];
                for (var i = cum[k].Length - 2; i >= 0; i--)
                {
                    cum[k][i] = new int[G[k][i].Length];
                    for (var j = 0; j < cum[k][i].Length; j++)
                    {
                        if (G[k][i][j]) cum[k][i][j] = cum[k][i + 1][j] + 1;
                    }
                }
            }

            bool Check(int step, int ch, int cw)
            {
                if (ch < 0 || G[step].Length <= ch || cw < 0 || G[step][0].Length <= cw) return false;
                if (!G[step][ch][cw]) return false;
                return true;
            }

            var answer = 0L;
            for (var k = 0; k < 4; k++)
            {
                var (dfh1, dfw1) = (0, 1);
                var (dfh2, dfw2) = (1, 0);
                var (drh, drw) = (1, 1);
                for (var i = 0; i < G[k].Length; i++)
                {
                    var streak = 0;
                    for (var j = 0; j < G[k][i].Length; j++)
                    {
                        if (G[k][i][j]) streak++;
                        else streak = 0;

                        var (fh, fw) = (i + dfh1, j + dfw1);
                        var (rh, rw) = (i + drh, j + drw);
                        if (!Check(k, i, j) || !Check(k, fh, fw) || !Check(k, rh, rw)) continue;

                        answer += streak * cum[k][rh][rw];
                    }
                }
            }

            Console.WriteLine(answer);
        }

        public static class Printer
        {
            public static void Print<T>(T source) => Console.WriteLine(source);
            public static void Print1D<T>(IEnumerable<T> source, string separator = "") =>
                Console.WriteLine(string.Join(separator, source));
            public static void Print1D<T, U>(IEnumerable<T> source, Func<T, U> selector, string separator = "") =>
                Console.WriteLine(string.Join(separator, source.Select(selector)));
            public static void Print2D<T>(IEnumerable<IEnumerable<T>> source, string separator = "") =>
                Console.WriteLine(string.Join("\n", source.Select(x => string.Join(separator, x))));
            public static void Print2D<T, U>(IEnumerable<IEnumerable<T>> source, Func<T, U> selector, string separator = "") =>
                Console.WriteLine(string.Join("\n", source.Select(x => string.Join(separator, x.Select(selector)))));
            public static void Print2D<T>(T[,] source, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(source[i, j]);
                        Console.Write(j == w - 1 ? "\n" : separator);
                    }
            }
            public static void Print2D<T, U>(T[,] source, Func<T, U> selector, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(selector(source[i, j]));
                        Console.Write(j == w - 1 ? "\n" : separator);
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
