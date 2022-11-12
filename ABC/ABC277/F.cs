using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
    {
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (H, W) = Scanner.Scan<int, int>();
            var A = new int[H][];
            for (var i = 0; i < H; i++)
            {
                A[i] = Scanner.ScanEnumerable<int>().ToArray();
            }

            var answer = true;
            Console.WriteLine(answer ? "Yes" : "No");
        }

        public class Graph
        {
            public int Length { get; }
            private readonly List<Edge>[] _data;
            private readonly int[] _degree;
            public Graph(int length)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                Length = length;
                _data = new List<Edge>[Length].Select(_ => new List<Edge>()).ToArray();
                _degree = new int[Length];
            }
            public void AddEdge(int u, int v, long cost)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                _data[u].Add(new Edge(v, cost));
                _degree[v]++;
            }
            public (bool Result, int[] Colors) IsBipartite()
            {
                var queue = new Queue<int>();
                queue.Enqueue(0);
                var colors = new int[Length];
                Array.Fill(colors, -1);
                colors[0] = 0;
                while (queue.Count > 0)
                {
                    var from = queue.Dequeue();
                    foreach (var node in _data[from])
                    {
                        if (colors[from] == colors[node.To]) return (false, colors);
                        if (colors[node.To] != -1) continue;
                        colors[node.To] = colors[from] ^ 1;
                        queue.Enqueue(node.To);
                    }
                }
                return (true, colors);
            }
            public (bool, int[]) TopologicalSort()
            {
                var queue = new Queue<int>();
                var degree = new int[Length];
                _degree.CopyTo(degree, 0);
                for (var i = 0; i < degree.Length; i++)
                {
                    if (degree[i] == 0) queue.Enqueue(i);
                }
                var result = new int[Length];
                var idx = 0;
                while (queue.Count > 0)
                {
                    var v = queue.Dequeue();
                    foreach (var node in _data[v])
                    {
                        degree[node.To]--;
                        if (degree[node.To] == 0) queue.Enqueue(node.To);
                    }
                    result[idx++] = v;
                }
                return (idx == Length, result);
            }
            private readonly struct Edge
            {
                internal int To { get; }
                internal long Cost { get; }
                public Edge(int to, long cost) => (To, Cost) = (to, cost);
            }
        }

        public static class Scanner
        {
            public static string ScanLine() => Console.ReadLine()?.Trim() ?? string.Empty;
            public static string[] Scan() => ScanLine().Split(' ');
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
