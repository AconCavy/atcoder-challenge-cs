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
            var uf = new UnionFind(N);
            for (var i = 0; i < M; i++)
            {
                var (A, B) = Scanner.Scan<int, int>();
                A--;
                B--;
                uf.Union(A, B);
            }

            var answer = 0L;
            for (var i = 0; i < N; i++)
            {
                answer = Math.Max(answer, uf.Size(i));
            }

            Console.WriteLine(answer);
        }

        public class UnionFind
        {
            private int[] _parents;
            private int[] _counts;

            public UnionFind(int length)
            {
                _parents = Enumerable.Range(0, length).ToArray();
                _counts = Enumerable.Repeat(1, length).ToArray();
            }

            public int Find(int x)
            {
                if (_parents[x] == x) return x;
                return _parents[x] = Find(_parents[x]);
            }

            public bool Union(int x, int y)
            {
                var rootX = Find(x);
                var rootY = Find(y);
                if (rootX == rootY) return false;

                if (_counts[rootX] < _counts[rootY])
                {
                    var tmp = rootX;
                    rootX = rootY;
                    rootY = tmp;
                }
                _counts[rootX] += _counts[rootY];
                _parents[rootY] = rootX;
                return true;
            }

            public int Size(int x)
            {
                return _counts[Find(x)];
            }

            public bool IsSame(int x, int y)
            {
                return Find(x) == Find(y);
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
