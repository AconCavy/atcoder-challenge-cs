using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    using mint = F.ModuloInteger;

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
            var V = Scanner.Scan<string>().Select(x => x - '0').ToArray();
            var N = V.Length;
            var M = Scanner.Scan<int>();
            var C = Scanner.ScanEnumerable<int>().ToArray();

            var ok = 0;
            foreach (var c in C)
            {
                ok |= 1 << c;
            }

            var max = 1 << 10;
            var count = new mint[2][] { new mint[max], new mint[max] };
            var sum = new mint[2][] { new mint[max], new mint[max] };
            mint curr = 0;
            var digits = 0;

            var t = 1;
            for (var i = 0; i < N; i++)
            {
                t ^= 1;
                var tt = t ^ 1;
                var c = V[i];
                Array.Fill(count[tt], 0);
                Array.Fill(sum[tt], 0);
                for (var j = 0; j < max; j++)
                {
                    for (var d = 0; d < 10; d++)
                    {
                        var next = j | (1 << d);
                        count[tt][next] += count[t][j];
                        sum[tt][next] += sum[t][j] * 10 + count[t][j] * d;
                    }
                }

                if (i > 0)
                {
                    for (var d = 1; d < 10; d++)
                    {
                        var next = 1 << d;
                        count[tt][next]++;
                        sum[tt][next] += d;
                    }
                }

                for (var d = 0; d < c; d++)
                {
                    if (i == 0 && d == 0) continue;
                    var next = digits | (1 << d);
                    count[tt][next]++;
                    sum[tt][next] += curr * 10 + d;
                }

                digits |= 1 << c;
                curr = curr * 10 + c;
            }

            t ^= 1;
            var answer = 0L;
            for (var j = 0; j < max; j++)
            {
                if ((j & ok) == ok)
                {
                    answer += sum[t][j];
                }
            }

            if ((digits & ok) == ok)
            {
                answer += curr;
            }

            Console.WriteLine(answer);
        }


        public readonly struct ModuloInteger : IEquatable<ModuloInteger>
        {
            public long Value { get; }
            // public static long Modulo { get; set; } = 998244353;
            // The modulo will be used as an editable property.
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
            public static ModuloInteger operator +(ModuloInteger a, int b) => a.Value + b;
            public static ModuloInteger operator +(int a, ModuloInteger b) => a + b.Value;
            public static ModuloInteger operator -(ModuloInteger a, int b) => a.Value - b;
            public static ModuloInteger operator -(int a, ModuloInteger b) => a - b.Value;
            public static ModuloInteger operator *(ModuloInteger a, int b) => a.Value * b;
            public static ModuloInteger operator *(int a, ModuloInteger b) => a * b.Value;
            public static ModuloInteger operator /(ModuloInteger a, int b) => a * Inverse(b);
            public static ModuloInteger operator /(int a, ModuloInteger b) => a * b.Inverse();
            public static ModuloInteger operator +(ModuloInteger a, long b) => a.Value + b;
            public static ModuloInteger operator +(long a, ModuloInteger b) => a + b.Value;
            public static ModuloInteger operator -(ModuloInteger a, long b) => a.Value - b;
            public static ModuloInteger operator -(long a, ModuloInteger b) => a - b.Value;
            public static ModuloInteger operator *(ModuloInteger a, long b) => a.Value * b;
            public static ModuloInteger operator *(long a, ModuloInteger b) => a * b.Value;
            public static ModuloInteger operator /(ModuloInteger a, long b) => a * Inverse(b);
            public static ModuloInteger operator /(long a, ModuloInteger b) => a * b.Inverse();
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
            public static T Scan<T>() where T : IConvertible => Convert<T>(ScanLine()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanLine().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
            private static string[] ScanLine() => Console.ReadLine()?.Trim().Split(' ') ?? Array.Empty<string>();
        }
    }
}
