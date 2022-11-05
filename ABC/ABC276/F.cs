using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    using mint = F.ModuloInteger;

    public class F
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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var (map, _) = Compress(A);
            var ft1 = new FenwickTree(N);
            var ft2 = new FenwickTree(N);
            var dp = new mint[N];
            dp[0] = A[0];
            ft1.Add(map[A[0]], 1);
            ft2.Add(map[A[0]], A[0]);

            for (var i = 1; i < N; i++)
            {
                var small = ft1.Sum(map[A[i]] + 1);
                var sum = ft2.Sum(map[A[i]] + 1, N);
                dp[i] = dp[i - 1] + (small * A[i] + sum) * 2 + A[i];

                ft1.Add(map[A[i]], 1);
                ft2.Add(map[A[i]], A[i]);
            }

            for (var i = 0; i < N; i++)
            {
                var curr = (mint)(i + 1) * (i + 1);
                Console.WriteLine(dp[i] / curr);
            }
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
            public int Length { get; }
            private readonly mint[] _data;
            public FenwickTree(int length)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                Length = length;
                _data = new mint[length];
            }
            public void Add(int index, long value)
            {
                if (index < 0 || Length <= index) throw new ArgumentOutOfRangeException(nameof(index));
                index++;
                while (index <= Length)
                {
                    _data[index - 1] += value;
                    index += index & -index;
                }
            }
            public mint Sum(int length)
            {
                if (length < 0 || Length < length) throw new ArgumentOutOfRangeException(nameof(length));
                mint s = 0;
                while (length > 0)
                {
                    s += _data[length - 1];
                    length -= length & -length;
                }
                return s;
            }
            public mint Sum(int left, int right)
            {
                if (left < 0 || right < left || Length < right) throw new ArgumentOutOfRangeException();
                return Sum(right) - Sum(left);
            }
            public int LowerBound(long value) => Bound(value, (x, y) => x <= y);
            public int UpperBound(long value) => Bound(value, (x, y) => x < y);
            private int Bound(long value, Func<long, long, bool> compare)
            {
                if (Length == 0 || compare(value, _data[0])) return 0;
                var x = 0;
                var r = 1;
                while (r < Length) r <<= 1;
                for (var k = r; k > 0; k >>= 1)
                {
                    if (x + k - 1 >= Length || compare(value, _data[x + k - 1])) continue;
                    value -= _data[x + k - 1];
                    x += k;
                }
                return x;
            }
        }

        public readonly struct ModuloInteger : IEquatable<ModuloInteger>
        {
            public long Value { get; }
            // The modulo will be used as an editable property.
            // public static long Modulo { get; set; } = 998244353;
            // The constant modulo will be recommended to use for performances in use cases.
            public const long Modulo = 998244353;
            public ModuloInteger(int value)
            {
                Value = value % Modulo;
                if (Value < 0) Value += Modulo;
            }
            public ModuloInteger(long value)
            {
                Value = value % Modulo;
                if (Value < 0) Value += Modulo;
            }
            public static implicit operator int(ModuloInteger mint) => (int)mint.Value;
            public static implicit operator long(ModuloInteger mint) => mint.Value;
            public static implicit operator ModuloInteger(int value) => new ModuloInteger(value);
            public static implicit operator ModuloInteger(long value) => new ModuloInteger(value);
            public static ModuloInteger operator +(ModuloInteger a, ModuloInteger b) => a.Value + b.Value;
            public static ModuloInteger operator -(ModuloInteger a, ModuloInteger b) => a.Value - b.Value;
            public static ModuloInteger operator *(ModuloInteger a, ModuloInteger b) => a.Value * b.Value;
            public static ModuloInteger operator /(ModuloInteger a, ModuloInteger b) => a * b.Inverse();
            public static bool operator ==(ModuloInteger a, ModuloInteger b) => a.Equals(b);
            public static bool operator !=(ModuloInteger a, ModuloInteger b) => !a.Equals(b);
            public bool Equals(ModuloInteger other) => Value == other.Value;
            public override bool Equals(object obj) => obj is ModuloInteger other && Equals(other);
            public override int GetHashCode() => Value.GetHashCode();
            public override string ToString() => Value.ToString();
            public ModuloInteger Inverse() => Inverse(Value);
            public static ModuloInteger Inverse(long value)
            {
                if (value == 0) return 0;
                var (s, t, m0, m1) = (Modulo, value, 0L, 1L);
                while (t > 0)
                {
                    var u = s / t;
                    s -= t * u;
                    m0 -= m1 * u;
                    (s, t) = (t, s);
                    (m0, m1) = (m1, m0);
                }
                if (m0 < 0) m0 += Modulo / s;
                return m0;
            }
            public ModuloInteger Power(long n) => Power(Value, n);
            public static ModuloInteger Power(long value, long n)
            {
                if (n < 0) throw new ArgumentException(nameof(n));
                var result = 1L;
                while (n > 0)
                {
                    if ((n & 1) > 0) result = result * value % Modulo;
                    value = value * value % Modulo;
                    n >>= 1;
                }
                return result;
            }
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
