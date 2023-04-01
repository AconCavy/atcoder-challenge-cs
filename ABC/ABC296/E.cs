using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Tasks
{
    public class E
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
            var A = Scanner.ScanEnumerable<int>().Select(x => x - 1).ToArray();
            var isSelf = new bool[N];

            var scc = new StronglyConnectedComponent(N);
            for (var i = 0; i < N; i++)
            {
                scc.AddEdge(i, A[i]);
                if (i == A[i]) isSelf[i] = true;
            }

            var set = new HashSet<int>();
            foreach (var graph in scc.GetGraph())
            {
                if (graph.Count == 1 && !isSelf[graph[0]]) continue;
                foreach (var u in graph)
                {
                    set.Add(u);
                }
            }

            var answer = set.Count;
            Console.WriteLine(answer);
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

        public class DisjointSetUnion
        {
            public int Length { get; }
            private readonly int[] _parentOrSize;
            public DisjointSetUnion(int length)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                Length = length;
                _parentOrSize = new int[Length];
                Array.Fill(_parentOrSize, -1);
            }
            public int Merge(int u, int v)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                var (x, y) = (LeaderOf(u), LeaderOf(v));
                if (x == y) return x;
                if (-_parentOrSize[x] < -_parentOrSize[y]) (x, y) = (y, x);
                _parentOrSize[x] += _parentOrSize[y];
                _parentOrSize[y] = x;
                return x;
            }
            public bool IsSame(int u, int v)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                return LeaderOf(u) == LeaderOf(v);
            }
            public int LeaderOf(int v)
            {
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                if (_parentOrSize[v] < 0) return v;
                return _parentOrSize[v] = LeaderOf(_parentOrSize[v]);
            }
            public int SizeOf(int v)
            {
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                return -_parentOrSize[LeaderOf(v)];
            }
            public IEnumerable<IReadOnlyCollection<int>> GetGroups()
            {
                var result = new List<int>[Length].Select(x => new List<int>()).ToArray();
                for (var i = 0; i < Length; i++) result[LeaderOf(i)].Add(i);
                return result.Where(x => x.Count > 0);
            }
        }

        public static class Printer
        {
            public static void Print<T>(T source) => Console.WriteLine(source);
            public static void Print1D<T>(IEnumerable<T> source, string separator = "") => Console.WriteLine(string.Join(separator, source));
            public static void Print1D<T, U>(IEnumerable<T> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(separator, source.Select(selector)));
            public static void Print2D<T>(IEnumerable<IEnumerable<T>> source, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x))));
            public static void Print2D<T, U>(IEnumerable<IEnumerable<T>> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x.Select(selector)))));
            public static void Print2D<T>(T[,] source, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                {
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(source[i, j]);
                        Console.Write(j == w - 1 ? Environment.NewLine : separator);
                    }
                }
            }
            public static void Print2D<T, U>(T[,] source, Func<T, U> selector, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                {
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(selector(source[i, j]));
                        Console.Write(j == w - 1 ? Environment.NewLine : separator);
                    }
                }
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
