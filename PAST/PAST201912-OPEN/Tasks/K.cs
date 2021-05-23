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
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var lca = new LowestCommonAncestor(N + 1);
            for (var i = 1; i <= N; i++)
            {
                var p = Scanner.Scan<int>();
                if (p == -1) p = 0;
                lca.AddEdge(p, i);
            }

            var Q = Scanner.Scan<int>();
            while (Q-- > 0)
            {
                var (a, b) = Scanner.Scan<int, int>();
                var p = lca.Find(a, b);
                Console.WriteLine(p == b ? "Yes" : "No");
            }
        }

        public class LowestCommonAncestor
        {
            private readonly int[] _depths;
            private readonly int _length;
            private readonly int _log;
            private readonly int[][] _parents;
            private readonly int _root;
            private readonly List<int>[] _tree;
            private bool _isUpdated;
            public LowestCommonAncestor(IReadOnlyCollection<IReadOnlyCollection<int>> tree, int root = 0)
                : this(tree.Count, root) =>
                _tree = tree.Select(x => x.ToList()).ToArray();
            public LowestCommonAncestor(int length, int root = 0)
            {
                if (root < 0 || length <= root) throw new ArgumentOutOfRangeException(nameof(root));
                _length = length;
                _root = root;
                while (_length >> _log > 0) _log++;
                _depths = new int[length];
                _parents = new int[length][].Select(x => new int[_log]).ToArray();
                _tree = new List<int>[length].Select(_ => new List<int>()).ToArray();
            }
            public void AddEdge(int u, int v)
            {
                if (u < 0 || _length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                _tree[u].Add(v);
                _tree[v].Add(u);
                _isUpdated = false;
            }
            public int Find(int u, int v)
            {
                if (u < 0 || _length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                if (!_isUpdated) Build();
                if (_depths[u] > _depths[v]) (u, v) = (v, u);
                v = GetAncestor(v, _depths[v] - _depths[u]);
                if (u == v) return u;
                for (var i = _log - 1; i >= 0; i--)
                    if (_parents[u][i] != _parents[v][i])
                        (u, v) = (_parents[u][i], _parents[v][i]);
                return _parents[u][0];
            }
            public int GetAncestor(int v, int height)
            {
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                if (!_isUpdated) Build();
                var parent = v;
                for (var i = 0; i < _log && parent != -1; i++)
                    if (((height >> i) & 1) == 1)
                        parent = _parents[parent][i];
                return parent;
            }
            public int GetDistance(int u, int v)
            {
                if (u < 0 || _length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                var p = Find(u, v);
                return _depths[u] + _depths[v] - _depths[p] * 2;
            }
            private void Build()
            {
                _isUpdated = true;
                var queue = new Queue<(int current, int from, int distance)>();
                queue.Enqueue((_root, -1, 0));
                var used = new bool[_length];
                used[_root] = true;
                while (queue.Any())
                {
                    var (current, from, depth) = queue.Dequeue();
                    _parents[current][0] = from;
                    _depths[current] = depth;
                    foreach (var next in _tree[current].Where(next => !used[next]))
                    {
                        used[next] = true;
                        queue.Enqueue((next, current, depth + 1));
                    }
                }
                for (var i = 0; i < _log - 1; i++)
                    for (var v = 0; v < _length; v++)
                    {
                        var parent = _parents[v][i];
                        _parents[v][i + 1] = parent == -1 ? -1 : _parents[parent][i];
                    }
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
