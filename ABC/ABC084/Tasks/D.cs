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
            var Q = Scanner.Scan<int>();
            var aggP = new int[(int)1e5 + 1];
            var prime = new Prime(2);
            for (var i = 2; i < aggP.Length; i++)
            {
                aggP[i] = aggP[i - 1];
                if (prime.IsPrime(i) && prime.IsPrime((i + 1) / 2)) aggP[i]++;
            }
            for (var i = 0; i < Q; i++)
            {
                var (l, r) = Scanner.Scan<int, int>();
                var answer = aggP[r] - aggP[l - 1];
                Console.WriteLine(answer);
            }
        }

        public class Prime
        {
            public Dictionary<long, long> Factors => new Dictionary<long, long>(_factors);
            private Dictionary<long, long> _factors;
            private static HashSet<long> _primes;
            public Prime(long n)
            {
                if (_primes == null) _primes = new HashSet<long>();
                _factors = new Dictionary<long, long>();
                var tmp = n;
                var max = (long)Math.Sqrt(n);
                var p = 2;
                while (p <= max)
                {
                    if (tmp % p == 0)
                    {
                        _factors[p] = 0;
                        _primes.Add(p);
                        while (tmp % p == 0)
                        {
                            tmp /= p;
                            _factors[p]++;
                        }
                    }
                    p++;
                }
                if (tmp > 1)
                {
                    _factors[tmp] = 1;
                    _primes.Add(tmp);
                }
            }
            public bool IsPrime(long n)
            {
                if (_primes.Contains(n)) return true;
                var p = new Prime(n);
                return _primes.Contains(n);
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
