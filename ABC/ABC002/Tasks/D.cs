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
            var (N, M) = Scanner.Scan<int, int>();
            var G = new bool[N][].Select(x => new bool[N]).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                x--;
                y--;
                G[x][y] = G[y][x] = true;
            }

            var answer = 0;
            for (var s = 1; s < (1 << N); s++)
            {
                var count = 0;
                for (var i = 0; i < N; i++)
                {
                    if ((s >> i & 1) == 1) count++;
                }
                if (count <= answer) continue;

                var ok = true;
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < i; j++)
                    {
                        if ((s >> i & s >> j & 1) == 1 && !G[i][j]) ok = false;
                    }
                }

                if (ok) answer = count;
            }
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
