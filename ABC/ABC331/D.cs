using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class D
{
    public static void Main()
    {
        using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
        Console.SetOut(sw);
        Solve();
        Console.Out.Flush();
    }

    public static void Solve()
    {
        var (N, Q) = Scanner.Scan<int, int>();
        var G = new char[N][];
        for (var i = 0; i < N; i++)
        {
            G[i] = Scanner.Scan<string>().ToCharArray();
        }

        var cum = new CumulativeSum2D<long>(N + 10, N + 10);
        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < N; j++)
            {
                if (G[i][j] == 'B')
                {
                    cum.Add(i, j, 1);
                }
            }
        }

        while (Q-- > 0)
        {
            var (a, b, c, d) = Scanner.Scan<int, int, int, int>();
            c++; d++;

            long answer = 0;
            var (am, bm, cm, dm) = (a % N, b % N, c % N, d % N);
            long hc = ((c - a) - (N - am + cm)) / N;
            long wc = ((d - b) - (N - bm + dm)) / N;
            // Console.WriteLine($"{hc} {wc}");

            answer += cum.Sum(am, bm, N, N); // 左上
            answer += cum.Sum(0, bm, cm, N); // 左下
            answer += cum.Sum(am, 0, N, dm); // 右上;
            answer += cum.Sum(0, 0, cm, dm); // 右下;

            answer += cum.Sum(0, bm, N, N) * hc; // 左中
            answer += cum.Sum(am, 0, N, N) * wc; // 上中
            answer += cum.Sum(0, 0, N, dm) * hc; // 右中
            answer += cum.Sum(0, 0, cm, N) * wc; // 下中

            answer += cum.Sum(N, N) * (hc * wc); // 中中

            Console.WriteLine(answer);
        }
    }

    public class CumulativeSum2D<T> where T : INumber<T>
    {
        public int Height { get; }
        public int Width { get; }
        private readonly T[] _data;
        private readonly T[] _sum;
        private bool _isUpdated;
        public CumulativeSum2D(int height, int width)
        {
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            Height = height;
            Width = width;
            _data = new T[height * width];
            _sum = new T[(height + 1) * (width + 1)];
        }
        public void Add(int height, int width, T value)
        {
            ThrowIfNegative(height);
            ThrowIfGreaterThanOrEqual(height, Height);
            ThrowIfNegative(width);
            ThrowIfGreaterThanOrEqual(width, Width);
            _isUpdated = false;
            _data[height * Width + width] += value;
        }
        public void Set(int height, int width, T value)
        {
            ThrowIfNegative(height);
            ThrowIfGreaterThanOrEqual(height, Height);
            ThrowIfNegative(width);
            ThrowIfGreaterThanOrEqual(width, Width);
            _isUpdated = false;
            _data[height * Width + width] = value;
        }
        public T Get(int height, int width)
        {
            ThrowIfNegative(height);
            ThrowIfGreaterThanOrEqual(height, Height);
            ThrowIfNegative(width);
            ThrowIfGreaterThanOrEqual(width, Width);
            return _data[height * Width + width];
        }
        /// <summary>
        /// Calculate a two-dimensional cumulative sum of [0, height), [0, width).
        /// </summary>
        public T Sum(int height, int width)
        {
            ThrowIfNegative(height);
            ThrowIfGreaterThan(height, Height);
            ThrowIfNegative(width);
            ThrowIfGreaterThan(width, Width);
            if (!_isUpdated) Build();
            return _sum[height * (Width + 1) + width];
        }
        /// <summary>
        /// Calculate a two-dimensional cumulative sum of [height1, height2), [width1, width2).
        /// </summary>
        public T Sum(int height1, int width1, int height2, int width2)
        {
            ThrowIfGreaterThan(height1, height2);
            ThrowIfGreaterThan(width1, width2);
            return Sum(height1, width1) + Sum(height2, width2) - Sum(height2, width1) - Sum(height1, width2);
        }
        private void Build()
        {
            _isUpdated = true;
            var w1 = Width + 1;
            _sum[0] = _sum[w1] = _sum[1] = T.Zero;
            for (var i = 1; i <= Height; i++)
                for (var j = 1; j <= Width; j++)
                    _sum[i * w1 + j] =
                        _sum[i * w1 + (j - 1)]
                        + _sum[(i - 1) * w1 + j]
                        - _sum[(i - 1) * w1 + (j - 1)]
                        + _data[(i - 1) * Width + (j - 1)];
        }
        private static void ThrowIfNegative(int value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
        }
        private static void ThrowIfGreaterThan(int value, int other)
        {
            if (value > other) throw new ArgumentOutOfRangeException(nameof(value));
        }
        private static void ThrowIfGreaterThanOrEqual(int value, int other)
        {
            if (value >= other) throw new ArgumentOutOfRangeException(nameof(value));
        }
    }

    public static class Scanner
    {
        public static T Scan<T>() where T : IConvertible => Convert<T>(ScanStringArray()[0]);
        public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]));
        }
        public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]));
        }
        public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]));
        }
        public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]));
        }
        public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]), Convert<T6>(input[5]));
        }
        public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanStringArray().Select(Convert<T>);
        private static string[] ScanStringArray()
        {
            var line = Console.ReadLine()?.Trim() ?? string.Empty;
            return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
        }
        private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
    }
}
