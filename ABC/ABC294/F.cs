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
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (N, M, K) = Scanner.Scan<int, int, int>();
            var SW1 = new SW[N];
            var SW2 = new SW[M];

            Fraction F(SW a, SW b) => new Fraction(100L * (a.S + b.S), a.S + b.S + a.W + b.W);

            for (var i = 0; i < N; i++)
            {
                var (s, w) = Scanner.Scan<int, int>();
                SW1[i] = new SW(s, w);
            }

            for (var i = 0; i < M; i++)
            {
                var (s, w) = Scanner.Scan<int, int>();
                SW2[i] = new SW(s, w);
            }
        }

        public readonly struct SW
        {
            public readonly long S;
            public readonly long W;
            public SW(long s, long w) => (S, W) = (s, w);
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
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]), Convert<T6>(buffer[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static string[] Scan()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
