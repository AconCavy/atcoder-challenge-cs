using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var G = new string[N];
            for (var i = 0; i < N; i++)
            {
                G[i] = Scanner.Scan<string>();
            }
            var mcfg = new MinCostFlowGraph(N * M + 2);
            var s = N * M;
            var t = N * M + 1;
            var sum = 0;
            const int Inf = (int)1e9;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    if (G[i][j] == '#') continue;
                    var dist = N - i + M - j;
                    if (G[i][j] == 'o')
                    {
                        mcfg.AddEdge(s, i * M + j, 1, 0);
                        sum += dist;
                    }
                    mcfg.AddEdge(i * M + j, t, 1, dist);
                    if (i + 1 < N && G[i + 1][j] != '#') mcfg.AddEdge(i * M + j, (i + 1) * M + j, Inf, 0);
                    if (j + 1 < M && G[i][j + 1] != '#') mcfg.AddEdge(i * M + j, i * M + (j + 1), Inf, 0);
                }
            }

            var answer = sum - mcfg.Flow(s, t, Inf).Item2;
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }

        public class MinCostFlowGraph
        {
            public readonly struct Edge
            {
                public readonly int From;
                public readonly int To;
                public readonly long Capacity;
                public readonly long Flow;
                public readonly long Cost;

                public Edge(int from, int to, long capacity, long flow, long cost)
                {
                    From = from;
                    To = to;
                    Capacity = capacity;
                    Flow = flow;
                    Cost = cost;
                }
            }

            private readonly struct InternalEdge
            {
                public readonly int To;
                public readonly int Rev;
                public readonly long Capacity;
                public readonly long Cost;

                public InternalEdge(int to, int rev, long capacity, long cost)
                {
                    To = to;
                    Rev = rev;
                    Capacity = capacity;
                    Cost = cost;
                }
            }

            private readonly struct Q : IComparable<Q>
            {
                public readonly long Key;
                public readonly int To;

                public Q(long key, int to)
                {
                    Key = key;
                    To = to;
                }

                public int CompareTo(Q other)
                {
                    var ret = Comparer<long>.Default.Compare(Key, other.Key);
                    if (ret == 0) ret = Comparer<int>.Default.Compare(To, other.To);
                    return ret;
                }
            }

            private readonly int _n;
            private readonly List<InternalEdge>[] _edges;
            private readonly List<(int X, int Y)> _pos;

            public MinCostFlowGraph(int n = 0)
            {
                _n = n;
                _edges = new List<InternalEdge>[n].Select(x => new List<InternalEdge>()).ToArray();
                _pos = new List<(int X, int Y)>();
            }

            public int AddEdge(int from, int to, long capacity, long cost)
            {
                if (from < 0 || _n <= from) throw new IndexOutOfRangeException(nameof(from));
                if (to < 0 || _n <= to) throw new IndexOutOfRangeException(nameof(to));
                var m = _pos.Count;
                _pos.Add((from, _edges[from].Count));
                _edges[from].Add(new InternalEdge(to, _edges[to].Count, capacity, cost));
                _edges[to].Add(new InternalEdge(from, _edges[from].Count - 1, 0, -cost));
                return m;
            }

            public Edge GetEdge(int i)
            {
                if (i < 0 || _pos.Count <= i) throw new IndexOutOfRangeException(nameof(i));
                var e = _edges[_pos[i].X][_pos[i].Y];
                var re = _edges[e.To][e.Rev];
                return new Edge(_pos[i].X, e.To, e.Capacity + re.Capacity, re.Capacity, e.Cost);
            }

            public IEnumerable<Edge> GetEdges()
            {
                for (var i = 0; i < _pos.Count; i++) yield return GetEdge(i);
            }

            public (long, long) Flow(int s, int t) => Flow(s, t, long.MaxValue);

            public (long, long) Flow(int s, int t, long flowLimit) => Slope(s, t, flowLimit).First();

            public IEnumerable<(long, long)> Slope(int s, int t) => Slope(s, t, long.MaxValue);

            public IEnumerable<(long, long)> Slope(int s, int t, long flowLimit)
            {
                if (s < 0 || _n <= s) throw new IndexOutOfRangeException(nameof(s));
                if (t < 0 || _n <= t) throw new IndexOutOfRangeException(nameof(t));
                if (s == t) throw new ArgumentException();
                var dual = new long[_n];
                int[] pv;
                int[] pe;

                bool Bfs()
                {
                    var dist = Enumerable.Repeat(long.MaxValue, _n).ToArray();
                    var visited = new bool[_n];
                    pv = Enumerable.Repeat(-1, _n).ToArray();
                    pe = Enumerable.Repeat(-1, _n).ToArray();
                    var queue = new PriorityQueue<Q>();
                    dist[s] = 0;
                    queue.Enqueue(new Q(0, s));
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
                            queue.Enqueue(new Q(dist[e.To], e.To));
                        }
                    }

                    if (!visited[t]) return false;
                    for (var v = 0; v < _n; v++)
                    {
                        if (!visited[v]) continue;
                        dual[v] -= dist[t] - dist[v];
                    }

                    return true;
                }

                var (flow, cost, prev) = (0L, 0L, -1L);
                var ret = new Stack<(long, long)>();
                ret.Push((flow, cost));
                while (flow < flowLimit && Bfs())
                {
                    var c = flowLimit - flow;
                    for (var v = t; v != s; v = pv[v])
                    {
                        c = System.Math.Min(c, _edges[pv[v]][pe[v]].Capacity);
                    }

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
                    if (prev == d) ret.Pop();
                    ret.Push((flow, cost));
                    prev = cost;
                }

                return ret;
            }
        }

        public class PriorityQueue<T> : IEnumerable<T>
        {
            private readonly SortedDictionary<T, int> _data;

            public PriorityQueue() : this(null, null)
            {
            }

            public PriorityQueue(IComparer<T> comparer = null)
                : this(null, comparer)
            {
            }

            public PriorityQueue(int count, IComparer<T> comparer = null)
                : this(Enumerable.Repeat(default(T), count), comparer)
            {
            }

            public PriorityQueue(IEnumerable<T> data = null, IComparer<T> comparer = null)
            {
                comparer ??= Comparer<T>.Default;
                var list = data?.ToList() ?? new List<T>();
                var dict = new Dictionary<T, int>();
                foreach (var val in list)
                {
                    if (!dict.ContainsKey(val)) dict[val] = 0;
                    dict[val]++;
                }

                _data = new SortedDictionary<T, int>(dict, comparer);
            }

            public void Enqueue(T item)
            {
                if (!_data.ContainsKey(item)) _data[item] = 0;
                _data[item]++;
            }

            public T Dequeue()
            {
                if (!_data.Any()) throw new InvalidOperationException();
                var key = Peek();
                if (_data[key] > 1) _data[key]--;
                else _data.Remove(key);
                return key;
            }

            public T Peek()
            {
                if (!_data.Any()) throw new InvalidOperationException();
                using var e = _data.GetEnumerator();
                e.MoveNext();
                var (ret, _) = e.Current;
                return ret;
            }

            public bool TryDequeue(out T result)
            {
                if (_data.Any())
                {
                    result = Dequeue();
                    return true;
                }

                result = default;
                return false;
            }

            public bool TryPeek(out T result)
            {
                if (_data.Any())
                {
                    result = Peek();
                    return true;
                }

                result = default;
                return false;
            }

            public void Clear() => _data.Clear();
            public bool Contains(T item) => _data.ContainsKey(item);

            public void CopyTo(T[] array, int arrayIndex)
            {
                GetFlatData().ToList().CopyTo(array, arrayIndex);
            }

            public IEnumerator<T> GetEnumerator() => GetFlatData().GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private IEnumerable<T> GetFlatData() => _data.SelectMany(x => Enumerable.Repeat(x.Key, x.Value));
        }
    }
}
