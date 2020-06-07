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
            var max = 55555;
            var prime = new Prime(max);
            var primes = new long[n];
            var i = 0;
            var p = 6;
            while (i < n && p <= max)
            {
                if (prime.IsPrime(p))
                {
                    primes[i] = p;
                    i++;
                }
                p += 5;
            }
            Console.WriteLine(string.Join(" ", primes));
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
    }
}
