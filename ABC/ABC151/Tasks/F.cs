using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
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
            var N = Scanner.Scan<int>();
            var P = new Point[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                P[i] = new Point(x, y);
            }

            var list = new List<Point>();
            for (var i = 0; i < N; i++)
            {
                for (var j = i + 1; j < N; j++)
                {
                    var mid = new Point((P[i].X + P[j].X) / 2, (P[i].Y + P[j].Y) / 2);
                    list.Add(mid);
                    for (var k = j + 1; k < N; k++)
                    {
                        var cc = new Triangle(P[i], P[j], P[k]).Circumcenter();
                        if (!double.IsNaN(cc.X) && !double.IsNaN(cc.Y)) list.Add(cc);
                    }
                }
            }

            const double inf = 1e18;
            var answer = inf;
            foreach (var p1 in list)
            {
                var max = 0d;
                foreach (var p2 in P)
                {
                    var d = Point.Distance(p1, p2);
                    max = Math.Max(max, d);
                }

                answer = Math.Min(answer, max);
            }

            Console.WriteLine(answer);
        }

        public readonly struct Point : IEquatable<Point>
        {
            public readonly double X;
            public readonly double Y;
            public Point(double x = 0, double y = 0) => (X, Y) = (x, y);
            public static double Distance(in Point p1, in Point p2)
            {
                var (dx, dy) = (p1.X - p2.X, p1.Y - p2.Y);
                return Math.Sqrt(dx * dx + dy * dy);
            }
            public bool Equals(Point other) => X.Equals(other.X) && Y.Equals(other.Y);
            public override bool Equals(object obj) => obj is Point other && Equals(other);
            public override int GetHashCode() => HashCode.Combine(X, Y);
            public override string ToString() => $"<{X}, {Y}>";
        }

        public readonly struct Triangle : IEquatable<Triangle>
        {
            public readonly Point Point1;
            public readonly Point Point2;
            public readonly Point Point3;
            public Triangle(Point point1, Point point2, Point point3) =>
                (Point1, Point2, Point3) = (point1, point2, point3);
            public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
                => (Point1, Point2, Point3) = (new Point(x1, y1), new Point(x2, y2), new Point(x3, y3));
            public double Aria()
            {
                var (dx1, dy1) = (Point2.X - Point1.X, Point2.Y - Point1.Y);
                var (dx2, dy2) = (Point3.X - Point1.X, Point3.Y - Point1.Y);
                return Math.Abs((dx1 * dy2 - dx2 * dy1) / 2);
            }
            public Point Incenter()
            {
                var a = Point.Distance(Point2, Point3);
                var b = Point.Distance(Point3, Point1);
                var c = Point.Distance(Point1, Point2);
                return WeightedPoint(a, b, c);
            }
            public Point Circumcenter()
            {
                var a = Point.Distance(Point2, Point3);
                var b = Point.Distance(Point3, Point1);
                var c = Point.Distance(Point1, Point2);
                var (aa, bb, cc) = (a * a, b * b, c * c);
                var w1 = aa * (bb + cc - aa);
                var w2 = bb * (cc + aa - bb);
                var w3 = cc * (aa + bb - cc);
                return WeightedPoint(w1, w2, w3);
            }
            public Point Orthocenter()
            {
                var a = Point.Distance(Point2, Point3);
                var b = Point.Distance(Point3, Point1);
                var c = Point.Distance(Point1, Point2);
                var (aa, bb, cc) = (a * a, b * b, c * c);
                var w1 = aa * aa - (bb - cc) * (bb - cc);
                var w2 = bb * bb - (cc - aa) * (cc - aa);
                var w3 = cc * cc - (aa - bb) * (aa - bb);
                return WeightedPoint(w1, w2, w3);
            }
            public Point Centroid() => WeightedPoint(1, 1, 1);
            public IEnumerable<Point> Excenters()
            {
                var a = Point.Distance(Point2, Point3);
                var b = Point.Distance(Point3, Point1);
                var c = Point.Distance(Point1, Point2);
                return new[] { WeightedPoint(-a, b, c), WeightedPoint(a, -b, c), WeightedPoint(a, b, -c) };
            }
            private Point WeightedPoint(double w1, double w2, double w3)
            {
                var x = (w1 * Point1.X + w2 * Point2.X + w3 * Point3.X) / (w1 + w2 + w3);
                var y = (w1 * Point1.Y + w2 * Point2.Y + w3 * Point3.Y) / (w1 + w2 + w3);
                return new Point(x, y);
            }
            public bool Equals(Triangle other) =>
                Point1.Equals(other.Point1) && Point2.Equals(other.Point2) && Point3.Equals(other.Point3);
            public override bool Equals(object obj) => obj is Triangle other && Equals(other);
            public override int GetHashCode() => HashCode.Combine(Point1, Point2, Point3);
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
