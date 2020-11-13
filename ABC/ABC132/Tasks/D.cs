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
            var (N, K) = Scanner.Scan<int, int>();
            const int p = (int)1e9 + 7;
            for (var i = 1; i <= K; i++)
            {
                var a = Enumeration.CombinationCount(N - K + 1, i, p);
                var b = Enumeration.CombinationCount(K - 1, i - 1, p);
                Console.WriteLine(a * b % p);
            }
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
                if (n < 0) return 0;
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
                if (n < 0) return 0;
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

            public static IEnumerable<IEnumerable<T>> Permutation<T>(IEnumerable<T> items)
            {
                var queue = new Queue<T>(items);
                var n = queue.Count;
                if (n == 0) yield return new T[0];
                for (var i = 0; i < n; i++)
                {
                    var x = queue.Dequeue();
                    foreach (var next in Permutation(queue)) yield return new[] { x }.Concat(next);
                    queue.Enqueue(x);
                }
            }

            public static long PermutationCount(long n, long k)
            {
                if (n < k) return 0;
                return Fractorial(n) / Fractorial(n - k);
                // no memo
                // var ret = 1L;
                // for (var i = 0; i < k; i++) ret *= (n - i);
                // return ret;
            }

            public static long PermutationCount(long n, long k, long mod)
            {
                if (n < k) return 0;
                var top = Fractorial(n, mod);
                var bottom = Fractorial(n - k, mod);
                return (top * Power(bottom, mod - 2, mod)) % mod;
                // no memo
                // var ret = 1L;
                // for (var i = 0; i < k; i++) ret = (ret * (n - i) % mod) % mod;
                // return ret;
            }

            public static long CombinationCount(long n, long k)
            {
                if (n < k) return 0;
                k = Math.Min(k, n - k);
                return Fractorial(n) / (Fractorial(k) * Fractorial(n - k));
                // no memo
                // return PermutationCount(n, k) / PermutationCount(k, k);
            }

            public static long CombinationCount(long n, long k, long mod)
            {
                if (n < k) return 0;
                k = Math.Min(k, n - k);
                var top = Fractorial(n, mod);
                var bottom = (Fractorial(k, mod) * Fractorial(n - k, mod)) % mod;
                // no memo
                // var top = PermutationCount(n, k, mod);
                // var bottom = PermutationCount(k, k, mod);
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
