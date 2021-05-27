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
            var (R, C, M) = Scanner.Scan<int, int, int>();
            var N = Scanner.Scan<int>();
            var P = new (int Ru, int Rb, int Cl, int Cr)[N];
            var G = new int[R, C];
            for (var i = 0; i < N; i++)
            {
                var (ru, rb, cl, cr) = Scanner.Scan<int, int, int, int>();
                ru--; rb--; cl--; cr--;
                P[i] = (ru, rb, cl, cr);

                for (var r = ru; r <= rb; r++)
                {
                    for (var c = cl; c <= cr; c++)
                    {
                        G[r, c]++;
                        G[r, c] %= 4;
                    }
                }
            }

            var count = new int[4];
            for (var i = 0; i < R; i++)
            {
                for (var j = 0; j < C; j++)
                {
                    count[G[i, j]]++;
                }
            }

            for (var i = 0; i < N; i++)
            {
                var s = count[0];
                var (ru, rb, cl, cr) = P[i];

                for (var r = ru; r <= rb; r++)
                {
                    for (var c = cl; c <= cr; c++)
                    {
                        if (G[r, c] == 0) s--;
                        if (G[r, c] == 1) s++;
                    }
                }

                if (s == M) Console.WriteLine(i + 1);
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
