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
            var G = new List<(int U, int ID)>[N].Select(x => new List<(int, int)>()).ToArray();
            for (var i = 0; i < N - 1; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--; b--;
                G[a].Add((b, i));
                G[b].Add((a, i));
            }

            var colors = new int[N];
            var answer = new int[N - 1];
            var used = new bool[N];
            used[0] = true;
            var queue = new Queue<int>();
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                var color = 1;
                foreach (var (v, idx) in G[u])
                {
                    if (used[v]) continue;
                    used[v] = true;
                    if (color == colors[u]) color++;
                    colors[v] = answer[idx] = color++;
                    queue.Enqueue(v);
                }
            }

            Console.WriteLine(G.Max(x => x.Count));
            Console.WriteLine(string.Join("\n", answer));
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
