using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

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
        var (N, M) = Scanner.Scan<int, int>();
        var G = new List<(int, long B, long C)>[N].Select(x => new List<(int, long B, long C)>()).ToArray();
        for (var i = 0; i < M; i++)
        {
            var (u, v, b, c) = Scanner.Scan<int, int, long, long>();
            u--; v--;
            G[u].Add((v, b, c));
        }

        var dp = new Fraction[N];
        var zero = new Fraction(0, 1);
        Array.Fill(dp, zero);

        for (var u = 0; u < N - 1; u++)
        {
            var uf = dp[u];
            foreach (var (v, b, c) in G[u])
            {
                var vf = u == 0 ? new Fraction(b, c) : new Fraction(uf.Y + b, uf.X + c);
                if (vf > dp[v]) dp[v] = vf;
            }
        }

        var rf = dp[^1];
        var answer = (double)rf.GY / rf.GX;
        Console.WriteLine(answer);
    }

    public static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);

    public readonly struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
    {
        public long Y { get; }
        public long X { get; }
        public long GY { get; }
        public long GX { get; }
        public Fraction(long y, long x)
        {
            var g = Gcd(y, x);
            (Y, X, GY, GX) = (y, x, y / g, x / g);
        }
        public static bool operator <(Fraction left, Fraction right) => left.CompareTo(right) < 0;
        public static bool operator <=(Fraction left, Fraction right) => left.CompareTo(right) <= 0;
        public static bool operator >(Fraction left, Fraction right) => left.CompareTo(right) > 0;
        public static bool operator >=(Fraction left, Fraction right) => left.CompareTo(right) >= 0;
        public static bool operator ==(Fraction left, Fraction right) => left.Equals(right);
        public static bool operator !=(Fraction left, Fraction right) => !left.Equals(right);
        public int CompareTo(Fraction other) => (GY * other.GX).CompareTo(GX * other.GY);
        public bool Equals(Fraction other) => Y == other.Y && X == other.X;
        public override bool Equals(object obj) => obj is Fraction other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(Y, X);
        public override string ToString() => $"{Y}/{X}";
    }

    public class PriorityQueue<T> : IReadOnlyCollection<T>
    {
        private readonly Comparison<T> _comparison;
        private readonly List<T> _heap;
        public PriorityQueue(IEnumerable<T> items, IComparer<T> comparer = null) : this(comparer)
        {
            foreach (var item in items) Enqueue(item);
        }
        public PriorityQueue(IEnumerable<T> items, Comparison<T> comparison) : this(comparison)
        {
            foreach (var item in items) Enqueue(item);
        }
        public PriorityQueue(IComparer<T> comparer = null) : this((comparer ?? Comparer<T>.Default).Compare) { }
        public PriorityQueue(Comparison<T> comparison)
        {
            _heap = new List<T>();
            _comparison = comparison;
        }
        public int Count => _heap.Count;
        public IEnumerator<T> GetEnumerator() => _heap.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Enqueue(T item)
        {
            var child = Count;
            _heap.Add(item);
            while (child > 0)
            {
                var parent = (child - 1) / 2;
                if (_comparison(_heap[parent], _heap[child]) <= 0) break;
                (_heap[parent], _heap[child]) = (_heap[child], _heap[parent]);
                child = parent;
            }
        }
        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException();
            var result = _heap[0];
            _heap[0] = _heap[Count - 1];
            _heap.RemoveAt(Count - 1);
            var parent = 0;
            while (parent * 2 + 1 < Count)
            {
                var left = parent * 2 + 1;
                var right = parent * 2 + 2;
                if (right < Count && _comparison(_heap[left], _heap[right]) > 0)
                    left = right;
                if (_comparison(_heap[parent], _heap[left]) <= 0) break;
                (_heap[parent], _heap[left]) = (_heap[left], _heap[parent]);
                parent = left;
            }
            return result;
        }
        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException();
            return _heap[0];
        }
        public bool TryDequeue(out T result)
        {
            if (Count > 0)
            {
                result = Dequeue();
                return true;
            }
            result = default;
            return false;
        }
        public bool TryPeek(out T result)
        {
            if (Count > 0)
            {
                result = Peek();
                return true;
            }
            result = default;
            return false;
        }
        public void Clear() => _heap.Clear();
        public bool Contains(T item) => _heap.Contains(item);
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
