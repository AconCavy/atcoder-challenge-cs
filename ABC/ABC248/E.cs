using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var (N, K) = Scanner.Scan<int, int>();
            if (K == 1)
            {
                Console.WriteLine("Infinity");
                return;
            }

            var P = new (long X, long Y)[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<long, long>();
                P[i] = (x, y);
            }


            var answer = 0;
            for (var i = 0; i < N; i++)
            {
                var dict = new Dictionary<Fraction, int>();
                for (var j = i + 1; j < N; j++)
                {
                    var (x1, y1) = P[i];
                    var (x2, y2) = P[j];
                    var (dx, dy) = (x2 - x1, y2 - y1);
                    var frac = new Fraction(dy, dx);
                    if (!dict.ContainsKey(frac)) dict[frac] = 0;
                    dict[frac]++;
                }

                foreach (var count in dict.Values)
                {
                    if (count == K - 1) answer++;
                }
            }

            Console.WriteLine(answer);
        }

        public readonly struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
        {
            public long Y { get; }
            public long X { get; }
            public Fraction(long y, long x)
            {
                static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);
                var g = Gcd(y, x);
                (Y, X) = (y / g, x / g);
            }
            public static bool operator <(Fraction left, Fraction right) => left.CompareTo(right) < 0;
            public static bool operator <=(Fraction left, Fraction right) => left.CompareTo(right) <= 0;
            public static bool operator >(Fraction left, Fraction right) => left.CompareTo(right) > 0;
            public static bool operator >=(Fraction left, Fraction right) => left.CompareTo(right) >= 0;
            public static bool operator ==(Fraction left, Fraction right) => left.Equals(right);
            public static bool operator !=(Fraction left, Fraction right) => !left.Equals(right);
            public int CompareTo(Fraction other) => (Y * other.X).CompareTo(X * other.Y);
            public bool Equals(Fraction other) => Y == other.Y && X == other.X;
            public override bool Equals(object obj) => obj is Fraction other && Equals(other);
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
