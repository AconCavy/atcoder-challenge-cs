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
        var A = Scanner.ScanEnumerable<long>().ToArray();
        var B = Scanner.ScanEnumerable<int>().ToArray();
        var lst = new LazySegmentTree<Monoid, long>(N, new Oracle());
        for (var i = 0; i < N; i++)
        {
            lst.Set(i, new Monoid(A[i], 1));
        }

        foreach (var b in B)
        {
            var x = lst.Get(b);
            lst.Set(b, new Monoid(0, 1));
            var div = x.V / N;
            var rem = x.V % N;
            lst.Apply(0, N, div);
            var r = (int)Math.Min(rem, N - 1 - b);
            if (r > 0) lst.Apply(b + 1, b + 1 + r, 1);
            var l = (int)(rem - r);
            if (l > 0) lst.Apply(0, l, 1);
        }

        var answers = new long[N];
        for (var i = 0; i < N; i++)
        {
            answers[i] = lst.Get(i).V;
        }

        Console.WriteLine(string.Join(" ", answers));
    }

    public readonly record struct Monoid(long V, int S);

    public class Oracle : IOracle<Monoid, long>
    {
        public long IdentityMapping => 0;

        public Monoid IdentityElement => new(0, 1);

        public long Compose(long f, long g)
        {
            return f + g;
        }

        public Monoid Map(long f, Monoid x)
        {
            return new Monoid(x.V + f * x.S, x.S);
        }

        public Monoid Operate(Monoid a, Monoid b)
        {
            return new Monoid(a.V + b.V, a.S + b.S);
        }
    }

    public interface IOracle<TMonoid>
    {
        TMonoid IdentityElement { get; }
        TMonoid Operate(TMonoid a, TMonoid b);
    }
    public interface IOracle<TMonoid, TMapping> : IOracle<TMonoid>
    {
        TMapping IdentityMapping { get; }
        TMonoid Map(TMapping f, TMonoid x);
        TMapping Compose(TMapping f, TMapping g);
    }

    public class LazySegmentTree<TMonoid, TMapping>
    {
        public int Length { get; }
        private readonly IOracle<TMonoid, TMapping> _oracle;
        private readonly TMonoid[] _data;
        private readonly TMapping[] _lazy;
        private readonly int _log;
        private readonly int _dataSize;
        public LazySegmentTree(IReadOnlyCollection<TMonoid> source, IOracle<TMonoid, TMapping> oracle)
            : this(source.Count, oracle)
        {
            var idx = _dataSize;
            foreach (var value in source) _data[idx++] = value;
            for (var i = _dataSize - 1; i >= 1; i--) Update(i);
        }
        public LazySegmentTree(int length, IOracle<TMonoid, TMapping> oracle)
        {
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
            Length = length;
            _oracle = oracle;
            while (1 << _log < Length) _log++;
            _dataSize = 1 << _log;
            _data = new TMonoid[_dataSize << 1];
            Array.Fill(_data, _oracle.IdentityElement);
            _lazy = new TMapping[_dataSize];
            Array.Fill(_lazy, _oracle.IdentityMapping);
        }
        public void Set(int index, in TMonoid value)
        {
            if (index < 0 || Length <= index) throw new ArgumentOutOfRangeException(nameof(index));
            index += _dataSize;
            for (var i = _log; i >= 1; i--) Push(index >> i);
            _data[index] = value;
            for (var i = 1; i <= _log; i++) Update(index >> i);
        }
        public TMonoid Get(int index)
        {
            if (index < 0 || Length <= index) throw new ArgumentOutOfRangeException(nameof(index));
            index += _dataSize;
            for (var i = _log; i >= 1; i--) Push(index >> i);
            return _data[index];
        }
        public TMonoid Query(int left, int right)
        {
            if (left < 0 || right < left || Length < right) throw new ArgumentOutOfRangeException();
            if (left == right) return _oracle.IdentityElement;
            left += _dataSize;
            right += _dataSize;
            for (var i = _log; i >= 1; i--)
            {
                if ((left >> i) << i != left) Push(left >> i);
                if ((right >> i) << i != right) Push((right - 1) >> i);
            }
            var (sml, smr) = (_oracle.IdentityElement, _oracle.IdentityElement);
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
        public void Apply(int index, TMapping mapping)
        {
            if (index < 0 || Length <= index) throw new ArgumentOutOfRangeException(nameof(index));
            index += _dataSize;
            for (var i = _log; i >= 1; i--) Push(index >> i);
            _data[index] = _oracle.Map(mapping, _data[index]);
            for (var i = 1; i <= _log; i++) Update(index >> i);
        }
        public void Apply(int left, int right, in TMapping mapping)
        {
            if (left < 0 || right < left || Length < right) throw new ArgumentOutOfRangeException();
            if (left == right) return;
            left += _dataSize;
            right += _dataSize;
            for (var i = _log; i >= 1; i--)
            {
                if ((left >> i) << i != left) Push(left >> i);
                if ((right >> i) << i != right) Push((right - 1) >> i);
            }
            var (l, r) = (left, right);
            while (l < r)
            {
                if ((l & 1) == 1) ApplyToAll(l++, mapping);
                if ((r & 1) == 1) ApplyToAll(--r, mapping);
                l >>= 1;
                r >>= 1;
            }
            for (var i = 1; i <= _log; i++)
            {
                if ((left >> i) << i != left) Update(left >> i);
                if ((right >> i) << i != right) Update((right - 1) >> i);
            }
        }
        public int MaxRight(int left, Func<TMonoid, bool> predicate)
        {
            if (left < 0 || Length < left) throw new ArgumentOutOfRangeException(nameof(left));
            if (predicate is null) throw new ArgumentNullException(nameof(predicate));
            if (!predicate(_oracle.IdentityElement)) throw new ArgumentException(nameof(predicate));
            if (left == Length) return Length;
            left += _dataSize;
            for (var i = _log; i >= 1; i--) Push(left >> i);
            var sm = _oracle.IdentityElement;
            do
            {
                while ((left & 1) == 0) left >>= 1;
                if (!predicate(_oracle.Operate(sm, _data[left])))
                {
                    while (left < _dataSize)
                    {
                        Push(left);
                        left <<= 1;
                        var tmp = _oracle.Operate(sm, _data[left]);
                        if (!predicate(tmp)) continue;
                        sm = tmp;
                        left++;
                    }
                    return left - _dataSize;
                }
                sm = _oracle.Operate(sm, _data[left]);
                left++;
            } while ((left & -left) != left);
            return Length;
        }
        public int MinLeft(int right, Func<TMonoid, bool> predicate)
        {
            if (right < 0 || Length < right) throw new ArgumentOutOfRangeException(nameof(right));
            if (predicate is null) throw new ArgumentNullException(nameof(predicate));
            if (!predicate(_oracle.IdentityElement)) throw new ArgumentException(nameof(predicate));
            if (right == 0) return 0;
            right += _dataSize;
            for (var i = _log; i >= 1; i--) Push((right - 1) >> i);
            var sm = _oracle.IdentityElement;
            do
            {
                right--;
                while (right > 1 && (right & 1) == 1) right >>= 1;
                if (!predicate(_oracle.Operate(_data[right], sm)))
                {
                    while (right < _dataSize)
                    {
                        Push(right);
                        right = (right << 1) + 1;
                        var tmp = _oracle.Operate(_data[right], sm);
                        if (!predicate(tmp)) continue;
                        sm = tmp;
                        right--;
                    }
                    return right + 1 - _dataSize;
                }
                sm = _oracle.Operate(_data[right], sm);
            } while ((right & -right) != right);
            return 0;
        }
        private void Update(int k) => _data[k] = _oracle.Operate(_data[k << 1], _data[(k << 1) + 1]);
        private void ApplyToAll(int k, in TMapping mapping)
        {
            _data[k] = _oracle.Map(mapping, _data[k]);
            if (k < _dataSize) _lazy[k] = _oracle.Compose(mapping, _lazy[k]);
        }
        private void Push(int k)
        {
            ApplyToAll(k << 1, _lazy[k]);
            ApplyToAll((k << 1) + 1, _lazy[k]);
            _lazy[k] = _oracle.IdentityMapping;
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
