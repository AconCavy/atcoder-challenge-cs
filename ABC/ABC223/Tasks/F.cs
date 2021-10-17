using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
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
            var (N, Q) = Scanner.Scan<int, int>();
            var S = Scanner.Scan<string>();

            int Score(char c) => c switch
            {
                '(' => 1,
                ')' => -1,
                _ => default
            };

            var seg = new SegmentTree<Monoid>(N, new Oracle());
            for (var i = 0; i < N; i++)
            {
                var score = Score(S[i]);
                seg.Set(i, new Monoid(score, score));
            }

            while (Q-- > 0)
            {
                var (q, l, r) = Scanner.Scan<int, int, int>();
                l--;
                if (q == 1)
                {
                    r--;
                    var (lv, rv) = (seg.Get(l), seg.Get(r));
                    seg.Set(l, rv);
                    seg.Set(r, lv);
                }
                else
                {
                    var x = seg.Query(l, r);
                    var answer = x.Value == 0 && x.Min >= 0;
                    Console.WriteLine(answer ? "Yes" : "No");
                }
            }
        }

        public readonly struct Monoid
        {
            public readonly int Value;
            public readonly int Min;
            public Monoid(int value, int min) => (Value, Min) = (value, min);
        }

        public class Oracle : IOracle<Monoid>
        {
            public Monoid MonoidIdentity => new Monoid(0, 0);

            public Monoid Operate(in Monoid a, in Monoid b)
            {
                return new Monoid(a.Value + b.Value, Math.Min(a.Min, a.Value + b.Min));
            }
        }

        public interface IOracle<TMonoid> where TMonoid : struct
        {
            TMonoid MonoidIdentity { get; }
            TMonoid Operate(in TMonoid a, in TMonoid b);
        }

        public class SegmentTree<TMonoid> where TMonoid : struct
        {
            private readonly TMonoid[] _data;
            private readonly int _length;
            private readonly int _log;
            private readonly TMonoid _monoidId;
            private readonly IOracle<TMonoid> _oracle;
            private readonly int _size;
            public SegmentTree(int length, IOracle<TMonoid> oracle)
                : this(Enumerable.Repeat(oracle.MonoidIdentity, length), oracle)
            {
            }
            public SegmentTree(IEnumerable<TMonoid> data, IOracle<TMonoid> oracle)
            {
                var d = data.ToArray();
                _length = d.Length;
                _oracle = oracle;
                _monoidId = oracle.MonoidIdentity;
                while (1 << _log < _length) _log++;
                _size = 1 << _log;
                _data = new TMonoid[_size << 1];
                Array.Fill(_data, _monoidId);
                d.CopyTo(_data, _size);
                for (var i = _size - 1; i >= 1; i--) Update(i);
            }
            public void Set(int index, TMonoid monoid)
            {
                if (index < 0 || _length <= index) throw new ArgumentOutOfRangeException(nameof(index));
                index += _size;
                _data[index] = monoid;
                for (var i = 1; i <= _log; i++) Update(index >> i);
            }
            public TMonoid Get(int index)
            {
                if (index < 0 || _length <= index) throw new ArgumentOutOfRangeException(nameof(index));
                return _data[index + _size];
            }
            public TMonoid Query(int left, int right)
            {
                if (left < 0 || right < left || _length < right) throw new ArgumentOutOfRangeException();
                var (sml, smr) = (_monoidId, _monoidId);
                left += _size;
                right += _size;
                while (left < right)
                {
                    if ((left & 1) == 1) sml = _oracle.Operate(sml, _data[left++]);
                    if ((right & 1) == 1) smr = _oracle.Operate(_data[--right], smr);
                    left >>= 1;
                    right >>= 1;
                }
                return _oracle.Operate(sml, smr);
            }
            public TMonoid QueryToAll() => _data[1];
            public int MaxRight(int left, Predicate<TMonoid> predicate)
            {
                if (left < 0 || _length < left) throw new ArgumentOutOfRangeException(nameof(left));
                if (predicate == null) throw new ArgumentNullException(nameof(predicate));
                if (!predicate(_monoidId)) throw new ArgumentException(nameof(predicate));
                if (left == _length) return _length;
                left += _size;
                var sm = _monoidId;
                do
                {
                    while ((left & 1) == 0) left >>= 1;
                    if (!predicate(_oracle.Operate(sm, _data[left])))
                    {
                        while (left < _size)
                        {
                            left <<= 1;
                            var tmp = _oracle.Operate(sm, _data[left]);
                            if (!predicate(tmp)) continue;
                            sm = tmp;
                            left++;
                        }
                        return left - _size;
                    }
                    sm = _oracle.Operate(sm, _data[left]);
                    left++;
                } while ((left & -left) != left);
                return _length;
            }
            public int MinLeft(int right, Predicate<TMonoid> predicate)
            {
                if (right < 0 || _length < right) throw new ArgumentOutOfRangeException(nameof(right));
                if (predicate == null) throw new ArgumentNullException(nameof(predicate));
                if (!predicate(_monoidId)) throw new ArgumentException(nameof(predicate));
                if (right == 0) return 0;
                right += _size;
                var sm = _monoidId;
                do
                {
                    right--;
                    while (right > 1 && (right & 1) == 1) right >>= 1;
                    if (!predicate(_oracle.Operate(_data[right], sm)))
                    {
                        while (right < _size)
                        {
                            right = (right << 1) + 1;
                            var tmp = _oracle.Operate(_data[right], sm);
                            if (!predicate(tmp)) continue;
                            sm = tmp;
                            right--;
                        }
                        return right + 1 - _size;
                    }
                    sm = _oracle.Operate(_data[right], sm);
                } while ((right & -right) != right);
                return 0;
            }
            private void Update(int k) => _data[k] = _oracle.Operate(_data[k << 1], _data[(k << 1) + 1]);
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
