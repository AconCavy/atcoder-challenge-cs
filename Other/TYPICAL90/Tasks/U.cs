using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class U
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
            var (N, M) = Scanner.Scan<int, int>();
            var scc = new StronglyConnectedComponent(N);
            for (var i = 0; i < M; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--; b--;
                scc.AddEdge(a, b);
            }

            var answer = 0L;
            foreach (var group in scc.GetGraph())
            {
                var c = (long)group.Count();
                answer += c * (c - 1) / 2;
            }

            Console.WriteLine(answer);
        }

        public class CompressedSparseRow<T>
        {
            public CompressedSparseRow(int length, IEnumerable<(int, T)> edges)
            {
                Start = new int[length + 1];
                var es = edges.ToArray();
                Edges = new T[es.Length];
                foreach (var e in es) Start[e.Item1 + 1]++;
                for (var i = 0; i < length; i++) Start[i + 1] += Start[i];
                var counter = Start.ToArray();
                foreach (var (i, t) in es) Edges[counter[i]++] = t;
            }
            public int[] Start { get; }
            public T[] Edges { get; }
        }

        public class StronglyConnectedComponent
        {
            private readonly List<(int, Edge)> _edges;
            private readonly int _length;
            public StronglyConnectedComponent(int length = 0)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                _length = length;
                _edges = new List<(int, Edge)>();
            }
            public void AddEdge(int from, int to)
            {
                if (from < 0 || _length <= from) throw new ArgumentOutOfRangeException(nameof(from));
                if (to < 0 || _length <= to) throw new ArgumentOutOfRangeException(nameof(to));
                _edges.Add((from, new Edge(to)));
            }
            public (int, IEnumerable<int>) GetIds()
            {
                var g = new CompressedSparseRow<Edge>(_length, _edges);
                var (nowOrd, groupNum) = (0, 0);
                var visited = new Stack<int>(_length);
                var low = new int[_length];
                var ord = new int[_length];
                Array.Fill(ord, -1);
                var ids = new int[_length];
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
                        ord[u] = _length;
                        ids[u] = groupNum;
                        if (u == v) break;
                    }
                    groupNum++;
                }
                for (var i = 0; i < _length; i++)
                    if (ord[i] == -1)
                        Dfs(i);
                for (var i = 0; i < _length; i++) ids[i] = groupNum - 1 - ids[i];
                return (groupNum, ids);
            }
            public IEnumerable<IEnumerable<int>> GetGraph()
            {
                var (groupNum, identities) = GetIds();
                var ids = identities.ToArray();
                var groups = new List<int>[groupNum].Select(_ => new List<int>()).ToArray();
                foreach (var (id, index) in ids.Select((x, i) => (x, i))) groups[id].Add(index);
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
