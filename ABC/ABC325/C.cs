using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class C
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
        var (H, W) = Scanner.Scan<int, int>();
        var M = 0;
        var S = new char[H][];
        var dict = new Dictionary<(int H, int W), int>();
        for (var i = 0; i < H; i++)
        {
            S[i] = Scanner.Scan<string>().ToCharArray();
            for (var j = 0; j < W; j++)
            {
                if (S[i][j] == '#')
                {
                    dict[(i, j)] = M++;
                }
            }
        }

        var dsu = new DisjointSetUnion(M);
        var D8 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1) };
        for (var i = 0; i < H; i++)
        {
            for (var j = 0; j < W; j++)
            {
                if (S[i][j] != '#') continue;
                foreach (var (dh, dw) in D8)
                {
                    var (nh, nw) = (i + dh, j + dw);
                    if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                    if (S[nh][nw] == '#')
                    {
                        dsu.Merge(dict[(i, j)], dict[(nh, nw)]);
                    }
                }
            }
        }

        var answer = dsu.GetGroups().Count();
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
