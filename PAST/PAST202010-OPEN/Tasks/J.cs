using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class J
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
            var X = Scanner.ScanEnumerable<long>().ToArray();
            var S = Scanner.Scan<string>().Select(x => x - 'A').ToArray();
            var G = new List<(int, long)>[N].Select(x => new List<(int, long)>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (a, b, c) = Scanner.Scan<int, int, long>();
                a--; b--;
                G[a].Add((b, c));
                G[b].Add((a, c));
            }

            const long inf = (long)1e18;

            long GetWarpCost(int u, int v)
            {
                if (u == v) return 0;
                var (a, b) = (S[u], S[v]);
                if (a > b) (a, b) = (b, a);
                return (a, b) switch
                {
                    (0, 1) => X[0],
                    (0, 2) => X[1],
                    (1, 2) => X[2],
                    _ => inf
                };
            }

            var group = new List<int>[3].Select(_ => new List<int>()).ToArray();
            for (var i = 0; i < N; i++)
            {
                group[S[i]].Add(i);
            }

            var cost = new long[N];
            var queue = new PriorityQueue<(int U, long Cost)>((x, y) => x.Cost.CompareTo(y.Cost));
            var used = new bool[3, 3];

            for (var v = 0; v < N; v++)
            {
                cost[v] = GetWarpCost(0, v);
                queue.Enqueue((v, cost[v]));
                used[S[0], S[v]] = true;
            }

            while (queue.Count > 0)
            {
                var (u, cu) = queue.Dequeue();
                if (cost[u] < cu) continue;
                for (var x = 0; x < 3; x++)
                {
                    if (used[S[u], x] || S[u] == x) continue;
                    used[S[u], x] = true;
                    var y = 3 - S[u] - x;
                    foreach (var v in group[y])
                    {
                        var c = cost[u] + GetWarpCost(u, v);
                        if (cost[v] <= c) continue;
                        cost[v] = c;
                        queue.Enqueue((v, c));
                    }
                }

                foreach (var (v, cv) in G[u])
                {
                    var c = cost[u] + Math.Min(GetWarpCost(u, v), cv);
                    if (cost[v] <= c) continue;
                    cost[v] = c;
                    queue.Enqueue((v, c));
                }
            }

            var answer = cost[N - 1];
            Console.WriteLine(answer);
        }

        public class PriorityQueue<T> : IReadOnlyCollection<T>
        {
            private readonly Comparison<T> _comparison;
            private readonly List<T> _heap;
            public PriorityQueue(IComparer<T> comparer) : this(null, comparer) { }
            public PriorityQueue(Comparison<T> comparison) : this(null, comparison) { }
            public PriorityQueue(IEnumerable<T> items = null, IComparer<T> comparer = null)
                : this(items, (comparer ?? Comparer<T>.Default).Compare) { }
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
