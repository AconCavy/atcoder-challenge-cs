using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

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
            var (N, Q) = Scanner.Scan<int, int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var ft = new FenwickTree(N);
            for (var i = 0; i < N; i++)
            {
                ft.Add(i, A[i]);
            }

            for (var i = 0; i < Q; i++)
            {
                var (t, p, x) = Scanner.Scan<int, int, int>();
                if (t == 0) ft.Add(p, x);
                else Console.WriteLine(ft.Sum(p, x));
            }
        }

        public class FenwickTree
        {
            private readonly int _n;
            private readonly long[] _data;

            public FenwickTree(int n = 0)
            {
                _n = n;
                _data = new long[n];
            }

            public void Add(int p, long x)
            {
                if (p < 0 || _n <= p) throw new IndexOutOfRangeException(nameof(p));
                p++;
                while (p <= _n)
                {
                    _data[p - 1] += x;
                    p += p & -p;
                }
            }

            public long Sum(int l, int r)
            {
                if (l < 0 || r < l || _n < r) throw new IndexOutOfRangeException();
                return Sum(r) - Sum(l);
            }

            private long Sum(int r)
            {
                var s = 0L;
                while (r > 0)
                {
                    s += _data[r - 1];
                    r -= r & -r;
                }

                return s;
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
