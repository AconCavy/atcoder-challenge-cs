using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var n = int.Parse(Console.ReadLine());
            var pi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = 0L;
        }
    }

    public static class Enumeration
    {
        private static Dictionary<long, long> _memo = new Dictionary<long, long>();
        private static Dictionary<long, long> _modMemo = new Dictionary<long, long>();

        public static long Fractorial(long n)
        {
            if (_memo.ContainsKey(n)) return _memo[n];
            if (n < 0) throw new ArgumentException();
            if (n <= 1) return _memo[n] = 1;
            return _memo[n] = n * Fractorial(n - 1);
        }

        public static long Fractorial(long n, long mod)
        {
            if (_modMemo.ContainsKey(n)) return _modMemo[n];
            if (n < 0) throw new ArgumentException();
            if (n <= 1) return _modMemo[n] = 1;
            return _modMemo[n] = ((n % mod) * Fractorial(n - 1, mod)) % mod;
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
