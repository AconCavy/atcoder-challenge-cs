using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class K
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
            var (P, Q) = Scanner.Scan<int, int>();
            var S = new bool[P][];
            for (var i = 0; i < P; i++)
            {
                S[i] = Scanner.Scan<string>().Select(x => x == '1').ToArray();
            }

            var AB = new (long A, long B)[P + Q + 1];
            for (var i = 1; i <= P + Q; i++)
            {
                AB[i] = Scanner.Scan<long, long>();
            }

            const long inf = (long)1e18;

            int IDP(int i) => 1 + i;
            int IDQ(int i) => 1 + P + i;
            var s = 0;
            var t = P + Q + 1;

            var fg = new FlowGraph(1 + P + Q + 1);
            for (var i = 0; i < P; i++)
            {
                var p = IDP(i);
                fg.AddEdge(s, p, 1);
            }

            for (var i = 0; i < Q; i++)
            {
                var q = IDQ(i);
                fg.AddEdge(q, t, 1);
            }

            for (var i = 0; i < P; i++)
            {
                for (var j = 0; j < Q; j++)
                {
                    var p = IDP(i);
                    var q = IDQ(j);
                    var cost = S[i][j] ? Math.Max(0, (AB[p].A + AB[q].A) - (AB[p].B + AB[q].B)) : 0;
                    fg.AddEdge(p, q, 1, inf - cost);
                }
            }

            var (_, result) = fg.MinCostFlow(s, t);
            var edges = fg.GetEdges().Where(x => x.From != s && x.To != t && x.Flow != 0).Count();
            var answer = AB.Sum(x => x.B) + inf * edges - result;

            Console.WriteLine(answer);
        }

        public class PriorityQueue<T> : IReadOnlyCollection<T>
        {
            private readonly Comparison<T> _comparison;
            private readonly List<T> _heap;
            public PriorityQueue(IEnumerable<T> items, IComparer<T> comparer = null) : this(comparer)
            {
                foreach (var item in items) Enqueue(item);
            }
            public PriorityQueue(IEnumerable<T> items, Comparison<T> comparison) : this(comparison)
            {
                foreach (var item in items) Enqueue(item);
            }
            public PriorityQueue(IComparer<T> comparer = null) : this((comparer ?? Comparer<T>.Default).Compare) { }
            public PriorityQueue(Comparison<T> comparison)
            {
                _heap = new List<T>();
                _comparison = comparison;
            }
            public int Count => _heap.Count;
            public IEnumerator<T> GetEnumerator() => _heap.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public void Enqueue(T item)
            {
                var child = Count;
                _heap.Add(item);
                while (child > 0)
                {
                    var parent = (child - 1) / 2;
                    if (_comparison(_heap[parent], _heap[child]) <= 0) break;
                    (_heap[parent], _heap[child]) = (_heap[child], _heap[parent]);
                    child = parent;
                }
            }
            public T Dequeue()
            {
                if (Count == 0) throw new InvalidOperationException();
                var result = _heap[0];
                _heap[0] = _heap[Count - 1];
                _heap.RemoveAt(Count - 1);
                var parent = 0;
                while (parent * 2 + 1 < Count)
                {
                    var left = parent * 2 + 1;
                    var right = parent * 2 + 2;
                    if (right < Count && _comparison(_heap[left], _heap[right]) > 0)
                        left = right;
                    if (_comparison(_heap[parent], _heap[left]) <= 0) break;
                    (_heap[parent], _heap[left]) = (_heap[left], _heap[parent]);
                    parent = left;
                }
                return result;
            }
            public T Peek()
            {
                if (Count == 0) throw new InvalidOperationException();
                return _heap[0];
            }
            public bool TryDequeue(out T result)
            {
                if (Count > 0)
                {
                    result = Dequeue();
                    return true;
                }
                result = default;
                return false;
            }
            public bool TryPeek(out T result)
            {
                if (Count > 0)
                {
                    result = Peek();
                    return true;
                }
                result = default;
                return false;
            }
            public void Clear() => _heap.Clear();
            public bool Contains(T item) => _heap.Contains(item);
        }

        public class FlowGraph
        {
            public int Length { get; }
            private readonly List<InternalEdge>[] _edges;
            private readonly List<(int X, int Y)> _positions;
            public FlowGraph(int length)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                Length = length;
                _edges = new List<InternalEdge>[length].Select(x => new List<InternalEdge>()).ToArray();
                _positions = new List<(int X, int Y)>();
            }
            public int AddEdge(int from, int to, long capacity, long cost = 0)
            {
                if (from < 0 || Length <= from) throw new ArgumentOutOfRangeException(nameof(from));
                if (to < 0 || Length <= to) throw new ArgumentOutOfRangeException(nameof(to));
                if (capacity < 0) throw new ArgumentException(nameof(capacity));
                if (cost < 0) throw new ArgumentException(nameof(cost));
                var count = _positions.Count;
                _positions.Add((from, _edges[from].Count));
                var fromId = _edges[from].Count;
                var toId = _edges[to].Count;
                if (from == to) toId++;
                _edges[from].Add(new InternalEdge(to, toId, capacity, cost));
                _edges[to].Add(new InternalEdge(from, fromId, 0, -cost));
                return count;
            }
            public void ChangeEdge(int index, long newCapacity, long newFlow)
            {
                var count = _positions.Count;
                if (index < 0 || count <= index) throw new ArgumentOutOfRangeException(nameof(index));
                if (newFlow < 0 || newCapacity < newFlow) throw new ArgumentException();
                var e = _edges[_positions[index].X][_positions[index].Y];
                var re = _edges[e.To][e.Rev];
                _edges[_positions[index].X][_positions[index].Y] =
                    new InternalEdge(e.To, e.Rev, newCapacity - newFlow, e.Cost);
                _edges[e.To][e.Rev] = new InternalEdge(re.To, re.Rev, newFlow, re.Cost);
            }
            public Edge GetEdge(int index)
            {
                if (index < 0 || _positions.Count <= index) throw new ArgumentOutOfRangeException(nameof(index));
                var e = _edges[_positions[index].X][_positions[index].Y];
                var re = _edges[e.To][e.Rev];
                return new Edge(_positions[index].X, e.To, e.Capacity + re.Capacity, re.Capacity, e.Cost);
            }
            public IEnumerable<Edge> GetEdges()
            {
                for (var i = 0; i < _positions.Count; i++) yield return GetEdge(i);
            }
            public long MaxFlow(int s, int t, long flowLimit = long.MaxValue)
            {
                if (s < 0 || Length <= s) throw new ArgumentOutOfRangeException(nameof(s));
                if (t < 0 || Length <= t) throw new ArgumentOutOfRangeException(nameof(t));
                if (s == t) throw new ArgumentException();
                var queue = new Queue<int>();
                var depth = new int[Length];
                var iter = new int[Length];
                void Bfs()
                {
                    Array.Fill(depth, -1);
                    depth[s] = 0;
                    queue.Clear();
                    queue.Enqueue(s);
                    while (queue.Count > 0)
                    {
                        var v = queue.Dequeue();
                        foreach (var edge in _edges[v].Where(edge => edge.Capacity != 0 && depth[edge.To] < 0))
                        {
                            depth[edge.To] = depth[v] + 1;
                            if (edge.To == t) return;
                            queue.Enqueue(edge.To);
                        }
                    }
                }
                long Dfs(int v, long up)
                {
                    if (v == s) return up;
                    var result = 0L;
                    var dv = depth[v];
                    for (var i = iter[v]; i < _edges[v].Count; i++)
                    {
                        var e = _edges[v][i];
                        if (dv <= depth[e.To] || _edges[e.To][e.Rev].Capacity == 0) continue;
                        var d = Dfs(e.To, Math.Min(up - result, _edges[e.To][e.Rev].Capacity));
                        if (d <= 0) continue;
                        e = _edges[v][i];
                        _edges[v][i] = new InternalEdge(e.To, e.Rev, e.Capacity + d, e.Cost);
                        var re = _edges[e.To][e.Rev];
                        _edges[e.To][e.Rev] = new InternalEdge(re.To, re.Rev, re.Capacity - d, re.Cost);
                        result += d;
                        if (result == up) return result;
                    }
                    depth[v] = Length;
                    return result;
                }
                var flow = 0L;
                while (flow < flowLimit)
                {
                    Bfs();
                    if (depth[t] == -1) break;
                    Array.Fill(iter, 0);
                    var f = Dfs(t, flowLimit - flow);
                    if (f == 0) break;
                    flow += f;
                }
                return flow;
            }
            public bool[] MinCut(int s)
            {
                var visited = new bool[Length];
                var queue = new Queue<int>();
                queue.Enqueue(s);
                while (queue.Any())
                {
                    var p = queue.Dequeue();
                    visited[p] = true;
                    foreach (var edge in _edges[p].Where(edge => edge.Capacity > 0 && !visited[edge.To]))
                    {
                        visited[edge.To] = true;
                        queue.Enqueue(edge.To);
                    }
                }
                return visited;
            }
            public (long, long) MinCostFlow(int s, int t, long flowLimit = long.MaxValue) =>
                MinCostSlope(s, t, flowLimit).Last();
            public IEnumerable<(long, long)> MinCostSlope(int s, int t, long flowLimit = long.MaxValue)
            {
                if (s < 0 || Length <= s) throw new ArgumentOutOfRangeException(nameof(s));
                if (t < 0 || Length <= t) throw new ArgumentOutOfRangeException(nameof(t));
                if (s == t) throw new ArgumentException();
                var dist = new long[Length];
                var dual = new long[Length];
                var pv = new int[Length];
                var pe = new int[Length];
                var visited = new bool[Length];
                bool Bfs()
                {
                    Array.Fill(dist, long.MaxValue);
                    dist[s] = 0;
                    Array.Fill(visited, false);
                    var queue = new PriorityQueue<(long Key, int To)>((x, y) =>
                    {
                        var comparison = x.Key.CompareTo(y.Key);
                        return comparison == 0 ? x.To.CompareTo(y.To) : comparison;
                    });
                    queue.Enqueue((0, s));
                    while (queue.Any())
                    {
                        var cur = queue.Dequeue();
                        var v = cur.To;
                        if (visited[v]) continue;
                        visited[v] = true;
                        if (v == t) break;
                        for (var i = 0; i < _edges[v].Count; i++)
                        {
                            var e = _edges[v][i];
                            if (visited[e.To] || e.Capacity <= 0) continue;
                            var c = e.Cost - dual[e.To] + dual[v];
                            if (dist[e.To] <= dist[v] + c) continue;
                            dist[e.To] = dist[v] + c;
                            pv[e.To] = v;
                            pe[e.To] = i;
                            queue.Enqueue((dist[e.To], e.To));
                        }
                    }
                    if (!visited[t]) return false;
                    for (var v = 0; v < Length; v++)
                    {
                        if (!visited[v]) continue;
                        dual[v] -= dist[t] - dist[v];
                    }
                    return true;
                }
                var (flow, cost, prev) = (0L, 0L, -1L);
                var result = new Stack<(long, long)>();
                result.Push((flow, cost));
                while (flow < flowLimit && Bfs())
                {
                    var c = flowLimit - flow;
                    for (var v = t; v != s; v = pv[v]) c = Math.Min(c, _edges[pv[v]][pe[v]].Capacity);
                    for (var v = t; v != s; v = pv[v])
                    {
                        var e = _edges[pv[v]][pe[v]];
                        _edges[pv[v]][pe[v]] = new InternalEdge(e.To, e.Rev, e.Capacity - c, e.Cost);
                        var re = _edges[v][e.Rev];
                        _edges[v][e.Rev] = new InternalEdge(re.To, re.Rev, re.Capacity + c, re.Cost);
                    }
                    var d = -dual[s];
                    flow += c;
                    cost += c * d;
                    if (prev == d) result.Pop();
                    result.Push((flow, cost));
                    prev = d;
                }
                return result.Reverse();
            }
            public readonly struct Edge
            {
                public readonly int From;
                public readonly int To;
                public readonly long Capacity;
                public readonly long Flow;
                public readonly long Cost;
                public Edge(int from, int to, long capacity, long flow, long cost = 0) =>
                    (From, To, Capacity, Flow, Cost) = (from, to, capacity, flow, cost);
            }
            private readonly struct InternalEdge
            {
                public readonly int To;
                public readonly int Rev;
                public readonly long Capacity;
                public readonly long Cost;
                public InternalEdge(int to, int rev, long capacity, long cost) =>
                    (To, Rev, Capacity, Cost) = (to, rev, capacity, cost);
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
