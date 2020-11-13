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
            var (N, M) = Scanner.Scan<int, int>();
            var X = new (int a, int b)[N];
            for (var i = 0; i < N; i++)
            {
                var (A, B) = Scanner.Scan<int, int>();
                X[i] = (A, B);
            }
            Array.Sort(X, (x, y) => x.a.CompareTo(y.a));
            var queue = new PriorityQueue<(int a, int b)>(Comparer<(int a, int b)>.Create((x, y) => y.b.CompareTo(x.b)));
            var index = 0;
            var answer = 0L;
            for (var i = 0; i < M; i++)
            {
                while (index < N && X[index].a <= i + 1) queue.Enqueue(X[index++]);
                if (!queue.Any()) continue;
                answer += queue.Dequeue().b;
            }
            Console.WriteLine(answer);
        }

        public class PriorityQueue<T> : IReadOnlyCollection<T>
        {
            private readonly List<T> _heap;
            private readonly IComparer<T> _comparer;
            public int Count => _heap.Count;
            public PriorityQueue() : this(null, null)
            {
            }
            public PriorityQueue(IComparer<T> comparer = null)
                : this(null, comparer)
            {
            }
            public PriorityQueue(IEnumerable<T> items = null, IComparer<T> comparer = null)
            {
                _heap = new List<T>();
                _comparer = comparer ?? Comparer<T>.Default;
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
                    if (_comparer.Compare(_heap[parent], _heap[child]) <= 0) break;
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
                    if (right < Count && _comparer.Compare(_heap[left], _heap[right]) > 0)
                        left = right;
                    if (_comparer.Compare(_heap[parent], _heap[left]) <= 0) break;
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
