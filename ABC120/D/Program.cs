using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public class Program
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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var briges = new Brige[nm[1]];
            var answers = new long[nm[1]];
            answers[answers.Length - 1] = ((long)nm[0] * ((long)nm[0] - 1)) / 2;
            for (var i = 0; i < briges.Length; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                briges[i] = new Brige { A = ab[0] - 1, B = ab[1] - 1 };
            }

            var unionFind = new UnionFind(nm[0]);
            for (var i = answers.Length - 1; i >= 1; i--)
            {
                var a = briges[i].A;
                var b = briges[i].B;
                if (unionFind.IsSame(a, b))
                {
                    answers[i - 1] = answers[i];
                }
                else
                {
                    answers[i - 1] = answers[i] - (long)unionFind.Size(a) * (long)unionFind.Size(b);
                    unionFind.Union(a, b);
                }
            }
            foreach (var count in answers)
            {
                Console.WriteLine(count);
            }

        }

        public struct Brige
        {
            public int A;
            public int B;
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
