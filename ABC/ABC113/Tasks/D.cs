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
            var (H, W, K) = Scanner.Scan<int, int, int>();
            var dp = new ModuloInteger[H + 1, W];
            dp[0, 0] = 1;
            for (var h = 0; h < H; h++)
            {
                for (var w = 0; w < W; w++)
                {
                    for (var s = 0; s < 1 << (W - 1); s++)
                    {
                        var ok = true;
                        for (var k = 0; k < W - 2; k++)
                        {
                            if ((s >> k & 1) == 1 && (s >> (k + 1) & 1) == 1) ok = false;
                        }

                        if (!ok) continue;
                        if (w >= 1 && (s >> (w - 1) & 1) == 1) dp[h + 1, w - 1] += dp[h, w];
                        else if (w <= W - 2 && (s >> w & 1) == 1) dp[h + 1, w + 1] += dp[h, w];
                        else dp[h + 1, w] += dp[h, w];
                    }
                }
            }

            Console.WriteLine(dp[H, K - 1]);
        }

        public readonly struct ModuloInteger : IEquatable<ModuloInteger>
        {
            public long Value { get; }
            // public static long Modulo { get; private set; } = 998244353;
            // public static void SetModulo(long m) => Modulo = m;
            // public static void SetModulo998244353() => SetModulo(998244353);
            // public static void SetModulo1000000007() => SetModulo(1000000007);
            // The modulo will be used as an editable property.
            // The constant modulo will be recommended to use for performances in use cases.
            public const long Modulo = 1000000007;
            public ModuloInteger(int value) => Value = 0 <= value ? value % Modulo : value % Modulo + Modulo;
            public ModuloInteger(long value) => Value = 0 <= value ? value % Modulo : value % Modulo + Modulo;
            public static implicit operator int(ModuloInteger mint) => (int)mint.Value;
            public static implicit operator long(ModuloInteger mint) => mint.Value;
            public static implicit operator ModuloInteger(int value) => new ModuloInteger(value);
            public static implicit operator ModuloInteger(long value) => new ModuloInteger(value);
            public static ModuloInteger operator +(in ModuloInteger a, in ModuloInteger b) => a.Value + b.Value;
            public static ModuloInteger operator -(in ModuloInteger a, in ModuloInteger b) => a.Value - b.Value;
            public static ModuloInteger operator *(in ModuloInteger a, in ModuloInteger b) => a.Value * b.Value;
            public static ModuloInteger operator /(in ModuloInteger a, in ModuloInteger b) => a * b.Inverse();
            public static ModuloInteger operator +(in ModuloInteger a, int b) => a.Value + b;
            public static ModuloInteger operator +(int a, in ModuloInteger b) => a + b.Value;
            public static ModuloInteger operator -(in ModuloInteger a, int b) => a.Value - b;
            public static ModuloInteger operator -(int a, in ModuloInteger b) => a - b.Value;
            public static ModuloInteger operator *(in ModuloInteger a, int b) => a.Value * b;
            public static ModuloInteger operator *(int a, in ModuloInteger b) => a * b.Value;
            public static ModuloInteger operator /(in ModuloInteger a, int b) => a * Inverse(b);
            public static ModuloInteger operator /(int a, in ModuloInteger b) => a * b.Inverse();
            public static ModuloInteger operator +(in ModuloInteger a, long b) => a.Value + b;
            public static ModuloInteger operator +(long a, in ModuloInteger b) => a + b.Value;
            public static ModuloInteger operator -(in ModuloInteger a, long b) => a.Value - b;
            public static ModuloInteger operator -(long a, in ModuloInteger b) => a - b.Value;
            public static ModuloInteger operator *(in ModuloInteger a, long b) => a.Value * b;
            public static ModuloInteger operator *(long a, in ModuloInteger b) => a * b.Value;
            public static ModuloInteger operator /(in ModuloInteger a, long b) => a * Inverse(b);
            public static ModuloInteger operator /(long a, in ModuloInteger b) => a * b.Inverse();
            public static bool operator ==(in ModuloInteger a, in ModuloInteger b) => a.Value == b.Value;
            public static bool operator !=(in ModuloInteger a, in ModuloInteger b) => a.Value != b.Value;
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
                if (n < 0) throw new ArgumentException();
                var ret = 1L;
                while (n > 0)
                {
                    if ((n & 1) > 0) ret = ret * value % Modulo;
                    value = value * value % Modulo;
                    n >>= 1;
                }
                return ret;
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
