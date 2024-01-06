using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class E
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
        var (N, M) = Scanner.Scan<int, int>();
        var A = Scanner.ScanEnumerable<int>().ToArray();
        var G = new List<int>[N].Select(x => new List<int>()).ToArray();
        var dsu = new DisjointSetUnion(N);
        var E = new Dictionary<int, List<(int U, int V)>>();
        for (var i = 0; i < M; i++)
        {
            var (u, v) = Scanner.Scan<int, int>();
            u--; v--;
            if (A[u] < A[0] || A[u] > A[^1]) continue;
            if (A[v] < A[0] || A[v] > A[^1]) continue;
            if (A[u] > A[v]) (u, v) = (v, u);
            if (A[u] == A[v])
            {
                dsu.Merge(u, v);
            }
            else
            {
                if (A[u] > A[v]) (u, v) = (v, u);
                var a = A[u];
                if (!E.ContainsKey(a)) E[a] = new List<(int U, int V)>();
                E[a].Add((u, v));
            }
        }

        const int Inf = 1 << 30;
        var dp = new int[N];
        Array.Fill(dp, -Inf);
        dp[dsu.LeaderOf(0)] = 1;
        foreach (var (a, edges) in E.OrderBy(x => x.Key))
        {
            foreach (var (u, v) in edges)
            {
                var (lu, lv) = (dsu.LeaderOf(u), dsu.LeaderOf(v));
                dp[lv] = Math.Max(dp[lv], dp[lu] + 1);
            }
        }

        var answer = Math.Max(0, dp[dsu.LeaderOf(N - 1)]);
        Console.WriteLine(answer);
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
