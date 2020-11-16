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
            if (M == 0) { Console.WriteLine("Yes"); return; }
            var G = new List<(int, long)>[N].Select(x => new List<(int, long)>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (L, R, D) = Scanner.Scan<int, int, long>();
                L--; R--;
                G[L].Add((R, D));
                G[R].Add((L, -D));
            }

            var position = new long[N];
            var used = new bool[N];
            for (var i = 0; i < N; i++)
            {
                if (used[i]) continue;
                used[i] = true;

                var queue = new Queue<int>();
                queue.Enqueue(i);
                while (queue.Any())
                {
                    var u = queue.Dequeue();
                    foreach (var (v, d) in G[u])
                    {
                        if (used[v])
                        {
                            if (position[v] != position[u] + d) { Console.WriteLine("No"); return; }
                            continue;
                        }
                        used[v] = true;
                        position[v] = position[u] + d;
                        queue.Enqueue(v);
                    }
                }
            }

            Console.WriteLine("Yes");
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
