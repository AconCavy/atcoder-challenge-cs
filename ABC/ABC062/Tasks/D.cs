using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var lq = new PriorityQueue<long>();
            var rq = new PriorityQueue<long>((x, y) => y.CompareTo(x));
            var (ls, rs) = (0L, 0L);
            foreach (var a in A.Take(N))
            {
                ls += a;
                lq.Enqueue(a);
            }
            foreach (var a in A.TakeLast(N))
            {
                rs += a;
                rq.Enqueue(a);
            }
            var L = new long[N * 3];
            var R = new long[N * 3];
            L[N] = ls;
            R[N * 2] = rs;
            for (var i = N; i < N * 2; i++)
            {
                lq.Enqueue(A[i]);
                ls += A[i] - lq.Dequeue();
                L[i + 1] = ls;
            }

            for (var i = N * 2 - 1; i >= N; i--)
            {
                rq.Enqueue(A[i]);
                rs += A[i] - rq.Dequeue();
                R[i] = rs;
            }
            var answer = long.MinValue;
            for (var i = N; i <= N * 2; i++) answer = Math.Max(answer, L[i] - R[i]);

            Console.WriteLine(answer);
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
