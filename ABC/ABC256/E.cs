using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
    {
        public static void Main()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var X = Scanner.ScanEnumerable<int>().Select(x => x - 1).ToArray();
            var C = Scanner.ScanEnumerable<long>().ToArray();
            const long inf = (long)1e18;
            var G = new List<(int To, long Cost)>[N].Select(x => new List<(int To, long)>()).ToArray();
            var deg = new int[N];
            var scc = new StronglyConnectedComponent(N);
            for (var i = 0; i < N; i++)
            {
                scc.AddEdge(X[i], i);
                deg[i]++;
            }

            var answer = 0L;
            foreach (var graph in scc.GetGraph())
            {
                if (graph.Count == 1) continue;
                var min = inf;
                foreach (var u in graph)
                {
                    min = Math.Min(min, C[u]);
                }
                answer += min;
            }

            Console.WriteLine(answer);
        }

        public class CompressedSparseRow<T>
        {
            public CompressedSparseRow(int length, IEnumerable<(int ID, T)> edges)
            {
                Start = new int[length + 1];
                var es = edges.ToArray();
                Edges = new T[es.Length];
                foreach (var e in es) Start[e.ID + 1]++;
                for (var i = 0; i < length; i++) Start[i + 1] += Start[i];
                var counter = new int[length + 1];
                Start.AsSpan().CopyTo(counter.AsSpan());
                foreach (var (i, t) in es) Edges[counter[i]++] = t;
            }
            public int[] Start { get; }
            public T[] Edges { get; }
        }
        public class StronglyConnectedComponent
        {
            public int Length { get; }
            private readonly List<(int, Edge)> _edges;
            public StronglyConnectedComponent(int length)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                Length = length;
                _edges = new List<(int, Edge)>();
            }
            public void AddEdge(int from, int to)
            {
                if (from < 0 || Length <= from) throw new ArgumentOutOfRangeException(nameof(from));
                if (to < 0 || Length <= to) throw new ArgumentOutOfRangeException(nameof(to));
                _edges.Add((from, new Edge(to)));
            }
            public (int GroupCount, int[] IDs) GetIDs()
            {
                var g = new CompressedSparseRow<Edge>(Length, _edges);
                var (nowOrd, groupCount) = (0, 0);
                var visited = new Stack<int>(Length);
                var low = new int[Length];
                var ord = new int[Length];
                Array.Fill(ord, -1);
                var ids = new int[Length];
                void Dfs(int v)
                {
                    low[v] = ord[v] = nowOrd++;
                    visited.Push(v);
                    for (var i = g.Start[v]; i < g.Start[v + 1]; i++)
                    {
                        var to = g.Edges[i].To;
                        if (ord[to] == -1)
                        {
                            Dfs(to);
                            low[v] = Math.Min(low[v], low[to]);
                        }
                        else
                        {
                            low[v] = Math.Min(low[v], ord[to]);
                        }
                    }
                    if (low[v] != ord[v]) return;
                    while (true)
                    {
                        var u = visited.Pop();
                        ord[u] = Length;
                        ids[u] = groupCount;
                        if (u == v) break;
                    }
                    groupCount++;
                }
                for (var i = 0; i < Length; i++)
                {
                    if (ord[i] == -1)
                        Dfs(i);
                }
                for (var i = 0; i < Length; i++)
                {
                    ids[i] = groupCount - 1 - ids[i];
                }
                return (groupCount, ids);
            }
            public IReadOnlyList<IReadOnlyList<int>> GetGraph()
            {
                var (groupCount, ids) = GetIDs();
                var groups = new List<int>[groupCount];
                for (var i = 0; i < groups.Length; i++)
                {
                    groups[i] = new List<int>();
                }
                foreach (var (id, index) in ids.Select((x, i) => (x, i)))
                {
                    groups[id].Add(index);
                }
                return groups;
            }
            private readonly struct Edge
            {
                public readonly int To;
                public Edge(int to) => To = to;
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
