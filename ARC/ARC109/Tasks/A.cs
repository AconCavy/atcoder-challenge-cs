using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class A
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
            var (a, b, x, y) = Scanner.Scan<int, int, int, int>();
            var N = 201;
            var G = new List<(int, int)>[N].Select(x => new List<(int, int)>()).ToArray();
            for (var i = 1; i <= 100; i++)
            {
                G[i].Add((i + 100, x));
                G[i + 100].Add((i, x));
                if (i + 1 <= 100)
                {
                    G[i + 1].Add((i + 100, x));
                    G[i + 100].Add((i + 1, x));
                }
            }

            for (var i = 1; i + 1 <= 100; i++)
            {
                G[i].Add((i + 1, y));
                G[i + 1].Add((i, y));
                G[i + 100].Add((i + 101, y));
                G[i + 101].Add((i + 100, y));
            }

            const int inf = (int)1e9;
            var queue = new Queue<int>();
            queue.Enqueue(a);
            var depths = Enumerable.Repeat(inf, N).ToArray();
            depths[a] = 0;
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var (next, c) in G[current])
                {
                    if (depths[next] <= depths[current] + c) continue;
                    depths[next] = depths[current] + c;
                    queue.Enqueue(next);
                }
            }

            Console.WriteLine(depths[b + 100]);
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
