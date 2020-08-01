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
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, M) = (NM[0], NM[1]);
            var paths = new (int A, int B, int Y)[M].ToArray();
            for (var i = 0; i < M; i++)
            {
                var aby = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                paths[i] = (aby[0] - 1, aby[1] - 1, aby[2]);
            }
            paths = paths.OrderByDescending(x => x.Y).ToArray();

            var Q = int.Parse(Console.ReadLine());
            var people = new (int I, int V, int W)[Q];
            for (var i = 0; i < Q; i++)
            {
                var vw = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                people[i] = (i, vw[0] - 1, vw[1]);
            }
            people = people.OrderByDescending(x => x.W).ToArray();

            var answers = new int[Q];
            var uf = new UnionFind(N);
            var j = 0;
            for (var i = 0; i < Q; i++)
            {
                var person = people[i];
                var year = person.W;
                while (j < M && paths[j].Y > year)
                {
                    uf.Union(paths[j].A, paths[j].B);
                    j++;
                }
                answers[person.I] = uf.Size(person.V);
            }

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
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
