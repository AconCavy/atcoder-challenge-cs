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
            var N = Scanner.Scan<int>();
            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            var edges = new (int a, int b)[N - 1];
            for (var i = 0; i < N - 1; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                G[--a].Add(--b);
                G[b].Add(a);
                edges[i] = (a, b);
            }

            var answer = 0;
            var colors = new int[N];
            var dict = new Dictionary<(int, int), int>();
            var queue = new Queue<int>();
            queue.Enqueue(0);
            var used = new bool[N];
            used[0] = true;
            while (queue.Any())
            {
                var from = queue.Dequeue();
                answer = Math.Max(answer, G[from].Count);
                var color = 1;
                foreach (var to in G[from])
                {
                    if (used[to]) continue;
                    if (color == colors[from]) color++;
                    colors[to] = dict[(from, to)] = dict[(to, from)] = color++;
                    used[to] = true;
                    queue.Enqueue(to);
                }
            }
            Console.WriteLine(answer);
            foreach (var edge in edges) Console.WriteLine(dict[edge]);
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
