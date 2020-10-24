using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var B = Scanner.ScanEnumerable<long>().ToArray();
            // if (A.Sum() != B.Sum()) { Console.WriteLine("No"); return; }
            var answer = true;
            var dsu = new DisjointSetUnion(N);
            for (var i = 0; i < M; i++)
            {
                var (c, d) = Scanner.Scan<int, int>();
                dsu.Merge(c - 1, d - 1);
            }

            foreach (var group in dsu.GetGroups())
            {
                var sumA = 0L;
                var sumB = 0L;
                foreach (var u in group)
                {
                    sumA += A[u];
                    sumB += B[u];
                }
                if (sumA != sumB) answer = false;
                if (!answer) break;
            }

            Console.WriteLine(answer ? "Yes" : "No");
        }

        public class DisjointSetUnion
        {
            private readonly int _length;
            private readonly int[] _parentOrSize;
            public DisjointSetUnion(int length = 0)
            {
                if (length < 0) throw new ArgumentException(nameof(length));
                _length = length;
                _parentOrSize = new int[_length];
                Array.Fill(_parentOrSize, -1);
            }
            public int Merge(int a, int b)
            {
                if (a < 0 || _length <= a) throw new IndexOutOfRangeException(nameof(a));
                if (b < 0 || _length <= b) throw new IndexOutOfRangeException(nameof(b));
                var (x, y) = (LeaderOf(a), LeaderOf(b));
                if (x == y) return x;
                if (-_parentOrSize[x] < -_parentOrSize[y]) (x, y) = (y, x);
                _parentOrSize[x] += _parentOrSize[y];
                _parentOrSize[y] = x;
                return x;
            }
            public bool IsSame(int a, int b)
            {
                if (a < 0 || _length <= a) throw new IndexOutOfRangeException(nameof(a));
                if (b < 0 || _length <= b) throw new IndexOutOfRangeException(nameof(b));
                return LeaderOf(a) == LeaderOf(b);
            }
            public int LeaderOf(int a)
            {
                if (a < 0 || _length <= a) throw new IndexOutOfRangeException(nameof(a));
                if (_parentOrSize[a] < 0) return a;
                return _parentOrSize[a] = LeaderOf(_parentOrSize[a]);
            }
            public int SizeOf(int a)
            {
                if (a < 0 || _length <= a) throw new IndexOutOfRangeException(nameof(a));
                return -_parentOrSize[LeaderOf(a)];
            }
            public IEnumerable<IEnumerable<int>> GetGroups()
            {
                var leaders = new int[_length];
                var groupSize = new int[_length];
                for (var i = 0; i < _length; i++)
                {
                    leaders[i] = LeaderOf(i);
                    groupSize[leaders[i]]++;
                }
                var ret = new List<int>[_length].Select(x => new List<int>()).ToArray();
                for (var i = 0; i < _length; i++) ret[leaders[i]].Add(i);
                return ret.Where(x => x.Any());
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
    }
}
