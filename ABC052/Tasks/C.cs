using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var N = int.Parse(Console.ReadLine());
            var p = (int)1e9 + 7;
            var answer = 1L;
            var factors = new Dictionary<int, int>();
            for (var i = N; i >= 1; i--)
            {
                var prime = new Prime(i);
                foreach (var f in prime.Factors)
                {
                    if (!factors.ContainsKey(f.Key)) factors[f.Key] = 0;
                    factors[f.Key] += f.Value;
                }
            }

            foreach (var f in factors)
            {
                answer *= f.Value + 1;
                answer %= p;
            }

            Console.WriteLine(answer);
        }

        public class Prime
        {
            public Dictionary<int, int> Factors => new Dictionary<int, int>(_factors);
            private Dictionary<int, int> _factors;
            private static HashSet<int> _primes;
            public Prime(int n)
            {
                if (_primes == null) _primes = new HashSet<int>();
                _factors = new Dictionary<int, int>();
                var tmp = n;
                var max = (int)Math.Sqrt(n);
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
            public bool IsPrime(int n)
            {
                if (_primes.Contains(n)) return true;
                var p = new Prime(n);
                return _primes.Contains(n);
            }
        }
    }
}
