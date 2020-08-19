using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var (a, b) = Scanner.Scan<int, int>();
            a--;
            b--;
            var M = Scanner.Scan<int>();
            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                x--;
                y--;
                G[x].Add(y);
                G[y].Add(x);
            }
            var p = (int)1e9 + 7;

            var queue = new Queue<int>();
            queue.Enqueue(a);
            var depths = Enumerable.Repeat(-1, N).ToArray();
            depths[a] = 0;
            var ways = new long[N];
            ways[a] = 1;
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var next in G[current])
                {
                    if (depths[next] != -1)
                    {
                        if (depths[next] == depths[current] + 1)
                        {
                            ways[next] += ways[current];
                            ways[next] %= p;
                        }
                        continue;
                    }
                    depths[next] = depths[current] + 1;
                    ways[next] += ways[current];
                    ways[next] %= p;

                    queue.Enqueue(next);
                }
            }

            // Console.WriteLine(string.Join(" ", ways));

            Console.WriteLine(ways[b]);
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
        }
    }
}
