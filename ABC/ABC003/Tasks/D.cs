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
            var (R, C) = Scanner.Scan<long, long>();
            var (X, Y) = Scanner.Scan<long, long>();
            var (D, L) = Scanner.Scan<long, long>();
            var p = (int)1e9 + 7;

            long Calc(long x, long y, long d, long l, long mod)
            {
                if (x * y < d + l) return 0;
                var ret = Enumeration.CombinationCount(x * y, d, mod);
                ret *= Enumeration.CombinationCount(x * y - d, l, mod);
                ret %= mod;
                return ret;
            }

            var pattern = ((R - X + 1) * (C - Y + 1)) % p;
            var comb = 0L;
            if (D + L == X * Y)
            {
                comb = Enumeration.CombinationCount(D + L, D, p);
            }
            else
            {
                comb = Calc(X, Y, D, L, p);

                comb = (comb + p - (Calc(X - 1, Y, D, L, p) * 2) % p) % p;
                comb = (comb + p - (Calc(X, Y - 1, D, L, p) * 2) % p) % p;

                comb = (comb + (Calc(X - 1, Y - 1, D, L, p) * 4) % p) % p;
                comb = (comb + Calc(X - 2, Y, D, L, p)) % p;
                comb = (comb + Calc(X, Y - 2, D, L, p)) % p;

                comb = (comb + p - (Calc(X - 2, Y - 1, D, L, p) * 2) % p) % p;
                comb = (comb + p - (Calc(X - 1, Y - 2, D, L, p) * 2) % p) % p;

                comb = (comb + Calc(X - 2, Y - 2, D, L, p)) % p;
            }

            var answer = (comb * pattern) % p;
            Console.WriteLine(answer);
        }

        public static class Enumeration
        {
            private static Dictionary<long, long> _memo = new Dictionary<long, long> { { 0, 1 }, { 1, 1 } };
            private static Dictionary<long, long> _modMemo = new Dictionary<long, long> { { 0, 1 }, { 1, 1 } };
            private static long _max = 1;
            private static long _modMax = 1;

            public static long Fractorial(long n)
            {
                if (_memo.ContainsKey(n)) return _memo[n];
                if (n < 0) throw new ArgumentException();
                var val = _memo[_max];
                for (var i = _max + 1; i <= n; i++)
                {
                    val *= i;
                    _memo[i] = val;
                }
                _max = n;
                return _memo[n];
            }

            public static long Fractorial(long n, long mod)
            {
                if (_modMemo.ContainsKey(n)) return _modMemo[n];
                if (n < 0) throw new ArgumentException();
                var val = _modMemo[_modMax];
                for (var i = _modMax + 1; i <= n; i++)
                {
                    val *= i % mod;
                    val %= mod;
                    _modMemo[i] = val;
                }
                _modMax = n;
                return _modMemo[n];
            }

            public static long PermutationCount(long n, long k)
            {
                if (n < k) throw new ArgumentException();
                return Fractorial(n) / Fractorial(n - k);
            }

            public static long PermutationCount(long n, long k, long mod)
            {
                if (n < k) throw new ArgumentException();
                var top = Fractorial(n, mod);
                var bottom = Fractorial(n - k, mod);
                return (top * Power(bottom, mod - 2, mod)) % mod;
            }

            public static long CombinationCount(long n, long k)
            {
                if (n < k) throw new ArgumentException();
                return Fractorial(n) / (Fractorial(k) * Fractorial(n - k));
            }

            public static long CombinationCount(long n, long k, long mod)
            {
                if (n < k) throw new ArgumentException();
                var top = Fractorial(n, mod);
                var bottom = (Fractorial(k, mod) * Fractorial(n - k, mod)) % mod;
                return (top * Power(bottom, mod - 2, mod)) % mod;
            }

            public static long Power(long x, long y, long mod)
            {
                var result = 1L;
                while (y > 0)
                {
                    var xmod = x % mod;
                    if ((y & 1) == 1) result = (result * xmod) % mod;
                    x = (xmod * xmod) % mod;
                    y >>= 1;
                }
                return result;
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
