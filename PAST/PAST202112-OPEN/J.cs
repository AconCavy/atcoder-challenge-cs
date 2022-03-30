using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Tasks
{
    public class J
    {
        public static void Main()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (N, Q) = Scanner.Scan<int, int>();
            var center = (double)(N + 1) / 2;
            var points = new List<(int, Matrix)>();
            var transforms = new Matrix[Q];

            for (var i = 0; i < Q; i++)
            {
                var line = Scanner.ScanEnumerable<string>().ToArray();
                if (line.Length == 3)
                {
                    var x = double.Parse(line[1]) - center;
                    var y = double.Parse(line[2]) - center;
                    var mat = new Matrix(3, 1);
                    mat[0, 0] = x;
                    mat[1, 0] = y;
                    mat[2, 0] = 1;
                    points.Add((i, mat));

                    transforms[i] = Matrix.Identity(3);
                }
                else
                {
                    var mat = (line[0], line[1]) switch
                    {
                        ("2", "A") => RotateClockwise(),
                        ("2", "B") => RotateCounterClockwise(),
                        ("3", "A") => FlipUD(),
                        ("3", "B") => FlipLR(),
                        _ => Matrix.Identity(3),
                    };

                    transforms[i] = mat;
                }
            }

            var cum = new Matrix[Q];
            cum[^1] = transforms[^1];
            for (var i = Q - 2; i >= 0; i--)
            {
                cum[i] = cum[i + 1].Multiply(transforms[i]);
            }

            var G = new int[N, N];
            foreach (var p in points.Select(x => cum[x.Item1].Multiply(x.Item2)))
            {
                var x = (int)(p[0, 0] + center) - 1;
                var y = (int)(p[1, 0] + center) - 1;
                G[x, y] ^= 1;
            }

            Printer.Print2D(G);
        }

        public static Matrix RotateClockwise()
        {
            var result = Matrix.Identity(3);
            result[0, 0] = result[1, 1] = 0;
            result[0, 1] = 1;
            result[1, 0] = -1;
            return result;
        }

        public static Matrix RotateCounterClockwise()
        {
            var result = Matrix.Identity(3);
            result[0, 0] = result[1, 1] = 0;
            result[0, 1] = -1;
            result[1, 0] = 1;
            return result;
        }

        public static Matrix FlipUD()
        {
            var result = Matrix.Identity(3);
            result[0, 0] = -1;
            result[0, 2] = 0;
            return result;
        }

        public static Matrix FlipLR()
        {
            var result = Matrix.Identity(3);
            result[1, 1] = -1;
            return result;
        }

        public readonly struct Matrix
        {
            public int Height { get; }
            public int Width { get; }
            public double this[int row, int column]
            {
                get => _data[row, column];
                set => _data[row, column] = value;
            }
            private readonly double[,] _data;
            public Matrix(int height, int width)
            {
                Height = height;
                Width = width;
                _data = new double[height, width];
            }
            public static Matrix Identity(int n)
            {
                var matrix = new Matrix(n, n);
                for (var i = 0; i < n; i++) matrix[i, i] = 1;
                return matrix;
            }
            public Matrix Add(in Matrix other) => Add(this, other);
            public static Matrix Add(in Matrix a, in Matrix b)
            {
                if (a.Height != b.Height) throw new ArgumentException("The matrix heights do not match");
                if (a.Width != b.Width) throw new ArgumentException("The matrix widths do not match");
                var c = new Matrix(a.Height, a.Width);
                for (var i = 0; i < b.Height; i++)
                    for (var j = 0; j < b.Width; j++)
                        c[i, j] = a[i, j] + b[i, j];
                return c;
            }
            public Matrix Multiply(in Matrix other) => Multiply(this, other);
            public static Matrix Multiply(in Matrix a, in Matrix b)
            {
                if (a.Width != b.Height) throw new ArgumentException();
                var c = new Matrix(a.Height, b.Width);
                for (var i = 0; i < a.Height; i++)
                    for (var k = 0; k < b.Height; k++)
                        for (var j = 0; j < b.Width; j++)
                            c[i, j] += a[i, k] * b[k, j];
                return c;
            }
            public override string ToString()
            {
                var builder = new StringBuilder();
                for (var i = 0; i < Height; i++)
                {
                    for (var j = 0; j < Width; j++)
                    {
                        builder.Append(_data[i, j]);
                        builder.Append(j == Width - 1 ? "\n" : " ");
                    }
                }
                return builder.ToString();
            }
        }

        public static class Printer
        {
            public static void Print<T>(T source) => Console.WriteLine(source);
            public static void Print1D<T>(IEnumerable<T> source, string separator = "") =>
                Console.WriteLine(string.Join(separator, source));
            public static void Print1D<T, U>(IEnumerable<T> source, Func<T, U> selector, string separator = "") =>
                Console.WriteLine(string.Join(separator, source.Select(selector)));
            public static void Print2D<T>(IEnumerable<IEnumerable<T>> source, string separator = "") =>
                Console.WriteLine(string.Join("\n", source.Select(x => string.Join(separator, x))));
            public static void Print2D<T, U>(IEnumerable<IEnumerable<T>> source, Func<T, U> selector, string separator = "") =>
                Console.WriteLine(string.Join("\n", source.Select(x => string.Join(separator, x.Select(selector)))));
            public static void Print2D<T>(T[,] source, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(source[i, j]);
                        Console.Write(j == w - 1 ? "\n" : separator);
                    }
            }
            public static void Print2D<T, U>(T[,] source, Func<T, U> selector, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(selector(source[i, j]));
                        Console.Write(j == w - 1 ? "\n" : separator);
                    }
            }
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
