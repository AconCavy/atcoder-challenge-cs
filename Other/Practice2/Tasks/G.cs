using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class G
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
            var (N, M) = Scanner.Scan<int, int>();
            var G = new SCCGraph(N);

            for (var i = 0; i < M; i++)
            {
                var (u, v) = Scanner.Scan<int, int>();
                G.AddEdge(u, v);
            }

            var scc = G.GetSCC();
            Console.WriteLine(scc.Count());
            foreach (var v in scc) Console.WriteLine($"{v.Count()} {string.Join(" ", v)}");
        }

        public class SCCGraph
        {
            private struct Edge
            {
                public int To;
            }

            private readonly int _n;
            private readonly List<(int, Edge)> _edges;

            public SCCGraph(int n = 0)
            {
                _n = n;
                _edges = new List<(int, Edge)>();
            }

            public void AddEdge(int from, int to)
            {
                if (from < 0 || _n <= from) throw new IndexOutOfRangeException(nameof(from));
                if (to < 0 || _n <= to) throw new IndexOutOfRangeException(nameof(to));
                _edges.Add((from, new Edge { To = to }));
            }

            public (int, IEnumerable<int>) Ids()
            {
                var g = new CSR<Edge>(_n, _edges);
                var (nowOrd, groupNum) = (0, 0);
                var visited = new Stack<int>(_n);
                var low = new int[_n];
                var ord = Enumerable.Repeat(-1, _n).ToArray();
                var ids = new int[_n];

                void DFS(int v)
                {
                    low[v] = ord[v] = nowOrd++;
                    visited.Push(v);
                    for (var i = g.Start[v]; i < g.Start[v + 1]; i++)
                    {
                        var to = g.Edges[i].To;
                        if (ord[to] == -1)
                        {
                            DFS(to);
                            low[v] = System.Math.Min(low[v], low[to]);
                        }
                        else
                        {
                            low[v] = System.Math.Min(low[v], ord[to]);
                        }
                    }

                    if (low[v] != ord[v]) return;
                    while (true)
                    {
                        var u = visited.Pop();
                        ord[u] = _n;
                        ids[u] = groupNum;
                        if (u == v) break;
                    }

                    groupNum++;
                }

                for (var i = 0; i < _n; i++)
                    if (ord[i] == -1)
                        DFS(i);

                for (var i = 0; i < _n; i++) ids[i] = groupNum - 1 - ids[i];

                return (groupNum, ids);
            }

            public IEnumerable<IEnumerable<int>> GetSCC()
            {
                var (groupNum, tmp) = Ids();
                var ids = tmp.ToArray();
                var groups = new List<int>[groupNum].Select(x => new List<int>()).ToArray();
                foreach (var (id, i) in ids.Select((x, i) => (x, i))) groups[id].Add(i);
                return groups;
            }
        }

        public class CSR<T>
        {
            public int[] Start { get; }

            public T[] Edges { get; }

            public CSR(int n, IEnumerable<(int, T)> edges)
            {
                Start = new int[n + 1];
                var es = edges.ToArray();
                Edges = new T[es.Length];
                foreach (var e in es) Start[e.Item1 + 1]++;
                for (var i = 0; i < n; i++) Start[i + 1] += Start[i];
                var counter = Start.ToArray();
                foreach (var (i, t) in es) Edges[counter[i]++] = t;
            }
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
