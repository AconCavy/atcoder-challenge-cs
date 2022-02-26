using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var Q = Scanner.Scan<int>();
            var query = new (int, long, int)[Q];
            var set = new HashSet<long>();
            for (var i = 0; i < Q; i++)
            {
                var line = Scanner.ScanEnumerable<long>().ToArray();
                var (t, x) = ((int)line[0], line[1]);
                var k = t == 1 ? -1 : (int)line[2];
                query[i] = (t, x, k);
                set.Add(x);
            }

            var (map, remap) = Compress(set);
            var N = map.Count;
            var ft = new FenwickTree(N);
            foreach (var (t, x, k) in query)
            {
                if (t == 1)
                {
                    ft.Add(map[x], 1);
                }
                else if (t == 2)
                {
                    bool F(int idx) => ft.Sum(idx, map[x] + 1) >= k;
                    var idx = BinarySearch(map[x] + 1, 0, F);
                    var answer = F(idx) ? remap[idx] : -1;
                    Console.WriteLine(answer);
                }
                else
                {
                    bool F(int idx) => ft.Sum(map[x], idx + 1) >= k;
                    var idx = BinarySearch(map[x] - 1, N - 1, F);
                    var answer = F(idx) ? remap[idx] : -1;
                    Console.WriteLine(answer);
                }
            }
        }

        public static int BinarySearch(int ng, int ok, Func<int, bool> func)
        {
            while (Math.Abs(ok - ng) > 1)
            {
                var m = (ok + ng) / 2;
                if (func(m)) ok = m;
                else ng = m;
            }
            return ok;
        }

        public static (Dictionary<T, int> Map, Dictionary<int, T> ReMap) Compress<T>(IEnumerable<T> source)
        {
            var distinct = source.Distinct().ToArray();
            Array.Sort(distinct);
            var map = new Dictionary<T, int>();
            var remap = new Dictionary<int, T>();
            foreach (var (x, i) in distinct.Select((x, i) => (x, i)))
            {
                map[x] = i;
                remap[i] = x;
            }
            return (map, remap);
        }

        public class FenwickTree
        {
            private readonly long[] _data;
            private readonly int _length;
            public FenwickTree(int length)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                _length = length;
                _data = new long[length];
            }
            public void Add(int index, long item)
            {
                if (index < 0 || _length <= index) throw new ArgumentOutOfRangeException(nameof(index));
                index++;
                while (index <= _length)
                {
                    _data[index - 1] += item;
                    index += index & -index;
                }
            }
            public long Sum(int length)
            {
                if (length < 0 || _length < length) throw new ArgumentOutOfRangeException(nameof(length));
                var s = 0L;
                while (length > 0)
                {
                    s += _data[length - 1];
                    length -= length & -length;
                }
                return s;
            }
            public long Sum(int left, int right)
            {
                if (left < 0 || right < left || _length < right) throw new ArgumentOutOfRangeException();
                return Sum(right) - Sum(left);
            }
            public int LowerBound(long item) => CommonBound(item, LessThanOrEqual);
            public int UpperBound(long item) => CommonBound(item, LessThan);
            private int CommonBound(long item, Func<long, long, bool> compare)
            {
                if (compare(item, _data[0])) return 0;
                var x = 0;
                var r = 1;
                while (r < _length) r <<= 1;
                for (var k = r; k > 0; k >>= 1)
                {
                    if (x + k - 1 >= _length || compare(item, _data[x + k - 1])) continue;
                    item -= _data[x + k - 1];
                    x += k;
                }
                return x;
            }
            private static bool LessThanOrEqual(long x, long y) => x <= y;
            private static bool LessThan(long x, long y) => x < y;
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
