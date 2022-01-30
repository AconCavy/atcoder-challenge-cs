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
            var (N, M) = Scanner.Scan<int, int>();
            var H = Scanner.ScanEnumerable<long>().ToArray();
            var G = new List<(int, long)>[N].Select(x => new List<(int, long)>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (u, v) = Scanner.Scan<int, int>();
                u--; v--;
                var dh = Math.Abs(H[u] - H[v]);
                if (H[u] > H[v])
                {
                    G[u].Add((v, dh));
                    G[v].Add((u, -2 * dh));
                }
                else if (H[u] < H[v])
                {
                    G[u].Add((v, -2 * dh));
                    G[v].Add((u, dh));
                }
                else
                {
                    G[u].Add((v, 0));
                    G[v].Add((u, 0));
                }
            }

            var costs = new long[N];
            Array.Fill(costs, -long.MaxValue);
            costs[0] = 0;
            var queue = new PriorityQueue<(int U, long Cost)>((x, y) => y.Cost.CompareTo(x.Cost));
            queue.Enqueue((0, 0));
            while (queue.Count > 0)
            {
                var (u, cu) = queue.Dequeue();
                if (costs[u] > cu) continue;
                foreach (var (v, cv) in G[u])
                {
                    var c = costs[u] + cv;
                    if (costs[v] >= c) continue;
                    costs[v] = c;
                    queue.Enqueue((v, c));
                }
            }

            var answer = costs.Max();
            Console.WriteLine(answer);
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

        public static class Scanner
        {
            public static string ScanLine() => Console.ReadLine()?.Trim() ?? string.Empty;
            public static string[] Scan() => ScanLine().Split(' ');
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
