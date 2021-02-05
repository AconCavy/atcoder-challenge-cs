using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < N; i++)
            {
                var s = Scanner.Scan<string>();
                for (var j = i + 1; j < N; j++)
                {
                    if (s[j] == '0') continue;
                    G[i].Add(j);
                    G[j].Add(i);
                }
            }

            var answer = 0;
            for (var i = 0; i < N; i++)
            {
                var queue = new Queue<int>();
                queue.Enqueue(i);
                var depths = new int[N];
                Array.Fill(depths, -1);
                depths[i] = 0;
                while (queue.Any())
                {
                    var u = queue.Dequeue();
                    foreach (var v in G[u])
                    {
                        if (depths[v] != -1)
                        {
                            if (depths[v] % 2 != depths[u] % 2) continue;
                            Console.WriteLine(-1);
                            return;
                        }
                        depths[v] = depths[u] + 1;
                        queue.Enqueue(v);
                    }
                }

                answer = Math.Max(answer, depths.Max() + 1);
                if (answer == N) break;
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
