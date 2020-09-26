using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
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
            var (N, Q) = Scanner.Scan<int, int>();

            S Operation(S a, S b) => new S(a.X * b.W + b.X, a.W * b.W);
            var idData = new S(0, 1);
            var inv9 = ModuloInteger.Inverse(9);
            S Mapping(int f, S x) => f == 0 ? x : new S((x.W - 1) * inv9 * f, x.W);
            int Composition(int f, int g) => f == 0 ? g : f;
            var idInt = 0;

            var lst = new LazySegmentTree<S, int>(N, Operation, idData, Mapping, Composition, idInt);
            for (var i = 0; i < N; i++) lst.Set(i, new S(1, 10));
            for (var i = 0; i < Q; i++)
            {
                var (L, R, D) = Scanner.Scan<int, int, int>();
                lst.Apply(L - 1, R, D);
                Console.WriteLine(lst.QueryToAll().X);
            }
        }

        public readonly struct S
        {
            public readonly ModuloInteger X;
            public readonly ModuloInteger W;
            public S(ModuloInteger x, ModuloInteger w) { X = x; W = w; }
        }

        public class LazySegmentTree<T, U>
        {
            private readonly int _n;
            private readonly int _size;
            private readonly int _log;
            private readonly T[] _data;
            private readonly U[] _lazy;
            private readonly Func<T, T, T> _operation;
            private readonly Func<U, T, T> _mapping;
            private readonly Func<U, U, U> _composition;
            private readonly T _identityT;
            private readonly U _identityU;
            public LazySegmentTree(int n, Func<T, T, T> operation, T identityT, Func<U, T, T> mapping,
                Func<U, U, U> composition, U identityU) :
                this(new T[n], operation, identityT, mapping, composition, identityU)
            {
            }
            public LazySegmentTree(IEnumerable<T> data, Func<T, T, T> operation, T identityT, Func<U, T, T> mapping,
                Func<U, U, U> composition, U identityU)
            {
                var d = data.ToArray();
                _n = d.Length;
                _operation = operation;
                _identityT = identityT;
                _mapping = mapping;
                _composition = composition;
                _identityU = identityU;
                while (1 << _log < _n) _log++;
                _size = 1 << _log;
                _data = Enumerable.Repeat(identityT, _size << 1).ToArray();
                _lazy = Enumerable.Repeat(identityU, _size).ToArray();
                d.CopyTo(_data, _size);
                for (var i = _size - 1; i >= 1; i--) Update(i);
            }
            public void Set(int p, T x)
            {
                if (p < 0 || _n <= p) throw new IndexOutOfRangeException(nameof(p));
                p += _size;
                for (var i = _log; i >= 1; i--) Push(p >> i);
                _data[p] = x;
                for (var i = 1; i <= _log; i++) Update(p >> i);
            }
            public T Get(int p)
            {
                if (p < 0 || _n <= p) throw new IndexOutOfRangeException(nameof(p));
                p += _size;
                for (var i = _log; i >= 1; i--) Push(p >> i);
                return _data[p];
            }
            public T Query(int l, int r)
            {
                if (l < 0 || r < l || _n < r) throw new IndexOutOfRangeException();
                if (l == r) return _identityT;
                l += _size;
                r += _size;
                for (var i = _log; i >= 1; i--)
                {
                    if ((l >> i) << i != l) Push(l >> i);
                    if ((r >> i) << i != r) Push(r >> i);
                }
                var (sml, smr) = (_identityT, _identityT);
                while (l < r)
                {
                    if ((l & 1) == 1) sml = _operation(sml, _data[l++]);
                    if ((r & 1) == 1) smr = _operation(_data[--r], smr);
                    l >>= 1;
                    r >>= 1;
                }
                return _operation(sml, smr);
            }
            public T QueryToAll() => _data[1];
            public void Apply(int p, U u)
            {
                if (p < 0 || _n <= p) throw new IndexOutOfRangeException(nameof(p));
                p += _size;
                for (var i = _log; i >= 1; i--) Push(p >> i);
                _data[p] = _mapping(u, _data[p]);
                for (var i = 1; i <= _log; i++) Update(p >> i);
            }
            public void Apply(int l, int r, U u)
            {
                if (l < 0 || r < l || _n < r) throw new IndexOutOfRangeException();
                if (l == r) return;
                l += _size;
                r += _size;
                for (var i = _log; i >= 1; i--)
                {
                    if ((l >> i) << i != l) Push(l >> i);
                    if ((r >> i) << i != r) Push((r - 1) >> i);
                }
                var (l2, r2) = (l, r);
                while (l2 < r2)
                {
                    if ((l2 & 1) == 1) ApplyToAll(l2++, u);
                    if ((r2 & 1) == 1) ApplyToAll(--r2, u);
                    l2 >>= 1;
                    r2 >>= 1;
                }
                for (var i = 1; i <= _log; i++)
                {
                    if ((l >> i) << i != l) Update(l >> i);
                    if ((r >> i) << i != r) Update((r - 1) >> i);
                }
            }
            public int MaxRight(int l, Func<T, bool> func)
            {
                if (l < 0 || _n <= l) throw new IndexOutOfRangeException(nameof(l));
                if (!func(_identityT)) throw new ArgumentException(nameof(func));
                if (l == _n) return _n;
                l += _size;
                var sm = _identityT;
                do
                {
                    while ((l & 1) == 0) l >>= 1;
                    if (!func(_operation(sm, _data[l])))
                    {
                        while (l < _size)
                        {
                            l *= 2;
                            var tmp = _operation(sm, _data[l]);
                            if (!func(tmp)) continue;
                            sm = tmp;
                            l++;
                        }
                        return l - _size;
                    }
                    sm = _operation(sm, _data[l]);
                    l++;
                } while ((l & -l) != l);
                return _n;
            }
            public int MinLeft(int r, Func<T, bool> func)
            {
                if (r < 0 || _n <= r) throw new IndexOutOfRangeException(nameof(r));
                if (!func(_identityT)) throw new ArgumentException(nameof(func));
                if (r == 0) return 0;
                r += _size;
                var sm = _identityT;
                do
                {
                    r--;
                    while (r > 1 && (r & 1) == 0) r >>= 1;
                    if (!func(_operation(_data[r], sm)))
                    {
                        while (r < _size)
                        {
                            r = (r << 1) + 1;
                            var tmp = _operation(_data[r], sm);
                            if (!func(tmp)) continue;
                            sm = tmp;
                            r--;
                        }
                        return r + 1 - _size;
                    }
                    sm = _operation(_data[r], sm);
                    r++;
                } while ((r & -r) != r);
                return 0;
            }
            private void Update(int k) => _data[k] = _operation(_data[k << 1], _data[(k << 1) + 1]);
            private void ApplyToAll(int k, U u)
            {
                _data[k] = _mapping(u, _data[k]);
                if (k < _size) _lazy[k] = _composition(u, _lazy[k]);
            }
            private void Push(int k)
            {
                ApplyToAll(k << 1, _lazy[k]);
                ApplyToAll((k << 1) + 1, _lazy[k]);
                _lazy[k] = _identityU;
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
