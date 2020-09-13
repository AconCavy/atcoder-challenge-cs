using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

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
            var (N, M) = Scanner.Scan<int, int>();
            var G = new char[N][].Select(x => Scanner.Scan<string>().ToCharArray()).ToArray();
            var mfg = new MaxFlowGraph(N * M + 2);
            var s = N * M;
            var t = N * M + 1;

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    if (G[i][j] == '#') continue;
                    var v = i * M + j;
                    if ((i + j) % 2 == 0) mfg.AddEdge(s, v, 1);
                    else mfg.AddEdge(v, t, 1);
                }
            }

            var di = new[] { -1, 0, 1, 0 };
            var dj = new[] { 0, -1, 0, 1 };
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    if ((i + j) % 2 == 1 || G[i][j] == '#') continue;
                    var v0 = i * M + j;
                    for (var k = 0; k < 4; k++)
                    {
                        var ci = i + di[k];
                        var cj = j + dj[k];
                        if (ci < 0 || N <= ci) continue;
                        if (cj < 0 || M <= cj) continue;
                        if (G[ci][cj] != '.') continue;
                        var v1 = ci * M + cj;
                        mfg.AddEdge(v0, v1, 1);
                    }
                }
            }

            Console.WriteLine(mfg.FlowOf(s, t));

            foreach (var edge in mfg.GetEdges().Where(x => x.From != s && x.To != t && x.Flow != 0))
            {
                var i0 = edge.From / M;
                var j0 = edge.From % M;
                var i1 = edge.To / M;
                var j1 = edge.To % M;

                if (i0 == i1 + 1)
                {
                    G[i1][j1] = 'v';
                    G[i0][j0] = '^';
                }
                else if (j0 == j1 + 1)
                {
                    G[i1][j1] = '>';
                    G[i0][j0] = '<';
                }
                else if (i0 == i1 - 1)
                {
                    G[i0][j0] = 'v';
                    G[i1][j1] = '^';
                }
                else
                {
                    G[i0][j0] = '>';
                    G[i1][j1] = '<';
                }
            }

            Console.WriteLine(string.Join("\n", G.Select(x => new string(x))));
        }

        public class MaxFlowGraph
        {
            public readonly struct Edge
            {
                public readonly int From;
                public readonly int To;
                public readonly long Cap;
                public readonly long Flow;

                public Edge(int from, int to, long cap, long flow)
                {
                    From = from;
                    To = to;
                    Cap = cap;
                    Flow = flow;
                }
            }

            private readonly struct InternalEdge
            {
                public readonly int To;
                public readonly int Rev;
                public readonly long Cap;

                public InternalEdge(int to, int rev, long cap)
                {
                    To = to;
                    Rev = rev;
                    Cap = cap;
                }
            }

            private readonly int _n;
            private readonly List<InternalEdge>[] _edges;
            private readonly List<(int X, int Y)> _pos;

            public MaxFlowGraph(int n = 0)
            {
                _n = n;
                _edges = new List<InternalEdge>[n].Select(x => new List<InternalEdge>()).ToArray();
                _pos = new List<(int X, int Y)>();
            }

            public int AddEdge(int from, int to, long cap)
            {
                if (from < 0 || _n <= from) throw new IndexOutOfRangeException(nameof(from));
                if (to < 0 || _n <= to) throw new IndexOutOfRangeException(nameof(to));
                if (cap < 0) throw new ArgumentException(nameof(cap));
                var m = _pos.Count;
                _pos.Add((from, _edges[from].Count));
                _edges[from].Add(new InternalEdge(to, _edges[to].Count, cap));
                _edges[to].Add(new InternalEdge(from, _edges[from].Count - 1, 0));
                return m;
            }

            public Edge GetEdge(int i)
            {
                var m = _pos.Count;
                if (i < 0 || m <= i) throw new IndexOutOfRangeException(nameof(i));
                var e = _edges[_pos[i].X][_pos[i].Y];
                var re = _edges[e.To][e.Rev];
                return new Edge(_pos[i].X, e.To, e.Cap + re.Cap, re.Cap);
            }

            public IEnumerable<Edge> GetEdges()
            {
                for (var i = 0; i < _pos.Count; i++) yield return GetEdge(i);
            }

            public void ChangeEdge(int i, long newCap, long newFlow)
            {
                var m = _pos.Count;
                if (i < 0 || m <= i) throw new IndexOutOfRangeException(nameof(i));
                if (newFlow < 0 || newCap < newFlow) throw new ArgumentException();
                var e = _edges[_pos[i].X][_pos[i].Y];
                var re = _edges[e.To][e.Rev];
                _edges[_pos[i].X][_pos[i].Y] = new InternalEdge(e.To, e.Rev, newCap - newFlow);
                _edges[e.To][e.Rev] = new InternalEdge(re.To, re.Rev, newFlow);
            }

            public long FlowOf(int s, int t) => FlowOf(s, t, long.MaxValue);

            public long FlowOf(int s, int t, long flowLimit)
            {
                if (s < 0 || _n <= s) throw new IndexOutOfRangeException(nameof(s));
                if (t < 0 || _n <= t) throw new IndexOutOfRangeException(nameof(t));
                var queue = new Queue<int>();
                int[] depth;
                int[] iter;

                void BFS()
                {
                    depth = Enumerable.Repeat(-1, _n).ToArray();
                    depth[s] = 0;
                    queue.Clear();
                    queue.Enqueue(s);
                    while (queue.Any())
                    {
                        var v = queue.Dequeue();
                        foreach (var edge in _edges[v].Where(edge => edge.Cap != 0 && depth[edge.To] < 0))
                        {
                            depth[edge.To] = depth[v] + 1;
                            if (edge.To == t) return;
                            queue.Enqueue(edge.To);
                        }
                    }
                }

                long DFS(int v, long up)
                {
                    if (v == s) return up;
                    var ret = 0L;
                    var dv = depth[v];
                    for (var i = iter[v]; i < _edges[v].Count; i++)
                    {
                        var e = _edges[v][i];
                        if (dv <= depth[e.To] || _edges[e.To][e.Rev].Cap == 0) continue;
                        var d = DFS(e.To, System.Math.Min(up - ret, _edges[e.To][e.Rev].Cap));
                        if (d <= 0) continue;
                        e = _edges[v][i];
                        _edges[v][i] = new InternalEdge(e.To, e.Rev, e.Cap + d);
                        var re = _edges[e.To][e.Rev];
                        _edges[e.To][e.Rev] = new InternalEdge(re.To, re.Rev, re.Cap - d);
                        ret += d;
                        if (ret == up) break;
                    }

                    return ret;
                }

                var flow = 0L;
                while (flow < flowLimit)
                {
                    BFS();
                    if (depth[t] == -1) break;
                    iter = new int[_n];
                    while (flow < flowLimit)
                    {
                        var f = DFS(t, flowLimit - flow);
                        if (f == 0) break;
                        flow += f;
                    }
                }

                return flow;
            }

            public IEnumerable<bool> MinCut(int s)
            {
                var visited = new bool[_n];
                var queue = new Queue<int>();
                queue.Enqueue(s);
                while (queue.Any())
                {
                    var p = queue.Dequeue();
                    visited[p] = true;
                    foreach (var edge in _edges[p].Where(edge => edge.Cap > 0 && !visited[edge.To]))
                    {
                        visited[edge.To] = true;
                        queue.Enqueue(edge.To);
                    }
                }

                return visited;
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
