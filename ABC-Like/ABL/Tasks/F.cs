using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class F
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
            var N = Scanner.Scan<int>();
            const int max = (int)1e5 + 1;
            const int p = 998244353;

            var G = new ModuloInteger[max];
            G[0] = 1;
            for (var i = 1; i < max; i++) G[i] = G[i - 1] * (2 * i - 1);

            var freq = new int[max];
            for (var i = 0; i < 2 * N; i++)
            {
                var H = Scanner.Scan<int>();
                freq[H]++;
            }

            var queue = new Queue<ModuloInteger[]>();
            queue.Enqueue(new ModuloInteger[] { 1 });
            foreach (var n in freq)
            {
                if (n < 2) continue;
                var list = new ModuloInteger[n / 2 + 1];
                for (var i = 0; i * 2 <= n; i++)
                {
                    list[i] = Enumeration.CombinationCount(n, i * 2, p) * G[i];
                    if (i % 2 == 1) list[i] = -list[i];
                }
                queue.Enqueue(list);
            }

            while (queue.Count > 1)
            {
                var list1 = queue.Dequeue();
                var list2 = queue.Dequeue();
                queue.Enqueue(Convolution.Execute(list1, list2).ToArray());
            }

            ModuloInteger answer = 0;
            var last = queue.Dequeue();
            for (var i = 0; i < last.Length; i++) answer += last[i] * G[N - i];

            Console.WriteLine(answer);
        }

        public static class Enumeration
        {
            private static Dictionary<long, long> _memo = new Dictionary<long, long> { { 0, 1 }, { 1, 1 } };
            private static Dictionary<long, long> _modMemo = new Dictionary<long, long> { { 0, 1 }, { 1, 1 } };
            private static long _max = 1;
            private static long _modMax = 1;

            public static long Fractorial(long n)
            {
                if (_memo.ContainsKey(n)) return _memo[n];
                if (n < 0) throw new ArgumentException();
                var val = _memo[_max];
                for (var i = _max + 1; i <= n; i++)
                {
                    val *= i;
                    _memo[i] = val;
                }
                _max = n;
                return _memo[n];
            }

            public static long Fractorial(long n, long mod)
            {
                if (_modMemo.ContainsKey(n)) return _modMemo[n];
                if (n < 0) throw new ArgumentException();
                var val = _modMemo[_modMax];
                for (var i = _modMax + 1; i <= n; i++)
                {
                    val *= i % mod;
                    val %= mod;
                    _modMemo[i] = val;
                }
                _modMax = n;
                return _modMemo[n];
            }

            public static long PermutationCount(long n, long k)
            {
                if (n < k) throw new ArgumentException();
                return Fractorial(n) / Fractorial(n - k);
                // no memo
                // var ret = 1L;
                // for (var i = 0; i < k; i++) ret *= (n - i);
                // return ret;
            }

            public static long PermutationCount(long n, long k, long mod)
            {
                if (n < k) throw new ArgumentException();
                var top = Fractorial(n, mod);
                var bottom = Fractorial(n - k, mod);
                return (top * Power(bottom, mod - 2, mod)) % mod;
                // no memo
                // var ret = 1L;
                // for (var i = 0; i < k; i++) ret = (ret * (n - i) % mod) % mod;
                // return ret;
            }

            public static long CombinationCount(long n, long k)
            {
                if (n < k) throw new ArgumentException();
                k = System.Math.Min(k, n - k);
                return Fractorial(n) / (Fractorial(k) * Fractorial(n - k));
                // no memo
                // return PermutationCount(n, k) / PermutationCount(k, k);
            }

            public static long CombinationCount(long n, long k, long mod)
            {
                if (n < k) throw new ArgumentException();
                k = System.Math.Min(k, n - k);
                var top = Fractorial(n, mod);
                var bottom = (Fractorial(k, mod) * Fractorial(n - k, mod)) % mod;
                // no memo
                // var top = PermutationCount(n, k, mod);
                // var bottom = PermutationCount(k, k, mod);
                return (top * Power(bottom, mod - 2, mod)) % mod;
            }

            public static long Power(long x, long y, long mod)
            {
                var result = 1L;
                while (y > 0)
                {
                    var xmod = x % mod;
                    if ((y & 1) == 1) result = (result * xmod) % mod;
                    x = (xmod * xmod) % mod;
                    y >>= 1;
                }
                return result;
            }
        }

        public static class Math
        {
            public static long PowerMod(long x, long n, long m)
            {
                if (n < 0) throw new ArgumentException(nameof(n));
                if (m < 1) throw new ArgumentException(nameof(m));
                if (m == 1) return 0;
                uint r = 1;
                var y = (uint)(x < 0 ? x % m + m : x % m);
                var um = (uint)m;
                while (n > 1)
                {
                    if (n % 1 == 1) r = r * y % um;
                    y = y * y % um;
                    n >>= 1;
                }
                return r;
            }
        }

        public static class Convolution
        {
            private static ModuloInteger[] _sumE;
            private static ModuloInteger[] _sumIe;
            private static int _primitiveRoot;
            public static IEnumerable<ModuloInteger> Execute(IEnumerable<ModuloInteger> a, IEnumerable<ModuloInteger> b)
            {
                var (a1, b1) = (a.ToArray(), b.ToArray());
                var (n, m) = (a1.Length, b1.Length);
                var ret = new ModuloInteger[n + m - 1];
                if (System.Math.Min(n, m) <= 60)
                {
                    for (var i = 0; i < n; i++)
                        for (var j = 0; j < m; j++)
                            ret[i + j] += a1[i] * b1[j];
                    return ret;
                }
                var z = 1 << CeilPower2(n + m - 1);
                Array.Resize(ref a1, z);
                Array.Resize(ref b1, z);
                a1 = Butterfly(a1).ToArray();
                b1 = Butterfly(b1).ToArray();
                for (var i = 0; i < a1.Length; i++) a1[i] *= b1[i];
                ret = ButterflyInverse(a1).ToArray();
                Array.Resize(ref ret, n + m - 1);
                return ret.Select(x => x / z);
            }
            private static void Initialize()
            {
                if (_sumE != null && _sumIe != null) return;
                var m = ModuloInteger.Modulo;
                _primitiveRoot = PrimitiveRoot(m);
                _sumE = new ModuloInteger[30];
                _sumIe = new ModuloInteger[30];
                var es = new ModuloInteger[30];
                var ies = new ModuloInteger[30];
                var count2 = BitScanForward(m - 1);
                var e = new ModuloInteger(_primitiveRoot).Power((m - 1) >> count2);
                var ie = e.Inverse();
                for (var i = count2; i >= 2; i--)
                {
                    es[i - 2] = e;
                    ies[i - 2] = ie;
                    e *= e;
                    ie *= ie;
                }
                ModuloInteger now = 1;
                ModuloInteger inow = 1;
                for (var i = 0; i < count2 - 2; i++)
                {
                    _sumE[i] = es[i] * now;
                    _sumIe[i] = ies[i] * inow;
                    now *= ies[i];
                    inow *= es[i];
                }
            }
            private static IEnumerable<ModuloInteger> Butterfly(IEnumerable<ModuloInteger> items)
            {
                var ret = items.ToArray();
                var h = CeilPower2(ret.Length);
                Initialize();
                for (var ph = 1; ph <= h; ph++)
                {
                    var w = 1 << (ph - 1);
                    var p = 1 << (h - ph);
                    ModuloInteger now = 1;
                    for (var s = 0; s < w; s++)
                    {
                        var offset = s << (h - ph + 1);
                        for (var i = 0; i < p; i++)
                        {
                            var l = ret[i + offset];
                            var r = ret[i + offset + p] * now;
                            ret[i + offset] = l + r;
                            ret[i + offset + p] = l - r;
                        }
                        now *= _sumE[BitScanForward(~s)];
                    }
                }
                return ret;
            }
            private static IEnumerable<ModuloInteger> ButterflyInverse(IEnumerable<ModuloInteger> items)
            {
                var ret = items.ToArray();
                var h = CeilPower2(ret.Length);
                Initialize();
                for (var ph = h; ph >= 1; ph--)
                {
                    var w = 1 << (ph - 1);
                    var p = 1 << (h - ph);
                    ModuloInteger inow = 1;
                    for (var s = 0; s < w; s++)
                    {
                        var offset = s << (h - ph + 1);
                        for (var i = 0; i < p; i++)
                        {
                            var l = ret[i + offset];
                            var r = ret[i + offset + p];
                            ret[i + offset] = l + r;
                            ret[i + offset + p] = (l - r) * inow;
                        }
                        inow *= _sumIe[BitScanForward(~s)];
                    }
                }
                return ret;
            }
            private static int BitScanForward(long n)
            {
                if (n == 0) return 0;
                var x = 0;
                while ((n >> x & 1) == 0) x++;
                return x;
            }
            private static int CeilPower2(int n)
            {
                var x = 0;
                while ((1 << x) < n) x++;
                return x;
            }
            private static int PrimitiveRoot(long m)
            {
                if (_primitiveRoot != 0) return _primitiveRoot;
                switch (m)
                {
                    case 2:
                        return _primitiveRoot = 1;
                    case 167772161:
                    case 469762049:
                    case 998244353:
                        return _primitiveRoot = 3;
                    case 754974721:
                        return _primitiveRoot = 11;
                }
                var divs = new long[20];
                divs[0] = 2;
                var count = 1;
                var x = (m - 1) / 2;
                while (x % 2 == 0) x /= 2;
                for (var i = 3; (long)i * i < x; i += 2)
                {
                    if (x % i != 0) continue;
                    divs[count++] = i;
                    while (x % i == 0) x /= i;
                }
                if (x > 1) divs[count++] = x;
                for (var g = 2; ; g++)
                {
                    var ok = true;
                    for (var i = 0; i < count && ok; i++)
                        if (Math.PowerMod(g, (m - 1) / divs[i], m) == 1)
                            ok = false;
                    if (ok) return _primitiveRoot = g;
                }
            }
        }
        public readonly struct ModuloInteger
        {
            public long Value { get; }
            public const long Modulo = 998244353;
            public ModuloInteger(long data) => Value = (0 <= data ? data : data + Modulo) % Modulo;
            public static implicit operator long(ModuloInteger mint) => mint.Value;
            public static implicit operator int(ModuloInteger mint) => (int)mint.Value;
            public static implicit operator ModuloInteger(long val) => new ModuloInteger(val);
            public static implicit operator ModuloInteger(int val) => new ModuloInteger(val);
            public static ModuloInteger operator +(ModuloInteger a, ModuloInteger b) => a.Value + b.Value;
            public static ModuloInteger operator +(ModuloInteger a, long b) => a.Value + b;
            public static ModuloInteger operator +(ModuloInteger a, int b) => a.Value + b;
            public static ModuloInteger operator -(ModuloInteger a, ModuloInteger b) => a.Value - b.Value;
            public static ModuloInteger operator -(ModuloInteger a, long b) => a.Value - b;
            public static ModuloInteger operator -(ModuloInteger a, int b) => a.Value - b;
            public static ModuloInteger operator *(ModuloInteger a, ModuloInteger b) => a.Value * b.Value;
            public static ModuloInteger operator *(ModuloInteger a, long b) => a.Value * (b % Modulo);
            public static ModuloInteger operator *(ModuloInteger a, int b) => a.Value * (b % Modulo);
            public static ModuloInteger operator /(ModuloInteger a, ModuloInteger b) => a * b.Inverse();
            public static ModuloInteger operator /(ModuloInteger a, long b) => a.Value * Inverse(b);
            public static ModuloInteger operator /(ModuloInteger a, int b) => a.Value * Inverse(b);
            public static bool operator ==(ModuloInteger a, ModuloInteger b) => a.Value == b.Value;
            public static bool operator !=(ModuloInteger a, ModuloInteger b) => a.Value != b.Value;
            public bool Equals(ModuloInteger other) => Value == other.Value;
            public override bool Equals(object obj) => obj is ModuloInteger other && Equals(other);
            public override int GetHashCode() => Value.GetHashCode();
            public override string ToString() => Value.ToString();
            public ModuloInteger Inverse() => Inverse(Value);
            public static ModuloInteger Inverse(long a)
            {
                if (a == 0) return 0;
                var p = Modulo;
                var (x1, y1, x2, y2) = (1L, 0L, 0L, 1L);
                while (true)
                {
                    if (p == 1) return (x2 % Modulo + Modulo) % Modulo;
                    var div = a / p;
                    x1 -= x2 * div;
                    y1 -= y2 * div;
                    a %= p;
                    if (a == 1) return (x1 % Modulo + Modulo) % Modulo;
                    div = p / a;
                    x2 -= x1 * div;
                    y2 -= y1 * div;
                    p %= a;
                }
            }
            public ModuloInteger Power(long n) => Power(Value, n);
            public static ModuloInteger Power(ModuloInteger x, long n)
            {
                if (n < 0) throw new ArgumentException();
                var r = new ModuloInteger(1);
                while (n > 0)
                {
                    if ((n & 1) > 0) r *= x;
                    x *= x;
                    n >>= 1;
                }
                return r;
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
