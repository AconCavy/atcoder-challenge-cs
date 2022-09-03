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
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var lca = new LowestCommonAncestor(N);
            for (var i = 0; i < N - 1; i++)
            {
                var (u, v) = Scanner.Scan<int, int>();
                u--; v--;
                lca.AddEdge(u, v);
            }

            var Q = Scanner.Scan<int>();
            while (Q-- > 0)
            {
                var (u, k) = Scanner.Scan<int, int>();
                u--;
            }
        }
        public class LowestCommonAncestor
        {
            public int Length { get; }
            private readonly long[] _costs;
            private readonly int[] _distances;
            private readonly int _log;
            private readonly int[][] _parents;
            private readonly int _root;
            private readonly List<Edge>[] _tree;
            private bool _isUpdated;
            public LowestCommonAncestor(int length, int root = 0)
            {
                if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
                if (root < 0 || length <= root) throw new ArgumentOutOfRangeException(nameof(root));
                Length = length;
                _root = root;
                while (Length >> _log > 0) _log++;
                _distances = new int[length];
                _costs = new long[length];
                _parents = new int[length][].Select(x => new int[_log]).ToArray();
                _tree = new List<Edge>[length].Select(_ => new List<Edge>()).ToArray();
            }
            public void AddEdge(int u, int v, long cost = 1)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                _tree[u].Add(new Edge(v, cost));
                _tree[v].Add(new Edge(u, cost));
                _isUpdated = false;
            }
            public int Find(int u, int v)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                if (!_isUpdated) Build();
                if (_distances[u] > _distances[v]) (u, v) = (v, u);
                v = GetAncestor(v, _distances[v] - _distances[u]);
                if (u == v) return u;
                for (var i = _log - 1; i >= 0; i--)
                {
                    if (_parents[u][i] != _parents[v][i]) (u, v) = (_parents[u][i], _parents[v][i]);
                }
                return _parents[u][0];
            }
            public int GetAncestor(int v, int height)
            {
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                if (!_isUpdated) Build();
                var parent = v;
                for (var i = 0; i < _log && parent != -1; i++)
                {
                    if ((height >> i & 1) == 1) parent = _parents[parent][i];
                }
                return parent;
            }
            public int GetDistance(int u, int v)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                var p = Find(u, v);
                return _distances[u] + _distances[v] - _distances[p] * 2;
            }
            public long GetCost(int u, int v)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                var p = Find(u, v);
                return _costs[u] + _costs[v] - _costs[p] * 2;
            }
            public long GetCost(int u, int v, int mod)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                var p = Find(u, v);
                var cost = (_costs[u] + _costs[v]) % mod;
                cost = (cost - _costs[p] * 2 % mod) % mod;
                return (cost + mod) % mod;
            }
            private void Build()
            {
                _isUpdated = true;
                var queue = new Queue<(int current, int from, int distance, long cost)>();
                queue.Enqueue((_root, -1, 0, 0));
                var used = new bool[Length];
                used[_root] = true;
                while (queue.Count > 0)
                {
                    var (u, p, depth, cost) = queue.Dequeue();
                    _parents[u][0] = p;
                    _distances[u] = depth;
                    _costs[u] = cost;
                    foreach (var (v, c) in _tree[u])
                    {
                        if (used[v]) continue;
                        used[v] = true;
                        queue.Enqueue((v, u, depth + 1, cost + c));
                    }
                }
                for (var i = 0; i + 1 < _log; i++)
                {
                    for (var v = 0; v < Length; v++)
                    {
                        var parent = _parents[v][i];
                        _parents[v][i + 1] = parent == -1 ? -1 : _parents[parent][i];
                    }
                }
            }
            private readonly struct Edge
            {
                int To { get; }
                long Cost { get; }
                internal Edge(int to, long cost) => (To, Cost) = (to, cost);
                internal void Deconstruct(out int to, out long cost) => (to, cost) = (To, Cost);
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
