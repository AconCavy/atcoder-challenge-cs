using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class H
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
            var (N, M, K) = Scanner.Scan<int, int, int>();
            var S = new int[N][];
            for (var i = 0; i < N; i++)
            {
                S[i] = Scanner.Scan<string>().Select(x => x - '0').ToArray();
            }

            var cums = new CumulativeSum2D[10];
            for (var i = 0; i < 10; i++)
            {
                cums[i] = new CumulativeSum2D(N, M);
            }

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    cums[S[i][j]].Add(i, j, 1);
                }
            }

            for (var n = Math.Min(N, M); n >= 1; n--)
            {
                for (var i = 0; i + n <= N; i++)
                {
                    for (var j = 0; j + n <= M; j++)
                    {
                        for (var l = 0; l < 10; l++)
                        {
                            var k = n * n - cums[l].Sum(i, j, i + n, j + n);
                            if (k <= K)
                            {
                                Console.WriteLine(n);
                                return;
                            }
                        }
                    }
                }
            }
        }

        public class CumulativeSum2D
        {
            private readonly long[,] _data;
            private readonly int _height;
            private readonly long[,] _sum;
            private readonly int _width;
            private bool _isUpdated;
            public CumulativeSum2D(int h, int w)
            {
                if (h <= 0) throw new ArgumentOutOfRangeException(nameof(h));
                if (w <= 0) throw new ArgumentOutOfRangeException(nameof(w));
                _height = h;
                _width = w;
                _data = new long[h, w];
                _sum = new long[h + 1, w + 1];
            }
            public void Add(int h, int w, long value)
            {
                if (h < 0 || _height <= h) throw new ArgumentOutOfRangeException(nameof(h));
                if (w < 0 || _width <= w) throw new ArgumentOutOfRangeException(nameof(w));
                _isUpdated = false;
                _data[h, w] += value;
            }
            public void Set(int h, int w, long value)
            {
                if (h < 0 || _height <= h) throw new ArgumentOutOfRangeException(nameof(h));
                if (w < 0 || _width <= w) throw new ArgumentOutOfRangeException(nameof(w));
                _isUpdated = false;
                _data[h, w] = value;
            }
            public long Get(int h, int w)
            {
                if (h < 0 || _height <= h) throw new ArgumentOutOfRangeException(nameof(h));
                if (w < 0 || _width <= w) throw new ArgumentOutOfRangeException(nameof(w));
                return _data[h, w];
            }
            public long Sum(int h, int w)
            {
                if (h < 0 || _height < h) throw new ArgumentOutOfRangeException(nameof(h));
                if (w < 0 || _width < w) throw new ArgumentOutOfRangeException(nameof(w));
                if (!_isUpdated) Build();
                return _sum[h, w];
            }
            public long Sum(int h1, int w1, int h2, int w2)
            {
                if (h1 < 0 || _height < h1) throw new ArgumentOutOfRangeException(nameof(h1));
                if (w1 < 0 || _width < w1) throw new ArgumentOutOfRangeException(nameof(w1));
                if (h2 < 0 || _height < h2) throw new ArgumentOutOfRangeException(nameof(h2));
                if (w2 < 0 || _width < w2) throw new ArgumentOutOfRangeException(nameof(w2));
                if (!_isUpdated) Build();
                return _sum[h1, w1] + _sum[h2, w2] - _sum[h2, w1] - _sum[h1, w2];
            }
            private void Build()
            {
                _isUpdated = true;
                _sum[0, 0] = _sum[1, 0] = _sum[0, 1] = 0;
                for (var i = 1; i <= _height; i++)
                    for (var j = 1; j <= _width; j++)
                        _sum[i, j] = _sum[i, j - 1] + _sum[i - 1, j] - _sum[i - 1, j - 1] + _data[i - 1, j - 1];
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
