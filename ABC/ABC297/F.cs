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
            var (H, W, K) = Scanner.Scan<int, int, int>();

            var fact = new mint[H * W + 1];
            var ifact = new mint[H * W + 1];
            fact[0] = ifact[0] = 1;
            for (var i = 1; i <= H * W; i++)
            {
                fact[i] = fact[i - 1] * i;
                ifact[i] = 1 / fact[i];
            }

            mint Combination(int n, int k)
            {
                if (n < k || n < 0 || k < 0) return 0;
                return fact[n] * ifact[k] * ifact[n - k];
            }

            mint score = 0;
            mint pattern = Combination(H * W, K);

            for (var h = 1; h <= H; h++)
            {
                for (var w = 1; w <= W; w++)
                {
                    var s = h * w;
                    if (s < K) continue;
                    var comb = Combination(s, K); //
                    var pat = (H - h + 1) * (W - w + 1);
                    score += (mint)s * comb * pat;
                }
            }

            var answer = score / pattern;
            Console.WriteLine(answer);
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
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]), Convert<T6>(buffer[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static string[] Scan()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
