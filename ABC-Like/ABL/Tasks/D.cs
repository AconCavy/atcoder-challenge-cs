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
            var (N, K) = Scanner.Scan<int, int>();
            const int max = 3 * (int)1e5 + 5;
            var st = new SegmentTree<int>(max, (a, b) => Math.Max(a, b), 0);
            for (var i = 0; i < N; i++)
            {
                var A = Scanner.Scan<int>();
                var l = Math.Max(0, A - K);
                var r = Math.Min(A + K, max - 1) + 1;
                st.Set(A, st.Query(l, r) + 1);
            }

            Console.WriteLine(st.Query(0, max));
        }

        public class SegmentTree<T>
        {
            private readonly int _n;
            private readonly int _size;
            private readonly int _log;
            private readonly T[] _data;
            private readonly Func<T, T, T> _operation;
            private readonly T _identity;
            public SegmentTree(int n, Func<T, T, T> operation, T identity)
                : this(Enumerable.Repeat(identity, n), operation, identity)
            {
            }
            public SegmentTree(IEnumerable<T> data, Func<T, T, T> operation, T identity)
            {
                var d = data.ToArray();
                _n = d.Length;
                _operation = operation;
                _identity = identity;
                while (1 << _log < _n) _log++;
                _size = 1 << _log;
                _data = Enumerable.Repeat(identity, _size << 1).ToArray();
                d.CopyTo(_data, _size);
                for (var i = _size - 1; i >= 1; i--) Update(i);
            }
            public void Set(int p, T x)
            {
                if (p < 0 || _n <= p) throw new IndexOutOfRangeException(nameof(p));
                p += _size;
                _data[p] = x;
                for (var i = 1; i <= _log; i++) Update(p >> i);
            }
            public T Get(int p)
            {
                if (p < 0 || _n <= p) throw new IndexOutOfRangeException(nameof(p));
                return _data[p + _size];
            }
            public T Query(int l, int r)
            {
                if (l < 0 || r < l || _n < r) throw new IndexOutOfRangeException();
                var (sml, smr) = (_identity, _identity);
                l += _size;
                r += _size;
                while (l < r)
                {
                    if ((l & 1) == 1) sml = _operation(sml, _data[l++]);
                    if ((r & 1) == 1) smr = _operation(_data[--r], smr);
                    l >>= 1;
                    r >>= 1;
                }
                return _operation(sml, smr);
            }
            public T QueryToAll() => _data[1];
            public int MaxRight(int l, Func<T, bool> func)
            {
                if (l < 0 || _n <= l) throw new IndexOutOfRangeException(nameof(l));
                if (!func(_identity)) throw new ArgumentException(nameof(func));
                if (l == _n) return _n;
                l += _size;
                var sm = _identity;
                do
                {
                    while ((l & 1) == 0) l >>= 1;
                    if (!func(_operation(sm, _data[l])))
                    {
                        while (l < _size)
                        {
                            l <<= 1;
                            var tmp = _operation(sm, _data[l]);
                            if (!func(tmp)) continue;
                            sm = tmp;
                            l++;
                        }
                        return l - _size;
                    }
                    sm = _operation(sm, _data[l]);
                    l++;
                } while ((l & -l) != l);
                return _n;
            }
            public int MinLeft(int r, Func<T, bool> func)
            {
                if (r < 0 || _n <= r) throw new IndexOutOfRangeException(nameof(r));
                if (!func(_identity)) throw new ArgumentException(nameof(func));
                if (r == 0) return 0;
                r += _size;
                var sm = _identity;
                do
                {
                    r--;
                    while (r > 1 && (r & 1) == 0) r >>= 1;
                    if (!func(_operation(_data[r], sm)))
                    {
                        while (r < _size)
                        {
                            r = (r << 1) + 1;
                            var tmp = _operation(_data[r], sm);
                            if (!func(tmp)) continue;
                            sm = tmp;
                            r--;
                        }
                        return r + 1 - _size;
                    }
                    sm = _operation(_data[r], sm);
                    r++;
                } while ((r & -r) != r);
                return 0;
            }
            private void Update(int k) => _data[k] = _operation(_data[k << 1], _data[(k << 1) + 1]);
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
