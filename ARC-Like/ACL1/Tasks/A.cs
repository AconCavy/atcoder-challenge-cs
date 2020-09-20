using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class A
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
            var X = new int[N];
            var Y = new int[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                X[i] = x - 1;
                Y[i] = y - 1;
            }

            var YByX = new int[N];
            for (var i = 0; i < N; i++) YByX[X[i]] = Y[i];
            var indexes = new int[N];
            for (var i = 0; i < N; i++) indexes[X[i]] = i;
            var comp = Comparer<(int y, int leader)>.Create((l, r) => Comparer<int>.Default.Compare(l.y, r.y));
            var queue = new PriorityQueue<(int y, int leader)>(comp);
            var dsu = new DisjointSetUnion(N);
            for (var i = 0; i < N; i++)
            {
                var y = YByX[i];
                var leader = i;
                while (queue.Any() && queue.Peek().y < YByX[i])
                {
                    var tmp = queue.Dequeue();
                    dsu.Merge(i, tmp.leader);
                    leader = dsu.LeaderOf(i);
                    y = Math.Min(y, tmp.y);
                }
                queue.Enqueue((y, leader));
            }

            var answer = new int[N];
            for (var i = 0; i < N; i++)
            {
                answer[indexes[i]] = dsu.SizeOf(i);
            }

            for (var k = 0; k < N; k++)
            {
                Console.WriteLine(answer[k]);
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
        public class DisjointSetUnion
        {
            private readonly int _n;
            private readonly int[] _parentOrSize;

            public DisjointSetUnion(int n = 0)
            {
                _n = n;
                _parentOrSize = Enumerable.Repeat(-1, n).ToArray();
            }

            public int Merge(int a, int b)
            {
                if (a < 0 || _n <= a) throw new IndexOutOfRangeException(nameof(a));
                if (b < 0 || _n <= b) throw new IndexOutOfRangeException(nameof(b));
                var (x, y) = (LeaderOf(a), LeaderOf(b));
                if (x == y) return x;
                if (-_parentOrSize[x] < -_parentOrSize[y]) (x, y) = (y, x);
                _parentOrSize[x] += _parentOrSize[y];
                _parentOrSize[y] = x;
                return x;
            }

            public bool IsSame(int a, int b)
            {
                if (a < 0 || _n <= a) throw new IndexOutOfRangeException(nameof(a));
                if (b < 0 || _n <= b) throw new IndexOutOfRangeException(nameof(b));
                return LeaderOf(a) == LeaderOf(b);
            }

            public int LeaderOf(int a)
            {
                if (a < 0 || _n <= a) throw new IndexOutOfRangeException(nameof(a));
                if (_parentOrSize[a] < 0) return a;
                return _parentOrSize[a] = LeaderOf(_parentOrSize[a]);
            }

            public int SizeOf(int a)
            {
                if (a < 0 || _n <= a) throw new IndexOutOfRangeException(nameof(a));
                return -_parentOrSize[LeaderOf(a)];
            }

            public IEnumerable<IEnumerable<int>> GetGroups()
            {
                var leaders = new int[_n];
                var groupSize = new int[_n];
                for (var i = 0; i < _n; i++)
                {
                    leaders[i] = LeaderOf(i);
                    groupSize[leaders[i]]++;
                }

                var ret = new List<int>[_n].Select(x => new List<int>()).ToArray();
                for (var i = 0; i < _n; i++) ret[leaders[i]].Add(i);
                return ret.Where(x => x.Any());
            }
        }

        public class PriorityQueue<T> : IEnumerable<T>
        {
            private readonly SortedDictionary<T, int> _data;

            public PriorityQueue() : this(null, null)
            {
            }

            public PriorityQueue(IComparer<T> comparer = null)
                : this(null, comparer)
            {
            }

            public PriorityQueue(int count, IComparer<T> comparer = null)
                : this(Enumerable.Repeat(default(T), count), comparer)
            {
            }

            public PriorityQueue(IEnumerable<T> data = null, IComparer<T> comparer = null)
            {
                comparer ??= Comparer<T>.Default;
                var list = data?.ToList() ?? new List<T>();
                var dict = new Dictionary<T, int>();
                foreach (var val in list)
                {
                    if (!dict.ContainsKey(val)) dict[val] = 0;
                    dict[val]++;
                }

                _data = new SortedDictionary<T, int>(dict, comparer);
            }

            public void Enqueue(T item)
            {
                if (!_data.ContainsKey(item)) _data[item] = 0;
                _data[item]++;
            }

            public T Dequeue()
            {
                if (!_data.Any()) throw new InvalidOperationException();
                var key = Peek();
                if (_data[key] > 1) _data[key]--;
                else _data.Remove(key);
                return key;
            }

            public T Peek()
            {
                if (!_data.Any()) throw new InvalidOperationException();
                using var e = _data.GetEnumerator();
                e.MoveNext();
                var (ret, _) = e.Current;
                return ret;
            }

            public bool TryDequeue(out T result)
            {
                if (_data.Any())
                {
                    result = Dequeue();
                    return true;
                }

                result = default;
                return false;
            }

            public bool TryPeek(out T result)
            {
                if (_data.Any())
                {
                    result = Peek();
                    return true;
                }

                result = default;
                return false;
            }

            public void Clear() => _data.Clear();
            public bool Contains(T item) => _data.ContainsKey(item);

            public void CopyTo(T[] array, int arrayIndex)
            {
                GetFlatData().ToList().CopyTo(array, arrayIndex);
            }

            public IEnumerator<T> GetEnumerator() => GetFlatData().GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private IEnumerable<T> GetFlatData() => _data.SelectMany(x => Enumerable.Repeat(x.Key, x.Value));
        }
    }
}