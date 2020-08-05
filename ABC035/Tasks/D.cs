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
            var (N, M, T) = Scanner.Scan<int, int, long>();
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var G1 = new List<(int, long)>[N].Select(x => new List<(int, long)>()).ToArray();
            var G2 = new List<(int, long)>[N].Select(x => new List<(int, long)>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (a, b, c) = Scanner.Scan<int, int, long>();
                G1[--a].Add((--b, c));
                G2[b].Add((a, c));
            }

            var graphs = new[] { G1, G2 };
            var times = new long[2][];
            for (var i = 0; i < 2; i++)
            {
                var queue = new Queue<(int, long)>();
                queue.Enqueue((0, 0));
                times[i] = Enumerable.Repeat(long.MaxValue, N).ToArray();
                var time = times[i];
                time[0] = 0;
                var graph = graphs[i];
                while (queue.Any())
                {
                    var current = queue.Dequeue();
                    foreach (var next in graphs[i][current.Item1])
                    {
                        if (time[next.Item1] <= time[current.Item1] + next.Item2) continue;
                        time[next.Item1] = time[current.Item1] + next.Item2;
                        queue.Enqueue((next.Item1, time[next.Item1]));
                    }
                }
            }

            var answer = 0L;
            for (var i = 0; i < N; i++)
            {
                if (T < times[0][i] || T < times[1][i]) continue;
                if (T < times[0][i] + times[1][i]) continue;
                var time = T - (times[0][i] + times[1][i]);
                answer = Math.Max(answer, time * A[i]);
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
        }
    }
}
