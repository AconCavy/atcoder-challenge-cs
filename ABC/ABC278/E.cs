using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var (H, W, N, h, w) = Scanner.Scan<int, int, int, int, int>();
            var A = new int[H][];
            for (var i = 0; i < H; i++)
            {
                A[i] = Scanner.ScanEnumerable<int>().ToArray();
            }

            var set = new HashSet<int>();
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    set.Add(A[i][j]);
                }
            }

            var (map, _) = Compress(set);
            var K = map.Count;
            var cum = new CumulativeSum2D[K].Select(_ => new CumulativeSum2D(H, W)).ToArray();
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    var a = A[i][j];
                    var ma = map[a];
                    cum[ma].Add(i, j, 1);
                }
            }

            var answer = new int[H - h + 1].Select(_ => new int[W - w + 1]).ToArray();

            for (var i = 0; i < H - h + 1; i++)
            {
                for (var j = 0; j < W - w + 1; j++)
                {
                    var sum = 0;
                    for (var k = 0; k < K; k++)
                    {
                        var all = cum[k].Sum(H, W);
                        var blak = cum[k].Sum(i, j, i + h, j + w);
                        if (all - blak > 0) sum++;
                    }

                    answer[i][j] = sum;
                }
            }

            Printer.Print2D(answer, " ");
        }

        public static class Printer
        {
            public static void Print<T>(T source) => Console.WriteLine(source);
            public static void Print1D<T>(IEnumerable<T> source, string separator = "") => Console.WriteLine(string.Join(separator, source));
            public static void Print1D<T, U>(IEnumerable<T> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(separator, source.Select(selector)));
            public static void Print2D<T>(IEnumerable<IEnumerable<T>> source, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x))));
            public static void Print2D<T, U>(IEnumerable<IEnumerable<T>> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x.Select(selector)))));
            public static void Print2D<T>(T[,] source, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                {
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(source[i, j]);
                        Console.Write(j == w - 1 ? Environment.NewLine : separator);
                    }
                }
            }
            public static void Print2D<T, U>(T[,] source, Func<T, U> selector, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                {
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(selector(source[i, j]));
                        Console.Write(j == w - 1 ? Environment.NewLine : separator);
                    }
                }
            }
        }

        public class CumulativeSum2D
        {
            public int Height { get; }
            public int Width { get; }
            private readonly long[] _data;
            private readonly long[] _sum;
            private bool _isUpdated;
            public CumulativeSum2D(int height, int width)
            {
                if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
                if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
                Height = height;
                Width = width;
                _data = new long[height * width];
                _sum = new long[(height + 1) * (width + 1)];
            }
            public void Add(int height, int width, long value)
            {
                if (height < 0 || Height <= height) throw new ArgumentOutOfRangeException(nameof(height));
                if (width < 0 || Width <= width) throw new ArgumentOutOfRangeException(nameof(width));
                _isUpdated = false;
                _data[height * Width + width] += value;
            }
            public void Set(int height, int width, long value)
            {
                if (height < 0 || Height <= height) throw new ArgumentOutOfRangeException(nameof(height));
                if (width < 0 || Width <= width) throw new ArgumentOutOfRangeException(nameof(width));
                _isUpdated = false;
                _data[height * Width + width] = value;
            }
            public long Get(int height, int width)
            {
                if (height < 0 || Height <= height) throw new ArgumentOutOfRangeException(nameof(height));
                if (width < 0 || Width <= width) throw new ArgumentOutOfRangeException(nameof(width));
                return _data[height * Width + width];
            }
            public long Sum(int height, int width)
            {
                if (height < 0 || Height < height) throw new ArgumentOutOfRangeException(nameof(height));
                if (width < 0 || Width < width) throw new ArgumentOutOfRangeException(nameof(width));
                if (!_isUpdated) Build();
                return _sum[height * (Width + 1) + width];
            }
            public long Sum(int height1, int width1, int height2, int width2)
            {
                if (height1 < 0 || Height < height1) throw new ArgumentOutOfRangeException(nameof(height1));
                if (width1 < 0 || Width < width1) throw new ArgumentOutOfRangeException(nameof(width1));
                if (height2 < 0 || Height < height2) throw new ArgumentOutOfRangeException(nameof(height2));
                if (width2 < 0 || Width < width2) throw new ArgumentOutOfRangeException(nameof(width2));
                if (!_isUpdated) Build();
                var w1 = Width + 1;
                return _sum[height1 * w1 + width1]
                       + _sum[height2 * w1 + width2]
                       - _sum[height2 * w1 + width1]
                       - _sum[height1 * w1 + width2];
            }
            private void Build()
            {
                _isUpdated = true;
                var w1 = Width + 1;
                _sum[0] = _sum[w1] = _sum[1] = 0;
                for (var i = 1; i <= Height; i++)
                    for (var j = 1; j <= Width; j++)
                        _sum[i * w1 + j] =
                            _sum[i * w1 + (j - 1)]
                            + _sum[(i - 1) * w1 + j]
                            - _sum[(i - 1) * w1 + (j - 1)]
                            + _data[(i - 1) * Width + (j - 1)];
            }
        }

        public static (Dictionary<T, int> Map, Dictionary<int, T> ReMap) Compress<T>(IEnumerable<T> source)
        {
            var distinct = source.Distinct().ToArray();
            Array.Sort(distinct);
            var map = new Dictionary<T, int>();
            var remap = new Dictionary<int, T>();
            foreach (var (x, i) in distinct.Select((x, i) => (x, i)))
            {
                map[x] = i;
                remap[i] = x;
            }
            return (map, remap);
        }

        public static class Scanner
        {
            public static string ScanLine() => Console.ReadLine()?.Trim() ?? string.Empty;
            public static string[] Scan() => ScanLine().Split(' ');
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
