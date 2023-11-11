using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class F
{
    public static void Main()
    {
        using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
        Console.SetOut(sw);
        Solve();
        Console.Out.Flush();
    }

    public static void Solve()
    {
        var (N, Q) = Scanner.Scan<int, int>();
        var S = new List<int>();
        var X = new long[N];
        var dsu = new DisjointSetUnion(N);
        var nodes = new List<int>[N];
        for (var i = 0; i < N; i++)
        {
            nodes[i] = new List<int> { i };
        }

        for (var i = 0; i < Q; i++)
        {
            var (a, b, d) = Scanner.Scan<int, int, long>();
            a--; b--;
            if (a == b && d != 0) continue;
            if (dsu.IsSame(a, b))
            {
                if (X[a] - X[b] == d)
                {
                    S.Add(i);
                }
            }
            else
            {
                var (u, v) = (dsu.LeaderOf(a), dsu.LeaderOf(b));
                d -= X[a] - X[b];
                if (nodes[u].Count < nodes[v].Count)
                {
                    (u, v) = (v, u);
                    d *= -1;
                }

                for (var j = 0; j < nodes[v].Count; j++)
                {
                    nodes[u].Add(nodes[v][j]);
                    X[nodes[v][j]] -= d;
                }

                dsu.Merge(a, b);
                S.Add(i);
            }
        }

        Console.WriteLine(string.Join(" ", S.Select(x => x + 1)));
    }


    public class DisjointSetUnion
    {
        public int Length { get; }
        private readonly int[] _parentOrSize;
        public DisjointSetUnion(int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
            Length = length;
            _parentOrSize = new int[Length];
            Array.Fill(_parentOrSize, -1);
        }
        public int Merge(int u, int v)
        {
            if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
            if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
            var (x, y) = (LeaderOf(u), LeaderOf(v));
            if (x == y) return x;
            if (-_parentOrSize[x] < -_parentOrSize[y]) (x, y) = (y, x);
            _parentOrSize[x] += _parentOrSize[y];
            _parentOrSize[y] = x;
            return x;
        }
        public bool IsSame(int u, int v)
        {
            if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
            if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
            return LeaderOf(u) == LeaderOf(v);
        }
        public int LeaderOf(int v)
        {
            if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
            if (_parentOrSize[v] < 0) return v;
            return _parentOrSize[v] = LeaderOf(_parentOrSize[v]);
        }
        public int SizeOf(int v)
        {
            if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
            return -_parentOrSize[LeaderOf(v)];
        }
        public IEnumerable<IReadOnlyCollection<int>> GetGroups()
        {
            var result = new List<int>[Length].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < Length; i++) result[LeaderOf(i)].Add(i);
            return result.Where(x => x.Count > 0);
        }
    }

    public static class Scanner
    {
        public static T Scan<T>() where T : IConvertible => Convert<T>(ScanStringArray()[0]);
        public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]));
        }
        public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]));
        }
        public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]));
        }
        public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]));
        }
        public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]), Convert<T6>(input[5]));
        }
        public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanStringArray().Select(Convert<T>);
        private static string[] ScanStringArray()
        {
            var line = Console.ReadLine()?.Trim() ?? string.Empty;
            return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
        }
        private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
    }
}
