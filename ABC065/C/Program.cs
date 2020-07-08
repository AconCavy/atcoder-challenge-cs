using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
{
    public class Program
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
            var NM = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var (N, M) = (NM[0], NM[1]);
            var p = (long)1e9 + 7;
            var answer = 0L;
            if (Math.Abs(N - M) < 2)
            {
                var npn = Enumeration.Fractorial(N, p);
                var mpm = Enumeration.Fractorial(M, p);
                answer = npn * mpm % p;
                if (N == M)
                {
                    answer *= 2;
                    answer %= p;
                }
            }
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
                    if ((y & 1) == 1) result = ((result % mod) * (x % mod)) % mod;
                    x = ((x % mod) * (x % mod)) % mod;
                    y >>= 1;
                }
                return result;
            }
        }
    }
}
