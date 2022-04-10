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
        public static void Main()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var Q = Scanner.Scan<int>();
            var deq = new Deque<(long X, long C)>();
            while (Q-- > 0)
            {
                var query = Scanner.ScanEnumerable<long>().ToArray();
                if (query[0] == 1)
                {
                    deq.PushBack((query[1], query[2]));
                }
                else
                {
                    var c = query[1];
                    long sum = 0;
                    while (c > 0)
                    {
                        var top = deq.PopFront();
                        var use = Math.Min(c, top.C);
                        c -= use;
                        sum += top.X * use;
                        if (use < top.C)
                        {
                            deq.PushFront((top.X, top.C - use));
                        }
                    }

                    Console.WriteLine(sum);
                }
            }
        }

        public class Deque<T> : IReadOnlyCollection<T>
        {
            private readonly LinkedList<T> _heap = new LinkedList<T>();
            public Deque(IEnumerable<T> source = null)
            {
                if (source is null) return;
                foreach (var value in source) PushBack(value);
            }
            public void PushFront(T value)
            {
                _heap.AddFirst(value);
            }
            public void PushBack(T value)
            {
                _heap.AddLast(value);
            }
            public T PeekFront()
            {
                if (_heap.First is null) throw new InvalidOperationException();
                return _heap.First.Value;
            }
            public T PeekBack()
            {
                if (_heap.Last is null) throw new InvalidOperationException();
                return _heap.Last.Value;
            }
            public T PopFront()
            {
                if (_heap.First is null) throw new InvalidOperationException();
                var item = _heap.First.Value;
                _heap.RemoveFirst();
                return item;
            }
            public T PopBack()
            {
                if (_heap.Last is null) throw new InvalidOperationException();
                var item = _heap.Last.Value;
                _heap.RemoveLast();
                return item;
            }
            public bool TryPeekFront(out T result)
            {
                var node = _heap.First;
                if (node is null)
                {
                    result = default;
                    return false;
                }
                result = node.Value;
                return true;
            }
            public bool TryPeekBack(out T result)
            {
                var node = _heap.Last;
                if (node is null)
                {
                    result = default;
                    return false;
                }
                result = node.Value;
                return true;
            }
            public bool TryPopFront(out T result)
            {
                var exist = TryPeekFront(out result);
                if (exist) _heap.RemoveFirst();
                return exist;
            }
            public bool TryPopBack(out T result)
            {
                var exist = TryPeekBack(out result);
                if (exist) _heap.RemoveLast();
                return exist;
            }
            public void Clear()
            {
                _heap.Clear();
            }
            public bool Contains(T value)
            {
                return _heap.Contains(value);
            }
            public IEnumerator<T> GetEnumerator() => _heap.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public int Count => _heap.Count;
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
