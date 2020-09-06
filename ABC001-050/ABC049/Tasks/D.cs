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
            var NKL = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, K, L) = (NKL[0], NKL[1], NKL[2]);
            var uf1 = new UnionFind(N);
            for (var i = 0; i < K; i++)
            {
                var pq = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                uf1.Union(pq[0] - 1, pq[1] - 1);
            }
            var uf2 = new UnionFind(N);
            for (var i = 0; i < L; i++)
            {
                var rs = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                uf2.Union(rs[0] - 1, rs[1] - 1);
            }

            var dict = new Dictionary<(int, int), int>();
            for (var i = 0; i < N; i++)
            {
                var p1 = uf1.Find(i);
                var p2 = uf2.Find(i);
                if (!dict.ContainsKey((p1, p2))) dict[(p1, p2)] = 0;
                dict[(p1, p2)]++;
            }

            var answer = new int[N];
            for (var i = 0; i < N; i++)
            {
                var p1 = uf1.Find(i);
                var p2 = uf2.Find(i);
                answer[i] = dict[(p1, p2)];
            }

            Console.WriteLine(string.Join(" ", answer));
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
    }
}
