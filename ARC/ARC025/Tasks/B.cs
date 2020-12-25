using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var (H, W) = Scanner.Scan<int, int>();
            var G = new int[H][].Select(_ => Scanner.ScanEnumerable<int>().ToArray()).ToArray();

            var cum2d = new CumulativeSum2D(H, W);
            for (var i = 0; i < H; i++)
                for (var j = 0; j < W; j++)
                    cum2d.Set(i, j, G[i][j] * ((i + j) % 2 == 0 ? 1 : -1));

            var answer = 0L;
            for (var h1 = 1; h1 <= H; h1++)
                for (var h2 = 0; h2 < h1; h2++)
                    for (var w1 = 1; w1 <= W; w1++)
                        for (var w2 = 0; w2 < w1; w2++)
                            if (cum2d.Sum(h1, w1, h2, w2) == 0)
                                answer = Math.Max(answer, (h1 - h2) * (w1 - w2));

            Console.WriteLine(answer);
        }

        public class CumulativeSum2D
        {
            private readonly int _height;
            private readonly int _width;
            private readonly long[,] _data;
            private readonly long[,] _sum;
            private bool _isUpdated;
            public CumulativeSum2D(int h, int w)
            {
                _height = h;
                _width = w;
                _data = new long[h, w];
                _sum = new long[h + 1, w + 1];
            }
            public void Add(int h, int w, long value)
            {
                _isUpdated = false;
                _data[h, w] += value;
            }
            public void Set(int h, int w, long value)
            {
                _isUpdated = false;
                _data[h, w] = value;
            }
            public long Get(int h, int w)
            {
                return _data[h, w];
            }
            public long Sum(int h1, int w1, int h2, int w2)
            {
                if (!_isUpdated) Build();
                return _sum[h1, w1] + _sum[h2, w2] - _sum[h2, w1] - _sum[h1, w2];
            }
            private void Build()
            {
                for (var i = 1; i <= _height; i++)
                    for (var j = 1; j <= _width; j++)
                        _sum[i, j] = _sum[i, j - 1] + _sum[i - 1, j] - _sum[i - 1, j - 1] + _data[i - 1, j - 1];
                _isUpdated = true;
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
