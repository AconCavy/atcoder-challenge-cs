using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var (N, M, S) = Scanner.Scan<int, int, int>();
            const int max = 50;
            var nMax = N * max;
            var state = N * (nMax + 1);

            int GetID(int u, int c) => u * (nMax + 1) + c;

            var G = new List<(int, long)>[state].Select(x => new List<(int, long)>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (u, v, a, b) = Scanner.Scan<int, int, int, long>();
                u--; v--;
                for (var j = a; j <= nMax; j++)
                {
                    G[GetID(u, j)].Add((GetID(v, j - a), b));
                    G[GetID(v, j)].Add((GetID(u, j - a), b));
                }
            }

            for (var i = 0; i < N; i++)
            {
                var (c, d) = Scanner.Scan<int, long>();
                for (var j = 0; j <= nMax; j++)
                {
                    G[GetID(i, j)].Add((GetID(i, Math.Min(j + c, nMax)), d));
                }
            }

            const long inf = (long)1e18;
            var times = new long[state];
            Array.Fill(times, inf);
            S = Math.Min(S, N * max);
            times[S] = 0;
            var queue = new PriorityQueue<(int U, long Cost)>((x, y) => x.Cost.CompareTo(y.Cost));
            queue.Enqueue((S, 0));
            while (queue.Count > 0)
            {
                var (u, cu) = queue.Dequeue();
                if (times[u] < cu) continue;
                foreach (var (v, cv) in G[u])
                {
                    var c = times[u] + cv;
                    if (times[v] <= c) continue;
                    times[v] = c;
                    queue.Enqueue((v, c));
                }
            }

            for (var i = 1; i < N; i++)
            {
                var answer = inf;
                for (var j = 0; j <= nMax; j++)
                {
                    answer = Math.Min(answer, times[GetID(i, j)]);
                }

                Console.WriteLine(answer);
            }
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
            public static T Scan<T>() where T : IConvertible => Convert<T>(ScanLine()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanLine().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
            private static string[] ScanLine() => Console.ReadLine()?.Trim().Split(' ') ?? Array.Empty<string>();
        }
    }
}
