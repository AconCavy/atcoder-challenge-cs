using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var T = Scanner.Scan<int>();
            for (var i = 0; i < T; i++)
            {
                var (N, A, B) = Scanner.Scan<long, long, long>();
                if (N - A - B < 0) { Console.WriteLine(0); continue; }
                var (n, a, b) = ((ModuloInteger)N, (ModuloInteger)A, (ModuloInteger)B);
                var patA = (n - a + 1);
                var patB = (n - b + 1);
                var x4 = (n - a - b + 2) * (n - a - b + 1);
                var x2 = patA * patB - x4;
                var x1 = x2 * x2;
                var answer = patA * patA * patB * patB - x1;
                Console.WriteLine(answer);
            }
        }

        public readonly struct ModuloInteger
        {
            public long Value { get; }
            public const long Modulo = 1000000007;
            public ModuloInteger(long data) => Value = 0 <= data % Modulo ? data % Modulo : data % Modulo + Modulo;
            public static implicit operator long(ModuloInteger mint) => mint.Value;
            public static implicit operator int(ModuloInteger mint) => (int)mint.Value;
            public static implicit operator ModuloInteger(long val) => new ModuloInteger(val);
            public static implicit operator ModuloInteger(int val) => new ModuloInteger(val);
            public static ModuloInteger operator +(ModuloInteger a, ModuloInteger b) => a.Value + b.Value;
            public static ModuloInteger operator +(ModuloInteger a, long b) => a.Value + b;
            public static ModuloInteger operator +(ModuloInteger a, int b) => a.Value + b;
            public static ModuloInteger operator -(ModuloInteger a, ModuloInteger b) => a.Value - b.Value;
            public static ModuloInteger operator -(ModuloInteger a, long b) => a.Value - b;
            public static ModuloInteger operator -(ModuloInteger a, int b) => a.Value - b;
            public static ModuloInteger operator *(ModuloInteger a, ModuloInteger b) => a.Value * b.Value;
            public static ModuloInteger operator *(ModuloInteger a, long b) => a.Value * (b % Modulo);
            public static ModuloInteger operator *(ModuloInteger a, int b) => a.Value * (b % Modulo);
            public static ModuloInteger operator /(ModuloInteger a, ModuloInteger b) => a * b.Inverse();
            public static ModuloInteger operator /(ModuloInteger a, long b) => a.Value * Inverse(b);
            public static ModuloInteger operator /(ModuloInteger a, int b) => a.Value * Inverse(b);
            public static bool operator ==(ModuloInteger a, ModuloInteger b) => a.Value == b.Value;
            public static bool operator !=(ModuloInteger a, ModuloInteger b) => a.Value != b.Value;
            public bool Equals(ModuloInteger other) => Value == other.Value;
            public override bool Equals(object obj) => obj is ModuloInteger other && Equals(other);
            public override int GetHashCode() => Value.GetHashCode();
            public override string ToString() => Value.ToString();
            public ModuloInteger Inverse() => Inverse(Value);
            public static ModuloInteger Inverse(long a)
            {
                if (a == 0) return 0;
                var p = Modulo;
                var (x1, y1, x2, y2) = (1L, 0L, 0L, 1L);
                while (true)
                {
                    if (p == 1) return x2;
                    var div = a / p;
                    x1 -= x2 * div;
                    y1 -= y2 * div;
                    a %= p;
                    if (a == 1) return x1;
                    div = p / a;
                    x2 -= x1 * div;
                    y2 -= y1 * div;
                    p %= a;
                }
            }
            public ModuloInteger Power(long n) => Power(Value, n);
            public static ModuloInteger Power(ModuloInteger x, long n)
            {
                if (n < 0) throw new ArgumentException();
                var r = new ModuloInteger(1);
                while (n > 0)
                {
                    if ((n & 1) > 0) r *= x;
                    x *= x;
                    n >>= 1;
                }
                return r;
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
