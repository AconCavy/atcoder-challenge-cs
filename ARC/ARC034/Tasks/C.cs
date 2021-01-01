using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    using mint = C.ModuloInteger;

    public class C
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
            var (A, B) = Scanner.Scan<int, int>();
            var dict = new Dictionary<long, int>();
            for (var x = B + 1; x <= A; x++)
            {
                foreach (var (p, c) in Prime.GetFactors(x))
                {
                    if (!dict.ContainsKey(p)) dict[p] = 0;
                    dict[p] += c;
                }
            }
            mint answer = 1;
            foreach (var value in dict.Values) answer *= value + 1;
            Console.WriteLine(answer);
        }

        public static class Prime
        {
            public static IDictionary<long, int> GetFactors(long value)
            {
                var factors = new Dictionary<long, int>();
                if (value < 2) return factors;
                void CountUp(long n)
                {
                    if (value % n != 0) return;
                    factors[n] = 0;
                    while (value % n == 0)
                    {
                        value /= n;
                        factors[n]++;
                    }
                }
                CountUp(2);
                for (var i = 3L; i * i <= value; i += 2) CountUp(i);
                if (value > 1) factors[value] = 1;
                return factors;
            }
            public static int[] GetPrimes(int value)
            {
                if (value < 2) return Array.Empty<int>();
                if (value == 2) return new[] { 2 };
                const int bit = 32;
                const int limit = 1024;
                value = (value + 1) / 2;
                var length = (value + bit) / bit;
                var sieve = length < limit ? stackalloc uint[length] : new uint[length];
                for (var i = value % bit; i < bit; i++) sieve[^1] |= 1U << i;
                for (var i = 1; i * i <= value;)
                {
                    for (var j = i; j <= value; j += i * 2 + 1) sieve[j / bit] |= 1U << (j % bit);
                    sieve[i / bit] &= ~(1U << (i % bit));
                    do
                    {
                        i++;
                    } while (i * i <= value && ((sieve[i / bit] >> (i % bit)) & 1) == 1);
                }
                var count = bit * length;
                foreach (var flags in sieve) count -= BitOperations.PopCount(flags);
                var primes = count < limit ? stackalloc int[count] : new int[count];
                primes[0] = 2;
                var index = 1;
                for (var i = 1; index < count && i <= value; i++)
                    if (((sieve[i / bit] >> (i % bit)) & 1U) == 0)
                        primes[index++] = i * 2 + 1;
                return primes.ToArray();
            }
            public static bool IsPrime(int value)
            {
                if (value == 2) return true;
                if (value < 2 || value % 2 == 0) return false;
                if (value < 2e5)
                {
                    for (var i = 3L; i * i <= value; i += 2)
                        if (value % i == 0)
                            return false;
                    return true;
                }
                long d = value - 1;
                d /= d & -d;
                foreach (var w in stackalloc long[] { 2, 7, 61 })
                {
                    var a = 1L;
                    var t = d;
                    var m = w;
                    while (t > 0)
                    {
                        if (t % 2 == 1) a = a * m % value;
                        m = m * m % value;
                        t >>= 1;
                    }
                    t = d;
                    while (t != value - 1 && a != 1 && a != value - 1)
                    {
                        a = a * a % value;
                        t <<= 1;
                    }
                    if (w % value != 0 && a != value - 1 && t % 2 == 0) return false;
                }
                return true;
            }
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
