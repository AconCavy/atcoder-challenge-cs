using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SandboxCSharp.Extensions;

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
            var A = Scanner.ScanEnumerable<long>().ToArray();

            long GetMedianCount(long m)
            {
                var ret = 0L;
                var ft = new FenwickTree(N * 2);
                foreach (var x in A.Select(x => x >= m ? 1 : -1).Cumulate(0, (x, y) => x + y))
                {
                    var p = x + N;
                    ret += ft.Sum(p);
                    ft.Add(p - 1, 1);
                }
                return ret;
            }

            var comb = (long)N * (N + 1) / 2;
            comb = (comb + 1) / 2;
            var (l, r) = (0L, A.Max() + 1);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (GetMedianCount(m) >= comb) l = m;
                else r = m;
            }

            Console.WriteLine(l);
        }

        public class FenwickTree
        {
            private readonly int _length;
            private readonly long[] _data;
            private delegate bool Compare(long item, long data);
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

namespace SandboxCSharp.Extensions
{
    public static partial class EnumerableExtension
    {
        public static IEnumerable<TAccumulate> Cumulate<TSource, TAccumulate>(this IEnumerable<TSource> source,
            TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));
            IEnumerable<TAccumulate> Inner()
            {
                yield return seed;
                foreach (var item in source) yield return seed = func(seed, item);
            }
            return Inner();
        }
        public static IEnumerable<TAccumulate> Cumulate<TSource, TAccumulate>(this IEnumerable<TSource> source,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));
            IEnumerable<TAccumulate> Inner()
            {
                TAccumulate seed = default;
                yield return seed;
                foreach (var item in source) yield return seed = func(seed, item);
            }
            return Inner();
        }
        public static IEnumerable<TSource> Cumulate<TSource>(this IEnumerable<TSource> source,
            Func<TSource, TSource, TSource> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));
            IEnumerable<TSource> Inner()
            {
                TSource seed = default;
                yield return seed;
                foreach (var item in source) yield return seed = func(seed, item);
            }
            return Inner();
        }
    }
}