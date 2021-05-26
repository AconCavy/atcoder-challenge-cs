using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class M
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
                var (u, v) = Scanner.Scan<int, int>();
                u--; v--;
                G[u].Add(v);
                G[v].Add(u);
            }

            var S = Scanner.Scan<int>() - 1;
            var K = Scanner.Scan<int>();
            var T = Scanner.ScanEnumerable<int>().Select(x => x - 1).ToList();
            T.Insert(0, S);
            K++;

            const long inf = (long)1e18;

            long[] GetCosts(int from)
            {
                var costs = new long[N];
                Array.Fill(costs, inf);
                costs[from] = 0;
                var queue = new PriorityQueue<(int U, long Cost)>((x, y) => x.Cost.CompareTo(y.Cost));
                queue.Enqueue((from, 0));
                while (queue.Any())
                {
                    var (u, cc) = queue.Dequeue();
                    if (costs[u] < cc) continue;
                    foreach (var v in G[u])
                    {
                        var nc = costs[u] + 1;
                        if (costs[v] <= nc) continue;
                        costs[v] = nc;
                        queue.Enqueue((v, nc));
                    }
                }

                return costs;
            }

            var WG = new long[K, K];

            for (var i = 0; i < K; i++)
            {
                var costs = GetCosts(T[i]);
                for (var j = i + 1; j < K; j++)
                {
                    WG[i, j] = WG[j, i] = costs[T[j]];
                }
            }

            var dp = new long[1 << K, K];
            for (var i = 0; i < 1 << K; i++)
            {
                for (var j = 0; j < K; j++)
                {
                    dp[i, j] = inf;
                }
            }

            dp[1, 0] = 0;
            for (var s = 1; s < 1 << K; s++)
            {
                for (var v = 0; v < K; v++)
                {
                    for (var u = 0; u < K; u++)
                    {
                        if (u == v || (s >> u & 1) == 0) continue;
                        dp[s | (1 << v), v] = Math.Min(dp[s | (1 << v), v], dp[s, u] + WG[u, v]);
                    }
                }
            }

            var answer = inf;
            var all = (1 << K) - 1;
            for (var i = 1; i < K; i++)
            {
                answer = Math.Min(answer, dp[all, i]);
            }

            Console.WriteLine(answer);
        }

        public class DisjointSetUnion
        {
            private readonly int _length;
            private readonly int[] _parentOrSize;
            public DisjointSetUnion(int length = 0)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                _length = length;
                _parentOrSize = new int[_length];
                Array.Fill(_parentOrSize, -1);
            }
            public int Merge(int u, int v)
            {
                if (u < 0 || _length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                var (x, y) = (LeaderOf(u), LeaderOf(v));
                if (x == y) return x;
                if (-_parentOrSize[x] < -_parentOrSize[y]) (x, y) = (y, x);
                _parentOrSize[x] += _parentOrSize[y];
                _parentOrSize[y] = x;
                return x;
            }
            public bool IsSame(int u, int v)
            {
                if (u < 0 || _length <= u) throw new ArgumentOutOfRangeException(nameof(u));
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                return LeaderOf(u) == LeaderOf(v);
            }
            public int LeaderOf(int v)
            {
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                if (_parentOrSize[v] < 0) return v;
                return _parentOrSize[v] = LeaderOf(_parentOrSize[v]);
            }
            public int SizeOf(int v)
            {
                if (v < 0 || _length <= v) throw new ArgumentOutOfRangeException(nameof(v));
                return -_parentOrSize[LeaderOf(v)];
            }
            public IEnumerable<IEnumerable<int>> GetGroups()
            {
                var ret = new List<int>[_length].Select(x => new List<int>()).ToArray();
                for (var i = 0; i < _length; i++) ret[LeaderOf(i)].Add(i);
                return ret.Where(x => x.Any());
            }
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
