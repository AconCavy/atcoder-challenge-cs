using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            var N = Scanner.Scan<int>();
            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < N - 1; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                x--;
                y--;
                G[x].Add(y);
                G[y].Add(x);
            }

            var lca = new LowestCommonAncestor(G);
            var Q = Scanner.Scan<int>();
            for (var i = 0; i < Q; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--;
                b--;
                var answer = lca.GetDistance(a, b) + 1;
                Console.WriteLine(answer);
            }
        }

        public class LowestCommonAncestor
        {
            private List<int>[] G;
            private int N;
            private int _root;
            private int _log;
            private int[] _depth;
            private int[][] _parents;
            public LowestCommonAncestor(List<int>[] graph, int root = 0)
            {
                G = graph;
                N = G.Length;
                _root = root;
                var tmp = N;
                while (tmp > 0)
                {
                    _log++;
                    tmp >>= 1;
                }

                _depth = new int[N];
                _parents = new int[N][].Select(x => new int[_log]).ToArray();
                var queue = new Queue<(int c, int p, int d)>();
                queue.Enqueue((_root, -1, 0));
                var used = new bool[N];
                used[_root] = true;
                while (queue.Any())
                {
                    var item = queue.Dequeue();
                    var current = item.c;
                    var prev = item.p;
                    var distance = item.d;
                    _parents[current][0] = prev;
                    _depth[current] = distance;
                    foreach (var next in G[current])
                    {
                        if (used[next]) continue;
                        used[next] = true;
                        queue.Enqueue((next, current, distance + 1));
                    }
                }

                for (var i = 0; i + 1 < _log; i++)
                {
                    for (var v = 0; v < N; v++)
                    {
                        var parent = _parents[v][i];
                        _parents[v][i + 1] = parent == -1 ? -1 : _parents[parent][i];
                    }
                }
            }
            public int Find(int u, int v)
            {
                if (_depth[u] > _depth[v]) (u, v) = (v, u);
                v = GetAncestor(v, _depth[v] - _depth[u]);
                if (u == v) return u;
                for (var i = _log - 1; i >= 0; i--)
                {
                    if (_parents[u][i] != _parents[v][i]) (u, v) = (_parents[u][i], _parents[v][i]);
                }
                return _parents[u][0];
            }
            public int GetAncestor(int v, int h)
            {
                var parent = v;
                for (var i = 0; i < _log; i++)
                {
                    if ((h >> i & 1) == 1) parent = _parents[parent][i];
                }
                return parent;
            }
            public int GetDistance(int u, int v)
            {
                var p = Find(u, v);
                return _depth[u] + _depth[v] - _depth[p] * 2;
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
        }
    }
}
