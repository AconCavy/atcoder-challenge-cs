using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var N = 4;
            var P = new Point[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                P[i] = new Point(x, y);
            }

            double Area(Point b, Point a, Point c)
            {
                var (dx1, dy1) = (a.X - b.X, a.Y - b.Y);
                var (dx2, dy2) = (c.X - b.X, c.Y - b.Y);
                return dx1 * dy2 - dx2 * dy1;
            }

            for (var i = 0; i < N; i++)
            {
                for (var j = i + 1; j < N; j++)
                {
                    if (Area(P[(i - 1 + 4) % 4], P[i], P[j]) < 0 || Area(P[i], P[(i + 1) % 4], P[j]) < 0)
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }

            Console.WriteLine("Yes");
        }

        public readonly struct Point : IComparable<Point>, IEquatable<Point>
        {
            public long X { get; }
            public long Y { get; }
            public Point(long x, long y) => (X, Y) = (x, y);
            public static bool operator <(Point left, Point right) => left.CompareTo(right) < 0;
            public static bool operator <=(Point left, Point right) => left.CompareTo(right) <= 0;
            public static bool operator >(Point left, Point right) => left.CompareTo(right) > 0;
            public static bool operator >=(Point left, Point right) => left.CompareTo(right) >= 0;
            public static bool operator ==(Point left, Point right) => left.Equals(right);
            public static bool operator !=(Point left, Point right) => !left.Equals(right);
            public int CompareTo(Point other) => (Y * other.X).CompareTo(X * other.Y);
            public bool Equals(Point other) => Y == other.Y && X == other.X;
            public override bool Equals(object obj) => obj is Point other && Equals(other);
            public override int GetHashCode() => HashCode.Combine(Y, X);
            public override string ToString() => $"{Y}/{X}";
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
