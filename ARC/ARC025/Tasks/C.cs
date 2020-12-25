using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
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
            var (N, M, R, T) = Scanner.Scan<int, int, int, int>();
            var G = new List<Edge>[N].Select(_ => new List<Edge>(M / 2)).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (a, b, c) = Scanner.Scan<int, int, long>();
                a--; b--;
                G[a].Add(new Edge(b, c));
                G[b].Add(new Edge(a, c));
            }

            const long inf = (long)1e18;
            var queue = new PriorityQueue<Edge>((x, y) => x.Cost.CompareTo(y.Cost));
            var answer = 0L;
            Span<long> span = stackalloc long[N];
            for (var a = 0; a < N; a++)
            {
                queue.Enqueue(new Edge(a, 0));
                span.Fill(inf);
                span[a] = 0;
                while (queue.Count > 0)
                {
                    var u = queue.Dequeue();
                    if (span[u.Idx] < u.Cost) continue;
                    foreach (var v in G[u.Idx])
                    {
                        if (span[v.Idx] <= span[u.Idx] + v.Cost) continue;
                        span[v.Idx] = span[u.Idx] + v.Cost;
                        queue.Enqueue(v);
                    }
                }

                var depths = span.ToArray();
                Array.Sort(depths);
                for (var c = 1; c < N; c++)
                {
                    var (l, r) = (-1, N);
                    while (r - l > 1)
                    {
                        var m = l + (r - l) / 2;
                        if (depths[m] * T > depths[c] * R) r = m;
                        else l = m;
                    }
                    answer += N - r;
                    if (r <= c) answer--;
                }
            }

            Console.WriteLine(answer);
        }

        public readonly struct Edge
        {
            public readonly int Idx;
            public readonly long Cost;
            public Edge(int v, long cost) => (Idx, Cost) = (v, cost);
        }

        public class PriorityQueue<T> : IReadOnlyCollection<T>
        {
            private readonly List<T> _heap;
            private readonly Comparison<T> _comparison;
            public int Count => _heap.Count;
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
            public IEnumerator<T> GetEnumerator() => _heap.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
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
