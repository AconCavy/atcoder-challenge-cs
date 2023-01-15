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
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var dict = new Dictionary<string, int>();
            var G = new Graph(N * 2);
            var idx = 0;
            for (var i = 0; i < N; i++)
            {
                var (s, t) = Scanner.Scan<string, string>();
                if (!dict.ContainsKey(s)) dict[s] = idx++;
                if (!dict.ContainsKey(t)) dict[t] = idx++;
                var (u, v) = (dict[s], dict[t]);
                G.AddEdge(u, v, 1);
            }

            var (answer, _) = G.TopologicalSort();
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
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]), Convert<T6>(buffer[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static string[] Scan()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
