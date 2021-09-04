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
            var (L, Q) = Scanner.Scan<int, int>();
            var points = new List<int> { 0, L };
            var query = new (int C, int X)[Q];

            for (var i = 0; i < Q; i++)
            {
                var (c, x) = Scanner.Scan<int, int>();
                query[i] = (c, x);
                points.Add(x);
            }

            points.Sort();
            var map = new Dictionary<int, int>();
            var remap = new Dictionary<int, int>();
            foreach (var (x, i) in points.Distinct().Select((x, i) => (x, i)))
            {
                map[x] = i;
                remap[i] = x;
            }

            var ft = new FenwickTree(map.Count);
            ft.Add(map[L], 1);
            foreach (var (c, x) in query)
            {
                var mx = map[x];
                if (c == 1)
                {
                    ft.Add(mx, 1);
                }
                else
                {
                    var sx = ft.Sum(mx);
                    var ub = ft.UpperBound(sx);
                    var lb = ft.LowerBound(sx);
                    var answer = remap[ub] - remap[lb];
                    Console.WriteLine(answer);
                }
            }
        }

        public class FenwickTree
        {
            private readonly long[] _data;
            private readonly int _length;
            private readonly Compare _lowerBound = (item, data) => item <= data;
            private readonly Compare _upperBound = (item, data) => item < data;
            public FenwickTree(int length = 0)
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
            public int LowerBound(long item) => CommonBound(item, _lowerBound);
            public int UpperBound(long item) => CommonBound(item, _upperBound);
            private int CommonBound(long item, Compare compare)
            {
                if (compare(item, 0)) return 0;
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
            private delegate bool Compare(long item, long data);
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
