using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    using mint = D.ModuloInteger;
    public class D
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
            var (N, M) = Scanner.Scan<int, int>();
            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--; b--;
                G[a].Add(b);
                G[b].Add(a);
            }

            var costs = new long[N];
            Array.Fill(costs, long.MaxValue);
            costs[0] = 0;
            var dp = new mint[N + 1];
            dp[0] = 1;
            var queue = new PriorityQueue<(int U, long Cost)>((x, y) => x.Cost.CompareTo(y.Cost));
            queue.Enqueue((0, 0));
            while (queue.Count > 0)
            {
                var (u, cu) = queue.Dequeue();
                if (costs[u] < cu) continue;
                foreach (var v in G[u])
                {
                    var c = costs[u] + 1;
                    if (costs[v] < c) continue;
                    if (costs[v] == c) dp[v] += dp[u];
                    else
                    {
                        costs[v] = c;
                        dp[v] = dp[u];
                        queue.Enqueue((v, c));
                    }
                }
            }

            var answer = dp[N - 1];
            Console.WriteLine(answer);
        }

        public class PriorityQueue<T> : IReadOnlyCollection<T>
        {
            private readonly Comparison<T> _comparison;
            private readonly List<T> _heap;
            public PriorityQueue() : this(items: null)
            {
            }
            public PriorityQueue(IEnumerable<T> items) : this(items, Comparer<T>.Default)
            {
            }
            public PriorityQueue(IComparer<T> comparer) : this(null, comparer)
            {
            }
            public PriorityQueue(Comparison<T> comparison) : this(null, comparison)
            {
            }
            public PriorityQueue(IEnumerable<T> items, IComparer<T> comparer)
                : this(items, (comparer ?? Comparer<T>.Default).Compare)
            {
            }
            public PriorityQueue(IEnumerable<T> items, Comparison<T> comparison)
            {
                _heap = new List<T>();
                _comparison = comparison;
                if (items == null) return;
                foreach (var item in items) Enqueue(item);
            }
            public int Count => _heap.Count;
            public IEnumerator<T> GetEnumerator() => _heap.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public void Enqueue(T item)
            {
                var child = Count;
                _heap.Add(item);
                while (child > 0)
                {
                    var parent = (child - 1) / 2;
                    if (_comparison(_heap[parent], _heap[child]) <= 0) break;
                    (_heap[parent], _heap[child]) = (_heap[child], _heap[parent]);
                    child = parent;
                }
            }
            public T Dequeue()
            {
                if (Count == 0) throw new InvalidOperationException();
                var ret = _heap[0];
                _heap[0] = _heap[Count - 1];
                _heap.RemoveAt(Count - 1);
                var parent = 0;
                while (parent * 2 + 1 < Count)
                {
                    var left = parent * 2 + 1;
                    var right = parent * 2 + 2;
                    if (right < Count && _comparison(_heap[left], _heap[right]) > 0)
                        left = right;
                    if (_comparison(_heap[parent], _heap[left]) <= 0) break;
                    (_heap[parent], _heap[left]) = (_heap[left], _heap[parent]);
                    parent = left;
                }
                return ret;
            }
            public T Peek()
            {
                if (Count == 0) throw new InvalidOperationException();
                return _heap[0];
            }
            public bool TryDequeue(out T result)
            {
                if (Count > 0)
                {
                    result = Dequeue();
                    return true;
                }
                result = default;
                return false;
            }
            public bool TryPeek(out T result)
            {
                if (Count > 0)
                {
                    result = Peek();
                    return true;
                }
                result = default;
                return false;
            }
            public void Clear() => _heap.Clear();
            public bool Contains(T item) => _heap.Contains(item);
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
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
