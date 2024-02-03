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
        var (N, D) = Scanner.Scan<int, int>();
        var A = Scanner.ScanEnumerable<int>().ToArray();
        var max = A.Max() + 10;
        var st = new SegmentTree<int>(max, new Oracle());
        for (var i = 0; i < N; i++)
        {
            var l = Math.Max(0, A[i] - D);
            var r = Math.Min(A[i] + D + 1, max);
            var v = st.Query(l, r);
            st.Set(A[i], v + 1);
        }

        var answer = st.QueryToAll();
        Console.WriteLine(answer);
    }

    public class Oracle : IOracle<int>
    {
        public int IdentityElement => 0;

        public int Operate(int a, int b)
        {
            return Math.Max(a, b);
        }
    }

    public interface IOracle<TMonoid>
    {
        TMonoid IdentityElement { get; }
        TMonoid Operate(TMonoid a, TMonoid b);
    }
    public class SegmentTree<TMonoid>
    {
        public int Length { get; }
        private readonly IOracle<TMonoid> _oracle;
        private readonly TMonoid[] _data;
        private readonly int _log;
        private readonly int _dataSize;
        public SegmentTree(IReadOnlyCollection<TMonoid> source, IOracle<TMonoid> oracle) : this(source.Count, oracle)
        {
            var idx = _dataSize;
            foreach (var value in source) _data[idx++] = value;
            for (var i = _dataSize - 1; i >= 1; i--) Update(i);
        }
        public SegmentTree(int length, IOracle<TMonoid> oracle)
        {
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
            Length = length;
            _oracle = oracle;
            while (1 << _log < Length) _log++;
            _dataSize = 1 << _log;
            _data = new TMonoid[_dataSize << 1];
            Array.Fill(_data, oracle.IdentityElement);
        }
        public void Set(int index, TMonoid value)
        {
            if (index < 0 || Length <= index) throw new ArgumentOutOfRangeException(nameof(index));
            index += _dataSize;
            _data[index] = value;
            for (var i = 1; i <= _log; i++) Update(index >> i);
        }
        public TMonoid Get(int index)
        {
            if (index < 0 || Length <= index) throw new ArgumentOutOfRangeException(nameof(index));
            return _data[index + _dataSize];
        }
        public TMonoid Query(int left, int right)
        {
            if (left < 0 || right < left || Length < right) throw new ArgumentOutOfRangeException();
            var (sml, smr) = (_oracle.IdentityElement, _oracle.IdentityElement);
            left += _dataSize;
            right += _dataSize;
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
        public int MaxRight(int left, Func<TMonoid, bool> predicate)
        {
            if (left < 0 || Length < left) throw new ArgumentOutOfRangeException(nameof(left));
            if (predicate is null) throw new ArgumentNullException(nameof(predicate));
            if (!predicate(_oracle.IdentityElement)) throw new ArgumentException(nameof(predicate));
            if (left == Length) return Length;
            left += _dataSize;
            var sm = _oracle.IdentityElement;
            do
            {
                while ((left & 1) == 0) left >>= 1;
                if (!predicate(_oracle.Operate(sm, _data[left])))
                {
                    while (left < _dataSize)
                    {
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
            var sm = _oracle.IdentityElement;
            do
            {
                right--;
                while (right > 1 && (right & 1) == 1) right >>= 1;
                if (!predicate(_oracle.Operate(_data[right], sm)))
                {
                    while (right < _dataSize)
                    {
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
