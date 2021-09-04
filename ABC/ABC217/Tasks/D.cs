using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
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
            var (L, Q) = Scanner.Scan<int, int>();
            var set = new Set<int> { 0, L };

            for (var i = 0; i < Q; i++)
            {
                var (c, x) = Scanner.Scan<int, int>();
                if (c == 1)
                {
                    set.Add(x);
                }
                else
                {
                    var lb = set.LowerBound(x);
                    var answer = set.ElementAt(lb) - set.ElementAt(lb - 1);
                    Console.WriteLine(answer);
                }
            }
        }

        public class Set<T> : IEnumerable<T>
        {
            private readonly RandomizedBinarySearchTree<T> _tree;
            private readonly bool _allowDuplication;
            public Set(bool allowDuplication = false)
                : this(null, comparer: null, allowDuplication)
            {
            }
            public Set(IEnumerable<T> source, bool allowDuplication = false)
                : this(source, comparer: null, allowDuplication)
            {
            }
            public Set(IEnumerable<T> source, Comparer<T> comparer, bool allowDuplication = false)
                : this(source, (comparer ?? Comparer<T>.Default).Compare, allowDuplication)
            {
            }
            public Set(IEnumerable<T> source, Comparison<T> comparison, bool allowDuplication = false)
            {
                _tree = new RandomizedBinarySearchTree<T>(comparison);
                _allowDuplication = allowDuplication;
                if (source is null) return;
                foreach (var value in source) Add(value);
            }
            public void Add(T value)
            {
                if (_allowDuplication || !_tree.Contains(value)) _tree.Insert(value);
            }
            public void Remove(T value)
            {
                _tree.Erase(value);
            }
            public bool Contains(T value)
            {
                return _tree.Contains(value);
            }
            public T ElementAt(int index)
            {
                return _tree.ElementAt(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
            }
            public int Count(T value)
            {
                return _tree.UpperBound(value) - _tree.LowerBound(value);
            }
            public int LowerBound(T value)
            {
                return _tree.LowerBound(value);
            }
            public int UpperBound(T value)
            {
                return _tree.UpperBound(value);
            }
            public IEnumerator<T> GetEnumerator() => _tree.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class RandomizedBinarySearchTree<T> : IEnumerable<T>
        {
            private readonly Comparison<T> _comparison;
            private readonly Compare _lowerBound;
            private readonly Compare _upperBound;
            private readonly Random _random;
            private Node _root;
            public RandomizedBinarySearchTree(int seed = 0) : this(comparer: null, seed) { }
            public RandomizedBinarySearchTree(Comparer<T> comparer, int seed = 0) : this(
                (comparer ?? Comparer<T>.Default).Compare, seed)
            {
            }
            public RandomizedBinarySearchTree(Comparison<T> comparison, int seed = 0)
            {
                _comparison = comparison;
                _lowerBound = (x, y) => _comparison(x, y) >= 0;
                _upperBound = (x, y) => _comparison(x, y) > 0;
                _random = new Random(seed);
            }
            public delegate bool Compare(T x, T y);
            public void Insert(T value)
            {
                if (_root is null) _root = new Node(value);
                else InsertAt(LowerBound(value), value);
            }
            public void InsertAt(int index, T value)
            {
                var (l, r) = Split(_root, index);
                _root = Merge(Merge(l, new Node(value)), r);
            }
            public void Erase(T value)
            {
                EraseAt(LowerBound(value));
            }
            public void EraseAt(int index)
            {
                var (l, r1) = Split(_root, index);
                var (_, r2) = Split(r1, 1);
                _root = Merge(l, r2);
            }
            public T ElementAt(int index)
            {
                if (index < 0 || Count(_root) <= index) throw new ArgumentNullException(nameof(index));
                var node = _root;
                var idx = Count(node) - Count(node.R) - 1;
                while (node is { })
                {
                    if (idx == index) return node.Value;
                    if (idx > index)
                    {
                        node = node.L;
                        idx -= Count(node?.R) + 1;
                    }
                    else
                    {
                        node = node.R;
                        idx += Count(node?.L) + 1;
                    }
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            public bool Contains(T value)
            {
                return Find(value) is { };
            }
            public IEnumerator<T> GetEnumerator() => Enumerate(_root).GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public int UpperBound(T value) => CommonBound(value, _upperBound);
            public int LowerBound(T value) => CommonBound(value, _lowerBound);
            public int CommonBound(T value, Compare compare)
            {
                var node = _root;
                if (node is null) return -1;
                var bound = Count(node);
                var idx = bound - Count(node.R) - 1;
                while (node is { })
                {
                    if (compare(node.Value, value))
                    {
                        node = node.L;
                        bound = Math.Min(bound, idx);
                        idx -= Count(node?.R) + 1;
                    }
                    else
                    {
                        node = node.R;
                        idx += Count(node?.L) + 1;
                    }
                }
                return bound;
            }
            private double GetProbability() => _random.NextDouble();
            private Node Merge(Node l, Node r)
            {
                if (l is null || r is null) return l ?? r;
                var (n, m) = (Count(l), Count(r));
                if ((double)n / (n + m) > GetProbability())
                {
                    l.R = Merge(l.R, r);
                    return l;
                }
                else
                {
                    r.L = Merge(l, r.L);
                    return r;
                }
            }
            private (Node, Node) Split(Node node, int k)
            {
                if (node is null) return (null, null);
                if (k <= Count(node.L))
                {
                    var (l, r) = Split(node.L, k);
                    node.L = r;
                    return (l, node);
                }
                else
                {
                    var (l, r) = Split(node.R, k - Count(node.L) - 1);
                    node.R = l;
                    return (node, r);
                }
            }
            private Node Find(T value)
            {
                var node = _root;
                while (node is { })
                {
                    var cmp = _comparison(node.Value, value);
                    if (cmp > 0) node = node.L;
                    else if (cmp < 0) node = node.R;
                    else break;
                }
                return node;
            }
            private static int Count(Node node) => node?.Count ?? 0;
            private static IEnumerable<T> Enumerate(Node node = null)
            {
                if (node is null) yield break;
                foreach (var value in Enumerate(node.L)) yield return value;
                yield return node.Value;
                foreach (var value in Enumerate(node.R)) yield return value;
            }
            private class Node
            {
                public T Value { get; }
                public Node L
                {
                    get => _l;
                    set
                    {
                        _l = value;
                        UpdateCount();
                    }
                }
                public Node R
                {
                    get => _r;
                    set
                    {
                        _r = value;
                        UpdateCount();
                    }
                }
                public int Count { get; private set; }
                private Node _l;
                private Node _r;
                public Node(T value)
                {
                    Value = value;
                    Count = 1;
                }
                private void UpdateCount()
                {
                    Count = (L?.Count ?? 0) + (R?.Count ?? 0) + 1;
                }
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
