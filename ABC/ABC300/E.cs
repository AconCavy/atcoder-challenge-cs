using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    using mint = E.ModuloInteger;

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
            var N = Scanner.Scan<long>();
            var C = new Dictionary<int, long>();
            var n = N;
            foreach (var v in new[] { 2, 3, 5 })
            {
                C[v] = 0;
                while (n % v == 0)
                {
                    C[v]++;
                    n /= v;
                }
            }

            if (n != 1)
            {
                Console.WriteLine(0);
                return;
            }

            var i5 = mint.Inverse(5);

            var (c2, c3, c5) = (C[2], C[3], C[5]);
            var M = c2 + c3 + c5;
            var dp = new mint[M + 1, c2 + 1, c3 + 1, c5 + 1];
            dp[0, 0, 0, 0] = 1;
            for (var i = 0; i < M; i++)
            {
                for (var p2 = 0; p2 <= c2; p2++)
                {
                    for (var p3 = 0; p3 <= c3; p3++)
                    {
                        for (var p5 = 0; p5 <= c5; p5++)
                        {
                            if (p2 + 1 <= c2) dp[i + 1, p2 + 1, p3, p5] += dp[i, p2, p3, p5] * i5;
                            if (p3 + 1 <= c3) dp[i + 1, p2, p3 + 1, p5] += dp[i, p2, p3, p5] * i5;
                            if (i + 2 <= M && p2 + 2 <= c2) dp[i + 2, p2 + 2, p3, p5] += dp[i, p2, p3, p5] * i5;
                            if (p5 + 1 <= c5) dp[i + 1, p2, p3, p5 + 1] += dp[i, p2, p3, p5] * i5;
                            if (i + 2 <= M && p2 + 1 <= c2 && p3 + 1 <= c3) dp[i + 2, p2 + 1, p3 + 1, p5] += dp[i, p2, p3, p5] * i5;
                        }
                    }
                }
            }

            var answer = dp[M, c2, c3, c5];
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
