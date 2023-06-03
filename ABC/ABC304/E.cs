using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
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
            var dsu = new DisjointSetUnion(N);
            for (var i = 0; i < M; i++)
            {
                var (u, v) = Scanner.Scan<int, int>();
                u--; v--;
                dsu.Merge(u, v);
            }

            var K = Scanner.Scan<int>();
            var dict = new Dictionary<int, HashSet<int>>();
            for (var i = 0; i < K; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                x--; y--;
                var xl = dsu.LeaderOf(x);
                var yl = dsu.LeaderOf(y);
                if (!dict.ContainsKey(xl)) dict[xl] = new HashSet<int>();
                if (!dict.ContainsKey(yl)) dict[yl] = new HashSet<int>();
                dict[xl].Add(yl);
                dict[yl].Add(xl);
            }

            var Q = Scanner.Scan<int>();
            for (var i = 0; i < Q; i++)
            {
                var (p, q) = Scanner.Scan<int, int>();
                p--; q--;
                var pl = dsu.LeaderOf(p);
                var ql = dsu.LeaderOf(q);
                var answer = true;
                if (dict.ContainsKey(pl)) answer &= !dict[pl].Contains(ql);
                if (dict.ContainsKey(ql)) answer &= !dict[ql].Contains(pl);

                Console.WriteLine(answer ? "Yes" : "No");
            }
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
            public IEnumerable<HashSet<int>> GetGroups()
            {
                var result = new HashSet<int>[Length].Select(x => new HashSet<int>()).ToArray();
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
}
