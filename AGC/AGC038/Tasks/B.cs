using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var (N, K) = Scanner.Scan<int, int>();
            var P = Scanner.ScanEnumerable<int>().ToArray();
            var minst = new SegmentTree<int>(P, new MinOracle());
            var maxst = new SegmentTree<int>(P, new MaxOracle());
            var inc = new int[N];
            inc[0] = 1;
            for (var i = 1; i < N; i++)
            {
                if (P[i] > P[i - 1]) inc[i] = inc[i - 1] + 1;
                else inc[i] = 1;
            }

            var answer = N - K + 1;
            var count = 0;
            if (inc[K - 1] >= K) count++;
            for (var i = 0; i + K < N; i++)
            {
                var min = minst.Query(i, i + K);
                var max = maxst.Query(i + 1, i + K + 1);
                if (P[i] == min && P[i + K] == max) answer--;
                else if (inc[i + K] >= K) count++;
            }

            answer -= Math.Max(0, count - 1);

            Console.WriteLine(answer);
        }

        public class MinOracle : IOracle<int>
        {
            public int MonoidIdentity => 200000;

            public int Operate(in int a, in int b) => Math.Min(a, b);
        }

        public class MaxOracle : IOracle<int>
        {
            public int MonoidIdentity => 0;

            public int Operate(in int a, in int b) => Math.Max(a, b);
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
