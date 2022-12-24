using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
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
            var P = Scanner.ScanEnumerable<int>().ToArray();

            int F1(int u, int v)
            {
                return Math.Abs(P[u] - P[v]) + Math.Abs(u - v);
            }

            bool F2(int u, int d, int m)
            {
                var t = u + d * m;
                return 0 <= t && t < N;
            }

            var D = new int[N];
            const int inf = (int)1e9;
            for (var i = 0; i < N; i++)
            {
                D[i] = inf;
            }

            var D2 = new[] { -1, 1 };
            var dsu = new DisjointSetUnion(N);
            var queue = new PriorityQueue<(int C, int U, int V)>((x, y) => x.C.CompareTo(y.C));

            void F3(int u, int c)
            {
                foreach (var m in D2)
                {
                    for (var d = 1; F2(u, d, m); d++)
                    {
                        var v = u + d * m;
                        var cc = F1(u, v);
                        if (cc >= D[v]) continue;
                        D[v] = cc;
                        queue.Enqueue((cc, u, v));
                    }
                }
            }

            for (var i = 0; i < N; i++)
            {
                if (D[i] != inf) continue;
                for (var j = 0; j < N; j++)
                {
                    if (i == j) continue;
                    queue.Enqueue((F1(i, j), i, j));
                }

                while (queue.Count > 0)
                {
                    var (c, u, v) = queue.Dequeue();
                    if (c < D[u])
                    {
                        D[u] = c;
                        F3(u, c);
                    }

                    if (c < D[v])
                    {
                        D[v] = c;
                        F3(v, c);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", D));
        }

        public class PriorityQueue<T> : IReadOnlyCollection<T>
        {
            private readonly Comparison<T> _comparison;
            private readonly List<T> _heap;
            public PriorityQueue(IEnumerable<T> items, IComparer<T> comparer = null) : this(comparer)
            {
                foreach (var item in items) Enqueue(item);
            }
            public PriorityQueue(IEnumerable<T> items, Comparison<T> comparison) : this(comparison)
            {
                foreach (var item in items) Enqueue(item);
            }
            public PriorityQueue(IComparer<T> comparer = null) : this((comparer ?? Comparer<T>.Default).Compare) { }
            public PriorityQueue(Comparison<T> comparison)
            {
                _heap = new List<T>();
                _comparison = comparison;
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
                var result = _heap[0];
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
                return result;
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

        public class DisjointSetUnion
        {
            public int Length { get; }
            private readonly int[] _parentOrSize;
            public DisjointSetUnion(int length)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                Length = length;
                _parentOrSize = new int[Length];
                Array.Fill(_parentOrSize, -1);
            }
            public int Merge(int u, int v)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                var (x, y) = (LeaderOf(u), LeaderOf(v));
                if (x == y) return x;
                if (-_parentOrSize[x] < -_parentOrSize[y]) (x, y) = (y, x);
                _parentOrSize[x] += _parentOrSize[y];
                _parentOrSize[y] = x;
                return x;
            }
            public bool IsSame(int u, int v)
            {
                if (u < 0 || Length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                return LeaderOf(u) == LeaderOf(v);
            }
            public int LeaderOf(int v)
            {
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                if (_parentOrSize[v] < 0) return v;
                return _parentOrSize[v] = LeaderOf(_parentOrSize[v]);
            }
            public int SizeOf(int v)
            {
                if (v < 0 || Length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                return -_parentOrSize[LeaderOf(v)];
            }
            public IEnumerable<IReadOnlyCollection<int>> GetGroups()
            {
                var result = new List<int>[Length].Select(x => new List<int>()).ToArray();
                for (var i = 0; i < Length; i++) result[LeaderOf(i)].Add(i);
                return result.Where(x => x.Count > 0);
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
