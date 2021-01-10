using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var (N, C) = Scanner.Scan<int, long>();
            var timeline = new List<(int T, long D)>();
            for (var i = 0; i < N; i++)
            {
                var (a, b, c) = Scanner.Scan<int, int, long>();
                timeline.Add((a, c));
                timeline.Add((b + 1, -c));
            }

            timeline.Sort();
            var compressed = new List<(int T, long D)>();
            compressed.Add(timeline[0]);
            for (var i = 1; i < timeline.Count; i++)
            {
                if (timeline[i].T == compressed[^1].T)
                {
                    var (t, d) = compressed[^1];
                    compressed[^1] = (t, d + timeline[i].D);
                }
                else
                {
                    compressed.Add(timeline[i]);
                }
            }

            var answer = 0L;
            var current = compressed[0].D;

            // Console.WriteLine(string.Join(" ", compressed));
            for (var i = 1; i < compressed.Count; i++)
            {
                answer += Math.Min(current, C) * (compressed[i].T - compressed[i - 1].T);
                current += compressed[i].D;
                // Console.WriteLine($"current:{current}, answer:{answer}");
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
