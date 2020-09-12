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
            var (N, M, K) = Scanner.Scan<int, int, int>();
            var friends = new List<int>[N].Select(x => new List<int>()).ToArray();
            var blocks = new List<int>[N].Select(x => new List<int>()).ToArray();
            var dsu = new DSU(N);
            for (var i = 0; i < M; i++)
            {
                var (A, B) = Scanner.Scan<int, int>();
                dsu.Merge(--A, --B);
                friends[A].Add(B);
                friends[B].Add(A);
            }

            for (var i = 0; i < K; i++)
            {
                var (C, D) = Scanner.Scan<int, int>();
                blocks[--C].Add(--D);
                blocks[D].Add(C);
            }

            var answer = new int[N];
            for (var i = 0; i < N; i++)
            {
                answer[i] = dsu.SizeOf(i) - friends[i].Count - 1;
                foreach (var block in blocks[i])
                    if (dsu.IsSame(i, block)) answer[i]--;
            }
            Console.WriteLine(string.Join(" ", answer));
        }

        public class DSU
        {
            private readonly int _n;
            private readonly int[] _parentOrSize;

            public DSU(int n = 0)
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

            public IEnumerable<IEnumerable<int>> Groups()
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
