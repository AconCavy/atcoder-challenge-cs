using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class L
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
            var NM = N + M;
            var X = new long[NM];
            var Y = new long[NM];
            var C = new long[NM];
            for (var i = 0; i < NM; i++)
            {
                var (x, y, c) = Scanner.Scan<long, long, long>();
                X[i] = x;
                Y[i] = y;
                C[i] = c;
            }

            double GetCost(int u, int v)
            {
                var (dx, dy) = (X[u] - X[v], Y[u] - Y[v]);
                var cost = Math.Sqrt(dx * dx + dy * dy);
                if (C[u] != C[v]) cost *= 10;
                return cost;
            }

            var big = new List<(int U, int V, double C)>();
            for (var i = 0; i < N; i++)
            {
                for (var j = i + 1; j < N; j++)
                {
                    big.Add((i, j, GetCost(i, j)));
                }
            }

            var answer = double.MaxValue;

            for (var s = 0; s < 1 << M; s++)
            {
                var costs = big.ToList();
                for (var i = 0; i < M; i++)
                {
                    if ((s >> i & 1) == 1)
                    {
                        for (var j = 0; j < N; j++)
                        {
                            costs.Add((j, N + i, GetCost(j, N + i)));
                        }

                        for (var j = i + 1; j < M; j++)
                        {
                            if ((s >> j & 1) == 1) costs.Add((N + i, N + j, GetCost(N + i, N + j)));
                        }
                    }
                }

                costs.Sort((x, y) => x.C.CompareTo(y.C));
                var dsu = new DisjointSetUnion(NM);

                var cost = 0d;
                foreach (var (u, v, c) in costs)
                {
                    if (dsu.IsSame(u, v)) continue;
                    cost += c;
                    dsu.Merge(u, v);
                }

                answer = Math.Min(answer, cost);
            }

            Console.WriteLine(answer);
        }

        public class DisjointSetUnion
        {
            private readonly int _length;
            private readonly int[] _parentOrSize;
            public DisjointSetUnion(int length = 0)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                _length = length;
                _parentOrSize = new int[_length];
                Array.Fill(_parentOrSize, -1);
            }
            public int Merge(int u, int v)
            {
                if (u < 0 || _length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                var (x, y) = (LeaderOf(u), LeaderOf(v));
                if (x == y) return x;
                if (-_parentOrSize[x] < -_parentOrSize[y]) (x, y) = (y, x);
                _parentOrSize[x] += _parentOrSize[y];
                _parentOrSize[y] = x;
                return x;
            }
            public bool IsSame(int u, int v)
            {
                if (u < 0 || _length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                return LeaderOf(u) == LeaderOf(v);
            }
            public int LeaderOf(int v)
            {
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                if (_parentOrSize[v] < 0) return v;
                return _parentOrSize[v] = LeaderOf(_parentOrSize[v]);
            }
            public int SizeOf(int v)
            {
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                return -_parentOrSize[LeaderOf(v)];
            }
            public IEnumerable<IEnumerable<int>> GetGroups()
            {
                var ret = new List<int>[_length].Select(x => new List<int>()).ToArray();
                for (var i = 0; i < _length; i++) ret[LeaderOf(i)].Add(i);
                return ret.Where(x => x.Any());
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
