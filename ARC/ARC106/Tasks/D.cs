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
            var A = Scanner.ScanEnumerable<int>().Select(x => (ModuloInteger)x).ToArray();

            var frac = new ModuloInteger[K + 1];
            var ifrac = new ModuloInteger[K + 1];
            frac[0] = ifrac[0] = 1;
            for (var i = 1; i <= K; i++)
            {
                frac[i] = frac[i - 1] * i;
                ifrac[i] = 1 / frac[i];
            }

            var powSum = new ModuloInteger[K + 1];
            ModuloInteger pow = 1;
            for (var i = 0; i < N; i++)
            {
                pow = 1;
                powSum[0] += pow;
                for (var j = 1; j <= K; j++)
                {
                    pow *= A[i];
                    powSum[j] += pow;
                }
            }

            pow = 2;
            var i2 = ModuloInteger.Inverse(2);
            for (var i = 1; i <= K; i++)
            {
                ModuloInteger sum = 0;
                for (var j = 0; j <= i; j++)
                {
                    var comb = frac[i] * ifrac[j] * ifrac[i - j];
                    sum += comb * powSum[j] * powSum[i - j];
                }
                Console.WriteLine((sum - powSum[i] * pow) * i2);
                pow *= 2;
            }
        }

        public readonly struct ModuloInteger
        {
            public long Value { get; }
            // The modulo will be used as an editable property.
            // The constant modulo will be recommended to use for performances in use cases.
            public const long Modulo = 998244353;
            public ModuloInteger(long value) => Value = 0 <= value % Modulo ? value % Modulo : value % Modulo + Modulo;
            public static implicit operator long(ModuloInteger mint) => mint.Value;
            public static implicit operator int(ModuloInteger mint) => (int)mint.Value;
            public static implicit operator ModuloInteger(long value) => new ModuloInteger(value);
            public static implicit operator ModuloInteger(int value) => new ModuloInteger(value);
            public static ModuloInteger operator +(ModuloInteger a, ModuloInteger b) => a.Value + b.Value;
            public static ModuloInteger operator -(ModuloInteger a, ModuloInteger b) => a.Value - b.Value;
            public static ModuloInteger operator *(ModuloInteger a, ModuloInteger b) => a.Value * b.Value;
            public static ModuloInteger operator /(ModuloInteger a, ModuloInteger b) => a * b.Inverse();
            public static bool operator ==(ModuloInteger a, ModuloInteger b) => a.Value == b.Value;
            public static bool operator !=(ModuloInteger a, ModuloInteger b) => a.Value != b.Value;
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
            public static ModuloInteger Power(ModuloInteger value, long n)
            {
                if (n < 0) throw new ArgumentException();
                var ret = new ModuloInteger(1);
                while (n > 0)
                {
                    if ((n & 1) > 0) ret *= value;
                    value *= value;
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
