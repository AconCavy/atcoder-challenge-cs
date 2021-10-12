using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class G
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
            var S = new char[N][];
            for (var i = 0; i < N; i++)
            {
                S[i] = Scanner.Scan<string>().ToCharArray();
            }

            var idx = -1;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    if (S[i][j] == '.')
                    {
                        idx = i * M + j;
                        break;
                    }
                }
            }

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            bool Check()
            {
                var dsu = new DisjointSetUnion(N * M);
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < M; j++)
                    {
                        if (S[i][j] == '#') continue;
                        var ci = i * M + j;
                        foreach (var (dh, dw) in D4)
                        {
                            var (nh, nw) = (i + dh, j + dw);
                            if (nh < 0 || N <= nh || nw < 0 || M <= nw) continue;
                            if (S[nh][nw] == '#') continue;
                            var ni = nh * M + nw;
                            dsu.Merge(ci, ni);
                        }
                    }
                }

                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < M; j++)
                    {
                        if (S[i][j] == '#') continue;
                        var ci = i * M + j;
                        if (!dsu.IsSame(idx, ci)) return false;
                    }
                }

                return true;
            }

            var answer = 0;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    if (S[i][j] == '#')
                    {
                        S[i][j] = '.';
                        if (Check()) answer++;
                        S[i][j] = '#';
                    }
                }
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
