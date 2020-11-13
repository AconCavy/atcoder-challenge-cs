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
            var S = Scanner.Scan<int>();
            MInt.SetMod1000000007();
            var dp = new MInt[S + 1];
            for (var i = 3; i <= S; i++)
            {
                dp[i] = (MInt)1;
            }
            for (var i = 3; i <= S; i++)
            {
                for (var j = 3; j <= S; j++)
                {
                    if (i - j < 0) continue;
                    dp[i] += dp[i - j];
                }
            }
            Console.WriteLine(dp[S]);
        }

        public readonly struct MInt
        {
            public long Value { get; }
            public static long Mod { get; private set; } = 998244353;

            public MInt(long data) => Value = (0 <= data ? data : data + Mod) % Mod;
            public static implicit operator long(MInt mint) => mint.Value;
            public static implicit operator int(MInt mint) => (int)mint.Value;
            public static implicit operator MInt(long val) => new MInt(val);
            public static implicit operator MInt(int val) => new MInt(val);
            public static MInt operator +(MInt a, MInt b) => a.Value + b.Value;
            public static MInt operator +(MInt a, long b) => a.Value + b;
            public static MInt operator +(MInt a, int b) => a.Value + b;
            public static MInt operator -(MInt a, MInt b) => a.Value - b.Value;
            public static MInt operator -(MInt a, long b) => a.Value - b;
            public static MInt operator -(MInt a, int b) => a.Value - b;
            public static MInt operator *(MInt a, MInt b) => a.Value * b.Value;
            public static MInt operator *(MInt a, long b) => a.Value * (b % Mod);
            public static MInt operator *(MInt a, int b) => a.Value * (b % Mod);
            public static MInt operator /(MInt a, MInt b) => a * b.Inverse();
            public static MInt operator /(MInt a, long b) => a.Value * Inverse(b);
            public static MInt operator /(MInt a, int b) => a.Value * Inverse(b);
            public static bool operator ==(MInt a, MInt b) => a.Value == b.Value;
            public static bool operator !=(MInt a, MInt b) => a.Value != b.Value;
            public bool Equals(MInt other) => Value == other.Value;
            public override bool Equals(object obj) => obj is MInt other && Equals(other);
            public override int GetHashCode() => Value.GetHashCode();
            public override string ToString() => Value.ToString();

            public MInt Inverse() => Inverse(Value);

            public static MInt Inverse(long a)
            {
                if (a == 0) return 0;
                var p = Mod;
                var (x1, y1, x2, y2) = (1L, 0L, 0L, 1L);
                while (true)
                {
                    if (p == 1) return (x2 % Mod + Mod) % Mod;
                    var div = a / p;
                    x1 -= x2 * div;
                    y1 -= y2 * div;
                    a %= p;
                    if (a == 1) return (x1 % Mod + Mod) % Mod;
                    div = p / a;
                    x2 -= x1 * div;
                    y2 -= y1 * div;
                    p %= a;
                }
            }

            public MInt Power(long n) => Power(Value, n);

            public static MInt Power(MInt x, long n)
            {
                if (n < 0) throw new ArgumentException();
                var r = new MInt(1);
                while (n > 0)
                {
                    if ((n & 1) > 0) r *= x;
                    x *= x;
                    n >>= 1;
                }

                return r;
            }

            public static void SetMod(long m) => Mod = m;
            public static void SetMod998244353() => SetMod(998244353);
            public static void SetMod1000000007() => SetMod(1000000007);
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
